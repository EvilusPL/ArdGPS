// ArdGPS - Arduino-based GPS tracker for sports use
// (C) 2017 Jarosław Rauza, University of Zielona Góra.
// Licensed under GNU GPL v2 License

// Including libraries
#include <TinyGPS++.h>                                                // TinyGPS++ library for parsing NMEA data
#include <SoftwareSerial.h>                                           // For software communication with GPS shield board via embedded serial port
#include <SPI.h>                                                      // SD card reader is connected to Arduino via SPI port, so we need to use that library
#include <SD.h>                                                       // For communicating with build-in SD card reader

// Defining the consts
#define GPS_BAUD 9600                                                 // GPS baud, it works on 9600 b/s
#define GPS_RX 3                                                      // GPS data receiving pin is 3, change if the jumper has changed 
#define GPS_TX 2                                                      // GPS data sending pin is 2, change if the jumper has changed
#define SD_PIN 8                                                      // SD card reader is connected to Arduino on pin 8
#define LOG_FILENAME "ardgps"                                        // Name of the log file
#define MAX_NUM_OF_FILES 100                                          // Maximum number of log files on SD card
#define LOG_EXTENSION "csv"                                           // We will save them as csv files, able to open in LibreOffice Calc, or Microsoft Excel
#define LOG_COLUMNS 8                                                 // Log columns
#define LOG_DELAY 5000                                                // Log every 5 seconds

// Defining the variables
TinyGPSPlus gpsData;                                                  // Create a TinyGPS++ object, we will collect usable data from this
SoftwareSerial gpsDevice(GPS_TX, GPS_RX);                             // Create a SoftwareSerial with GPS board (in my case, DuinoPeak GPS Shield)
char logFilename[16];                                                 // File name string buffer
char* logColNames[LOG_COLUMNS] = {                                    // Log column names for CSV file
  "Latitude", "Longitude", "Altitude", "Speed", "Course", "Date",
  "Time", "Satellites"
};
unsigned long timeAfterLastLog = 0;                                   // To know last time that we made a log

// Last defines to have access to serial terminal and GPS device
#define gpsPort gpsDevice                                             // GPS board alias
#define SerialIO Serial                                               // Terminal input/output

//Setup the device
void setup() {
  SerialIO.begin(115200);                                             // Initialize serial I/O on 115200 b/s to not collide with GPS module shield
  SerialIO.println("");
  SerialIO.println("ArdGPS ALPHA 1 DEBUG CONSOLE");
  SerialIO.println("Initializing GPS device... ");
  gpsPort.begin(9600);                                                // Initialize GPS device
  SerialIO.println("Initializing SD card...");
  if (!SD.begin(SD_PIN)) {                                            // If initialization of SD card failed
    SerialIO.println("Device work is impossible, system halting...");
    while (1 == 1) {                                                  // Infinite loop to interrupt the program

    }
  }
  SerialIO.println("Creating new file...");
  generateFileName();                                                 // Generate new file name
  printHeader();                                                      // Print a header at the top of file
}

// Do the work of the device
void loop() {
  if ((timeAfterLastLog + LOG_DELAY) <= millis()) {                   // If it's been LOG_DELAY milliseconds since the last log
    if (gpsData.location.isUpdated()) {                               // and if tne GPS data is updated and valid
      if (logGPSData()) {                                             // Log GPS data
        SerialIO.println("Logged data to file!");                     // Print message to the serial output
        timeAfterLastLog = millis();                                  // Save time after log
      }
      else {                                                          // If logging data to file failed
        SerialIO.println("Logging data to file failed!");             // Send info for serial output
      }
    }
    else {                                                            // If GPS data is invalid
      SerialIO.print("GPS data invalid. Sats: ");
      SerialIO.println(gpsData.satellites.value());
    }
  }
  while (gpsDevice.available()) {                                     // If GPS is sending data
    gpsData.encode(gpsDevice.read());                                 // Send it to parser
  }
}

// Function to log single line of GPS data
byte logGPSData() {
  File logOutput = SD.open(logFilename, FILE_WRITE);                  // Open log file to write
  if (logOutput) {                                                    // If file is successfully opened
    logOutput.print(gpsData.location.lat(), 6);                       // Write latitude, ...
    logOutput.print(',');
    logOutput.print(gpsData.location.lng(), 6);                       // ... longitude, ...
    logOutput.print(',');
    logOutput.print(gpsData.altitude.meters(), 1);                    // ... altitude, ...
    logOutput.print(',');
    logOutput.print(gpsData.speed.kmph(), 1);                         // ... speed, ...
    logOutput.print(',');
    logOutput.print(gpsData.course.deg(), 1);                         // ... course, ...
    logOutput.print(',');
    logOutput.print(gpsData.date.day());                              // ... date, ...
    logOutput.print('/');
    logOutput.print(gpsData.date.month());
    logOutput.print('/');
    logOutput.print(gpsData.date.year());
    logOutput.print(',');
    logOutput.print(gpsData.time.hour());                             // ... time, ...
    logOutput.print(':');
    if (gpsData.time.minute() < 10) {
      logOutput.print('0');
    }
    logOutput.print(gpsData.time.minute());
    logOutput.print(':');
    if (gpsData.time.second() < 10) {
      logOutput.print('0');
    }
    logOutput.print(gpsData.time.second());
    logOutput.print(',');
    logOutput.print(gpsData.satellites.value());                      // ... and satellites count
    logOutput.println();                                              // Start new line
    logOutput.close();                                                // and close the file
    SerialIO.print(logColNames[0]);                                   // And write GPS data to the serial output
    SerialIO.print(": ");
    SerialIO.println(gpsData.location.lat(), 6);
    SerialIO.print(logColNames[1]);
    SerialIO.print(": ");
    SerialIO.println(gpsData.location.lng(), 6);
    SerialIO.print(logColNames[2]);
    SerialIO.print(": ");
    SerialIO.println(gpsData.altitude.meters(), 1);
    SerialIO.print(logColNames[3]);
    SerialIO.print(": ");
    SerialIO.println(gpsData.speed.kmph(), 1);
    SerialIO.print(logColNames[4]);
    SerialIO.print(": ");
    SerialIO.println(gpsData.course.deg(), 1);
    SerialIO.print(logColNames[5]);
    SerialIO.print(": ");
    SerialIO.print(gpsData.date.day());
    SerialIO.print('/');
    SerialIO.print(gpsData.date.month());
    SerialIO.print('/');
    SerialIO.println(gpsData.date.year());
    SerialIO.print(logColNames[6]);
    SerialIO.print(": ");
    SerialIO.print(gpsData.time.hour());
    SerialIO.print(':');
    if (gpsData.time.minute() < 10) {
      SerialIO.print('0');
    }
    SerialIO.print(gpsData.time.minute());
    SerialIO.print(':');
    if (gpsData.time.second() < 10) {
      SerialIO.print('0');
    }
    SerialIO.println(gpsData.time.second());
    SerialIO.print(logColNames[7]);
    SerialIO.print(": ");
    SerialIO.println(gpsData.satellites.value());
    return 1;                                                         // Return that device has sucessfully logged data
  }
  return 0;                                                           // If device has failed to open file, return error
}

// Function to write the header of CSV file (eight columns)
void printHeader() {
  File logOutput = SD.open(logFilename, FILE_WRITE);                  // Open log file to write
  if (logOutput) {                                                    // If file is successfully opened
    for (int i = 0; i < LOG_COLUMNS; i++) {
      logOutput.print(logColNames[i]);                                // Print column names to CSV file
      if (i < LOG_COLUMNS - 1) {                                      // If we haven't written last column
        logOutput.print(',');                                         // print comma
      }
      else {                                                          // If it's the last column
        logOutput.println();                                          // Just print a new line
      }
    }
    logOutput.close();                                                // Close the file
  }
}

// Function to generate new file name for our log
void generateFileName() {
  for (int i = 0; i < MAX_NUM_OF_FILES; i++) {
    memset(logFilename, 0, strlen(logFilename));                      // Clear logFilename string buffer
    sprintf(logFilename, "%s%d.%s", LOG_FILENAME, i, LOG_EXTENSION);  // Set the file name in which we will log GPS data
    if (SD.exists(logFilename)) {                                     // If file exists
      SerialIO.print(logFilename);                                    // Log it to the serial debug console
      SerialIO.println(" exists");
    }
    else {                                                            // Otherwise
      break;                                                          // Break the loop, since we haven't file with that name
    }
  }
  SerialIO.print("Logging to file: ");                                // Report it to the debug console
  SerialIO.println(logFilename);
}


