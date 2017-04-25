using System;
using System.Diagnostics;
using System.IO;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Panning_Evaluation_Touch_Pad
{
    /// <summary>
    /// Provides functions and variables for logging
    /// </summary>
    class DataLogger
    {
        private MainWindow mainWindow; // Referred to the MainWindow class of the program

        // Logging variables
        private string deviceName; // Name of the device on that the program runs
        private string itemSetName; // Actual item set name
        private string filePathItemSetName; // Name of the item set in the filename
        private FileStream logFS; // Filestream for logging
        private StreamWriter logSW; // Streamwriter for logging
        private string logFilesPath; // Path on which the logging data will be stored

        // Recall Logging variables
        private FileStream recallLogFS; // Filestream for recall logging
        private StreamWriter recallLogSW; // Streamwriter for recall logging

        /// <summary>
        /// Constructor of DataLogger
        /// </summary>
        /// <param name="deviceName">Name of the device on that the program runs.</param>
        /// <param name="logFilesPath">Path on which the logging data will be stored.</param>
        public DataLogger(string deviceName, string logFilesPath)
        {
            mainWindow = (MainWindow) Application.Current.MainWindow;
            this.deviceName = deviceName;
            this.itemSetName = "Item Set B";
            this.logFilesPath = logFilesPath;

            // Debug stuff
            Debug.WriteLine("LOGFILE PATH: " + logFilesPath);
        }

        /// <summary>
        /// Creates the logfile in which the logging data is stored.
        /// </summary>
        public async void CreateLogFile()
        {
            if (mainWindow.isTouch)
            {
                Directory.CreateDirectory(logFilesPath);
                string filename = logFilesPath + filePathItemSetName + "Touch_" + mainWindow.ParticipantComboBox.SelectedIndex + "_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".csv";
                logFS = new FileStream(@filename, FileMode.OpenOrCreate, FileAccess.Write);
                logSW = new StreamWriter(logFS);
                logSW.BaseStream.Seek(0, SeekOrigin.End);
                await logSW.WriteLineAsync("Participant No: " + mainWindow.ParticipantComboBox.SelectedIndex + " | Input device: Touch | " + itemSetName + " | Computer name: " + deviceName + " | Iterations: " + mainWindow.countIterations);
                await logSW.WriteLineAsync("Ticks ; CenterOfScreen_x ; CenterOfScreen_y ; Scale ; ReferencePointScreen_x ; ReferencePointScreen_y ; ReferencePointLandscape_x ; ReferencePointLandscape_y ; Object_ID");
            }
            else
            {
                Directory.CreateDirectory(logFilesPath);
                string filename = logFilesPath + filePathItemSetName + "Pad_" + mainWindow.ParticipantComboBox.SelectedIndex + "_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".csv";
                logFS = new FileStream(@filename, FileMode.OpenOrCreate, FileAccess.Write);
                logSW = new StreamWriter(logFS);
                logSW.BaseStream.Seek(0, SeekOrigin.End);
                await logSW.WriteLineAsync("Participant No: " + mainWindow.ParticipantComboBox.SelectedIndex + " | Input device: Pad | " + itemSetName + " | Computer name: " + deviceName + " | Iterations: " + mainWindow.countIterations);
                await logSW.WriteLineAsync("Ticks ; CenterOfScreen_x ; CenterOfScreen_y ; Scale ; ReferencePointScreen_x ; ReferencePointScreen_y ; ReferencePointLandscape_x ; ReferencePointLandscape_y ; Object_ID");
            }
        }

        /// <summary>
        /// Creates the logfile in which the recall logging data is stored.
        /// </summary>
        public async void CreateRecallLogFile()
        {
            if (mainWindow.isTouch)
            {
                Directory.CreateDirectory(logFilesPath);
                string filename = logFilesPath + "Touch_Recall_" + mainWindow.ParticipantComboBox.SelectedIndex + "_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".csv";
                recallLogFS = new FileStream(@filename, FileMode.OpenOrCreate, FileAccess.Write);
                recallLogSW = new StreamWriter(recallLogFS);
                recallLogSW.BaseStream.Seek(0, SeekOrigin.End);
                await recallLogSW.WriteLineAsync("Recall | Participant No: " + mainWindow.ParticipantComboBox.SelectedIndex + " | Input device: Touch | " + itemSetName + " | Computer name: " + deviceName + " | Iterations: " + mainWindow.countIterations);
                await recallLogSW.WriteLineAsync("Ticks ; Object_ID ; Key ; GridPosition_x ; GridPosition_y");
            }
            else
            {
                Directory.CreateDirectory(logFilesPath);
                string filename = logFilesPath + "Pad_Recall_" + mainWindow.ParticipantComboBox.SelectedIndex + "_" + DateTime.Now.ToString("yyyy_MM_dd_HH_mm_ss") + ".csv";
                recallLogFS = new FileStream(@filename, FileMode.OpenOrCreate, FileAccess.Write);
                recallLogSW = new StreamWriter(recallLogFS);
                recallLogSW.BaseStream.Seek(0, SeekOrigin.End);
                await recallLogSW.WriteLineAsync("Recall | Participant No: " + mainWindow.ParticipantComboBox.SelectedIndex + " | Input device: Pad | " + itemSetName + " | Computer name: " + deviceName + " | Iterations: " + mainWindow.countIterations);
                await recallLogSW.WriteLineAsync("Ticks ; Object_ID ; Key ; GridPosition_x ; GridPosition_y");
            }
        }

        /// <summary>
        /// Finishes the logging process safely.
        /// </summary>
        public async void FlushAsync()
        {
            if (logSW != null)
            {
                await logSW.FlushAsync();
            }
            if (recallLogSW != null)
            {
                await recallLogSW.FlushAsync();
            }
        }

        /// <summary>
        /// Returns the path on which the logging data will be stored.
        /// </summary>
        /// <returns>File path on which the logging data will be stored</returns>
        public string GetLogFilesPath()
        {
            return logFilesPath;
        }

        /// <summary>
        /// Sets the name of the actual item set type for logging purposes.
        /// </summary>
        /// <param name="itemSetName"></param>
        public void SetItemSetName(string itemSetName)
        {
            this.itemSetName = itemSetName;
            if (itemSetName.Contains("Demo"))
            {
                filePathItemSetName = "-Demo-";
            }
            else if (itemSetName.Contains("Exercise"))
            {
                filePathItemSetName = "-Exercise-";
            }
            else
            {
                filePathItemSetName = " ";
            }
        }

        /// <summary>
        /// Writes a logging entry into the previously generated logging file.
        /// </summary>
        /// <param name="panX">X position of the left top pixel relating to the whole panning landscape</param>
        /// <param name="panY">Y position of the left top pixel relating to the whole panning landscape</param>
        /// <param name="touchX">X touch position on the screen</param>
        /// <param name="touchY">Y touch position on the screen</param>
        /// <param name="actualSearchItemNumber">ID of the actual searched item</param>
        public async void WriteLogStamp(double panX, double panY, double touchX, double touchY, string actualSearchItemNumber)
        {
            try
            {
                await logSW.WriteLineAsync(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss,fff") + " ; " + (panX + mainWindow.resolutionX / 2) + " ; " + (panY + mainWindow.resolutionY / 2) + " ; " + "1" + " ; " + touchX + " ; " + touchY + " ; " + (panX + touchX) + " ; " + (panY + touchY) + " ; " + actualSearchItemNumber);
            }
            catch
            {
                System.Diagnostics.Debug.WriteLine("Logging Schritt wurde nicht eingetragen: " + DateTime.Now.ToString("HH:mm:ss.fff"));
            }
        }

        /// <summary>
        /// Writes a recall logging entry into the previously generated logging file.
        /// </summary>
        /// <param name="recallGridX">Actual x position of the black rectangle</param>
        /// <param name="recallGridY">Actual y position of the black rectangle</param>
        /// <param name="actualSetItemNumber">ID of the actual searched item</param>
        /// <param name="key">Actual pressed key on the keyboard</param>
        /// <returns>Zero when finished</returns>
        public async Task<int> WriteRecallLogStamp(int recallGridX, int recallGridY, int actualSetItemNumber, Key key)
        {
            await recallLogSW.WriteLineAsync(DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss,fff") + " ; " + actualSetItemNumber + ";" + key.ToString() + " ; " + recallGridX + " ; " + recallGridY);
            return 0;
        }
    }
}
