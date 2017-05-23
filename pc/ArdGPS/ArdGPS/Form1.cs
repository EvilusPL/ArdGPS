using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace ArdGPS
{
    public partial class mainWindow : Form
    {
        public mainWindow()
        {
            InitializeComponent();
        }

        private void aboutArdGPSToolStripMenuItem_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }

        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
                                                                                                                                                                               
            DialogResult result = openFileDialog.ShowDialog();
            string fileName="";
            if (result == DialogResult.OK)                                                                                                                                    
            {
                try
                {
                    string buffer;                                                                                                                                             
                    string[] newItem = new string[8];
                    ListViewItem tmpItem;
                    int i = 0;
                    int commaCounter = 0;
                    int fileHeader = 0;                                                                                                                                        
                    string csvFile = openFileDialog.FileName;                                                                                                                  
                    fileName = csvFile;
                    StreamReader csvFileOp = new StreamReader(csvFile);                                                                   
                    listView.Items.Clear();
                    while (csvFileOp.Peek()>=0)
                    {
                        buffer = csvFileOp.ReadLine();
                        if (fileHeader == 0)
                        {
                            
                            if (!buffer.Contains("Latitude,Longitude,Altitude,Speed,Course,Date,Time,Satellites"))
                            {
                                MessageBox.Show("File " + csvFile + " is not created by ArdGPS device", "Error opening file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                return;
                            }
                            fileHeader = 1;                                                           
                        }
                        else
                        {
                            commaCounter = 0;
                            for (i=0; i<buffer.Length; i++)
                            {
                                if(buffer[i]!=',')
                                {
                                    newItem[commaCounter] = newItem[commaCounter] + buffer[i];
                                }
                                else 
                                {
                                    commaCounter++;
                                }
                            }
                            tmpItem = new ListViewItem(newItem);
                            listView.Items.Add(tmpItem);
                            Array.Clear(newItem, 0, 8);
                        }
                    }
                    this.Text="ArdGPS v1.0 - " + csvFile;
                }
                catch (Exception)
                {
                    MessageBox.Show("Access denied for file " + fileName, "Error opening file", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }
                
            }
        }

        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
