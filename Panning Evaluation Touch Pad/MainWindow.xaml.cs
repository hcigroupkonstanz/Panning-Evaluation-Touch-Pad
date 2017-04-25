using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;

namespace Panning_Evaluation_Touch_Pad
{
    /// <summary>
    /// Panning Evaluation (Touch and Pad support)
    /// Developed at HCI Group University of Konstanz 2016
    /// </summary>
    public partial class MainWindow : Window
    {
        // Initialization
        private bool loaded = false; // Is the program loaded?

        // Logging
        private DataLogger dataLogger; // DataLogger class that provide functions and variables for logging 

        // UI variables
        public double resolutionX, resolutionY; // Resolution of the screen
        private int halfResolutionX, halfResolutionY; // Center of screen coordinates

        // Touch
        private double firstTouchX = 0; // X coordinate of first touch point of the actual panning action
        private double firstTouchY = 0; // Y coordinate of first touch point of the actual panning action
        private double firstTouchLeft = 0; // Actual Panning environment position from left
        private double firstTouchTop = 0; // Actual Panning environment position from top
        private TouchDevice actualTouchDevice; // The actual used TouchDevice for Panning (e.g. when touching with three fingers one finger reprensents a TouchDevice)
        private int actualTouchID = 0; // Id of actual used TouchDevice
        private List<TouchDevice> touchDevices = new List<TouchDevice>(); // List of all actual touching TouchDevices
        private List<int> touchDeviceIDs = new List<int>(); // List of all IDs from all actual touching TouchDevices

        // Pad
        private int relocateCursorThreshold = 100; // Pixel distance to screen edges when cursor will be relocated to screen center

        // Recall
        private int recallGridX = 12; // Starting coordinate x of recall mode
        private int recallGridY = 9; // Starting coordinate y of recall mode

        // Panning variables
        private PanningLandscape panningLandscape; // PanningLandscape class provides hard coded information (e.g. position of items) of the panning landscape
        public bool isTouch = true; // Is touch the actual input device?
        public bool isPad = false; // Is pad the actual input device?
        private double lastX, lastY; // Last position of panning environment
        private bool isPanning = false; // Actual during panning process?
        private bool noTransition = true; // In transition between the found item and the new item?

        // Task variables
        private bool isTaskMode = false; // Actual in task mode?
        private bool isExerciseMode = false; // Actual in exercise mode?
        private bool isDemoMode = false; // Actual in demo mode?
        private int itemSetNumber = (int) ItemSet.B; // Selected item set
        private int actualLeftSearch = 0; // Position from left of actual searched item in the whole panning environment
        private int actualTopSearch = 0; // Position from top of actual searched item in the whole panning environment
        private int actualSearchIndex = 0; // Index of actual searched item in item set list (PanningLandscape)
        private string actualSearchNumber; // Number of the actual searched item
        public int countIterations = 1; // Count of item set iterations
        private int actualIteration = 0; // Actual iteration number

        // Animation
        private Storyboard myStoryboard; // Storyboard for animation between items


        // ----------------------------- Program initialization, loading and closing functions -----------------------------


        /// <summary>
        /// Constructor of MainWindow
        /// </summary>
        public MainWindow()
        {
            Loaded += MainWindow_Loaded;
            Closing += MainWindow_Closing;
            InitializeComponent();

            // Initialize DataLogger object for logging
            dataLogger = new DataLogger(Environment.MachineName, Environment.CurrentDirectory + "\\Logdata\\");
            LogpathTextBlock.Text = "Path Logdata: " + dataLogger.GetLogFilesPath();

            // Panning environment initialization
            panningLandscape = new PanningLandscape();
            resolutionX = SystemParameters.PrimaryScreenWidth;
            resolutionY = SystemParameters.PrimaryScreenHeight;
            halfResolutionX = Convert.ToInt32(resolutionX / 2);
            halfResolutionY = Convert.ToInt32(resolutionY / 2);
            PanScrollViewer.Width = resolutionX;
            PanScrollViewer.Height = resolutionY;
            lastX = 4800 - resolutionX / 2;
            lastY = 2700 - resolutionY / 2;
            PanScrollViewer.ScrollToHorizontalOffset(lastX);
            PanScrollViewer.ScrollToVerticalOffset(lastY);

            // Animation storyboard initialization
            myStoryboard = this.FindResource("ZoomElementOut") as Storyboard;
            myStoryboard.Completed += (o, s) =>
            {
                ActualSearchElement.Width = 180;
                ActualSearchElement.Height = 180;
                LeftBorderNew.Visibility = Visibility.Visible;
                RightBorderNew.Visibility = Visibility.Visible;
                noTransition = true;
            };
        }

        /// <summary>
        /// Will be called when the program is loaded.
        /// </summary>
        /// <param name="sender">Object that triggers the method</param>
        /// <param name="e">Event arguments</param>
        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            loaded = true;
        }

        /// <summary>
        /// Will be called before the program will close.
        /// </summary>
        /// <param name="sender">Object that triggers the method</param>
        /// <param name="e">Event arguments</param>
        private async void MainWindow_Closing(object sender, CancelEventArgs e)
        {
            dataLogger.FlushAsync();
        }


        // ----------------------------- Touch and mouse panning functionality -----------------------------


        /// <summary>
        /// Will be called when the mouse button is pressed.
        /// </summary>
        /// <param name="sender">Object that triggers the method</param>
        /// <param name="e">Event arguments</param>
        private void HitRectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.StylusDevice == null && noTransition)
            {
                firstTouchX = e.GetPosition(HitRectangle).X;
                firstTouchY = e.GetPosition(HitRectangle).Y;
                firstTouchLeft = PanScrollViewer.HorizontalOffset;
                firstTouchTop = PanScrollViewer.VerticalOffset;
                isPanning = true;
            }
        }

        /// <summary>
        /// Will be called when the mouse button is released.
        /// </summary>
        /// <param name="sender">Object that triggers the method</param>
        /// <param name="e">Event arguments</param>
        private void HitRectangle_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (e.StylusDevice == null)
            {
                firstTouchX = e.GetPosition(HitRectangle).X;
                firstTouchY = e.GetPosition(HitRectangle).Y;
                firstTouchLeft = PanScrollViewer.HorizontalOffset;
                firstTouchTop = PanScrollViewer.VerticalOffset;
                isPanning = false;
            }
        }

        /// <summary>
        /// Will be called when the mouse cursor moving over the HitRectangle
        /// </summary>
        /// <param name="sender">Object that triggers the method</param>
        /// <param name="e">Event arguments</param>
        private void HitRectangle_MouseMove(object sender, MouseEventArgs e)
        {
            if (isPanning && e.StylusDevice == null)
            {
                PanScrollViewer.ScrollToHorizontalOffset(firstTouchLeft + (firstTouchX - e.GetPosition(HitRectangle).X));
                PanScrollViewer.ScrollToVerticalOffset(firstTouchTop + (firstTouchY - e.GetPosition(HitRectangle).Y));
                dataLogger.WriteLogStamp(PanScrollViewer.HorizontalOffset, PanScrollViewer.VerticalOffset, e.GetPosition(HitRectangle).X, e.GetPosition(HitRectangle).Y, actualSearchNumber);
            }
        }

        /// <summary>
        /// Will be called when touching the HitRectangle.
        /// </summary>
        /// <param name="sender">Object that triggers the method</param>
        /// <param name="e">Event arguments</param>
        private void HitRectangle_TouchDown(object sender, TouchEventArgs e)
        {
            touchDeviceIDs.Add(e.GetTouchPoint(HitRectangle).TouchDevice.Id);
            touchDevices.Add(e.TouchDevice);
            actualTouchID = touchDeviceIDs.First();
            actualTouchDevice = touchDevices.First();
            if (actualTouchID == e.GetTouchPoint(HitRectangle).TouchDevice.Id && noTransition)
            {
                firstTouchX = e.GetTouchPoint(HitRectangle).Position.X;
                firstTouchY = e.GetTouchPoint(HitRectangle).Position.Y;
                firstTouchLeft = PanScrollViewer.HorizontalOffset;
                firstTouchTop = PanScrollViewer.VerticalOffset;
                isPanning = true;
            }
        }

        /// <summary>
        /// Will be called when a TouchDevice (e.g. a finger) is leaving the HitRectangle
        /// </summary>
        /// <param name="sender">Object that triggers the method</param>
        /// <param name="e">Event arguments</param>
        private void HitRectangle_TouchUp(object sender, TouchEventArgs e)
        {
            touchDeviceIDs.Remove(e.GetTouchPoint(HitRectangle).TouchDevice.Id);
            touchDevices.Remove(e.TouchDevice);
            try
            {
                actualTouchID = touchDeviceIDs.First();
                actualTouchDevice = touchDevices.First();
                firstTouchX = actualTouchDevice.GetTouchPoint(HitRectangle).Position.X;
                firstTouchY = actualTouchDevice.GetTouchPoint(HitRectangle).Position.Y;
                firstTouchLeft = PanScrollViewer.HorizontalOffset;
                firstTouchTop = PanScrollViewer.VerticalOffset;
            }
            catch
            {
                isPanning = false;
            }
        }

        /// <summary>
        /// Will be called while a TouchDevice (e.g. a finger) is moving over the HitRectangle
        /// </summary>
        /// <param name="sender">Object that triggers the method</param>
        /// <param name="e">Event arguments</param>
        private void HitRectangle_TouchMove(object sender, TouchEventArgs e)
        {
            if (isPanning & e.GetTouchPoint(HitRectangle).TouchDevice.Id == actualTouchID)
            {
                PanScrollViewer.ScrollToHorizontalOffset(firstTouchLeft + (firstTouchX - e.GetTouchPoint(HitRectangle).Position.X));
                PanScrollViewer.ScrollToVerticalOffset(firstTouchTop + (firstTouchY - e.GetTouchPoint(HitRectangle).Position.Y));
                dataLogger.WriteLogStamp(PanScrollViewer.HorizontalOffset, PanScrollViewer.VerticalOffset, e.GetTouchPoint(HitRectangle).Position.X, e.GetTouchPoint(HitRectangle).Position.Y, actualSearchNumber);
            }
        }


        // ----------------------------- Pad panning functionality -----------------------------

        /// <summary>
        /// Will be called when the mouse is moving on the PanScrollViewer
        /// </summary>
        /// <param name="sender">Object that triggers the method</param>
        /// <param name="e">Event arguments</param>
        private void PanScrollViewer_MouseMove(object sender, MouseEventArgs e)
        {
            if (isPad)
            {
                if (noTransition && e.GetPosition(PanScrollViewer).X > relocateCursorThreshold && e.GetPosition(PanScrollViewer).X < resolutionX - relocateCursorThreshold && e.GetPosition(PanScrollViewer).Y > relocateCursorThreshold && e.GetPosition(PanScrollViewer).Y < resolutionY - relocateCursorThreshold)
                {
                    PanScrollViewer.ScrollToHorizontalOffset(lastX + (halfResolutionX - e.GetPosition(PanScrollViewer).X));
                    PanScrollViewer.ScrollToVerticalOffset(lastY + (halfResolutionY - e.GetPosition(PanScrollViewer).Y));
                    dataLogger.WriteLogStamp(PanScrollViewer.HorizontalOffset, PanScrollViewer.VerticalOffset, 0, 0, actualSearchNumber);
                }
                else
                {
                    lastX = PanScrollViewer.HorizontalOffset;
                    lastY = PanScrollViewer.VerticalOffset;
                    NativeMethods.SetCursorPos(halfResolutionX, halfResolutionY);
                }            
            }
        }

        /// <summary>
        /// NativeMethods class provides method to set the cursor to a new position
        /// </summary>
        public partial class NativeMethods
        {
            [System.Runtime.InteropServices.DllImportAttribute("user32.dll", EntryPoint = "SetCursorPos")]
            [return: System.Runtime.InteropServices.MarshalAsAttribute(System.Runtime.InteropServices.UnmanagedType.Bool)]
            public static extern bool SetCursorPos(int X, int Y);
        }


        // ----------------------------- Keyboard key query -----------------------------


        /// <summary>
        /// Will be called when a keyboard key is pressed.
        /// </summary>
        /// <param name="sender">Object that triggers the method</param>
        /// <param name="e">Event arguments</param>
        private async void Window_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                if (MainMenuGrid.Visibility == Visibility.Visible)
                {
                    Application.Current.Shutdown();
                }
                else
                {
                    dataLogger.FlushAsync();
                    Mouse.OverrideCursor = Cursors.Arrow;
                    OptionsMenuGrid.Visibility = Visibility.Collapsed;
                    MainMenuGrid.Visibility = Visibility.Visible;
                    ModeEndGrid.Visibility = Visibility.Collapsed;
                    RecallGrid.Visibility = Visibility.Collapsed;
                    RecallEndGrid.Visibility = Visibility.Collapsed;
                }
            }
            if (RecallGrid.Visibility == Visibility.Visible)
            {
                if (e.Key == Key.Left && NavigationRectangle.Margin.Left > 1)
                {
                    NavigationRectangle.Margin = new Thickness(NavigationRectangle.Margin.Left - 80, NavigationRectangle.Margin.Top, 0, 0);
                    recallGridX--;
                    if(!isDemoMode)
                    {
                        switch (itemSetNumber)
                        {
                            case 0:
                                if (panningLandscape.GetItemSetAFull().Length > actualSearchIndex)
                                {
                                    try
                                    {
                                        await dataLogger.WriteRecallLogStamp(recallGridX, recallGridY, panningLandscape.GetItemSetAFull()[actualSearchIndex], e.Key);
                                    }
                                    catch
                                    {

                                    }
                                }
                                break;
                            case 1:
                                if (panningLandscape.GetItemSetBFull().Length > actualSearchIndex)
                                {
                                    try
                                    {
                                        await dataLogger.WriteRecallLogStamp(recallGridX, recallGridY, panningLandscape.GetItemSetBFull()[actualSearchIndex], e.Key);
                                    }
                                    catch
                                    {

                                    }
                                }
                                break;
                            case 2:
                                if (panningLandscape.GetItemSetCFull().Length > actualSearchIndex)
                                {
                                    try
                                    {
                                        await dataLogger.WriteRecallLogStamp(recallGridX, recallGridY, panningLandscape.GetItemSetCFull()[actualSearchIndex], e.Key);
                                    }
                                    catch
                                    {

                                    }
                                }
                                break;
                        }
                    }
                }
                if (e.Key == Key.Up && NavigationRectangle.Margin.Top > 1)
                {
                    NavigationRectangle.Margin = new Thickness(NavigationRectangle.Margin.Left, NavigationRectangle.Margin.Top - 60, 0, 0);
                    recallGridY--;
                    if(!isDemoMode)
                    {
                        switch (itemSetNumber)
                        {
                            case 0:
                                if (panningLandscape.GetItemSetAFull().Length > actualSearchIndex)
                                {
                                    try
                                    {
                                        await dataLogger.WriteRecallLogStamp(recallGridX, recallGridY, panningLandscape.GetItemSetAFull()[actualSearchIndex], e.Key);
                                    }
                                    catch
                                    {

                                    }
                                }
                                break;
                            case 1:
                                if (panningLandscape.GetItemSetBFull().Length > actualSearchIndex)
                                {
                                    try
                                    {
                                        await dataLogger.WriteRecallLogStamp(recallGridX, recallGridY, panningLandscape.GetItemSetBFull()[actualSearchIndex], e.Key);
                                    }
                                    catch
                                    {

                                    }
                                }
                                break;
                            case 2:
                                if (panningLandscape.GetItemSetCFull().Length > actualSearchIndex)
                                {
                                    try
                                    {
                                        await dataLogger.WriteRecallLogStamp(recallGridX, recallGridY, panningLandscape.GetItemSetCFull()[actualSearchIndex], e.Key);
                                    }
                                    catch
                                    {

                                    }
                                }
                                break;
                        }
                    }
                }
                if (e.Key == Key.Right && NavigationRectangle.Margin.Left < 1840)
                {
                    NavigationRectangle.Margin = new Thickness(NavigationRectangle.Margin.Left + 80, NavigationRectangle.Margin.Top, 0, 0);
                    recallGridX++;
                    if(!isDemoMode)
                    {
                        switch (itemSetNumber)
                        {
                            case 0:
                                if (panningLandscape.GetItemSetAFull().Length > actualSearchIndex)
                                {
                                    try
                                    {
                                        await dataLogger.WriteRecallLogStamp(recallGridX, recallGridY, panningLandscape.GetItemSetAFull()[actualSearchIndex], e.Key);
                                    }
                                    catch
                                    {

                                    }
                                }
                                break;
                            case 1:
                                if (panningLandscape.GetItemSetBFull().Length > actualSearchIndex)
                                {
                                    try
                                    {
                                        await dataLogger.WriteRecallLogStamp(recallGridX, recallGridY, panningLandscape.GetItemSetBFull()[actualSearchIndex], e.Key);
                                    }
                                    catch
                                    {

                                    }
                                }
                                break;
                            case 2:
                                if (panningLandscape.GetItemSetCFull().Length > actualSearchIndex)
                                {
                                    try
                                    {
                                        await dataLogger.WriteRecallLogStamp(recallGridX, recallGridY, panningLandscape.GetItemSetCFull()[actualSearchIndex], e.Key);
                                    }
                                    catch
                                    {

                                    }
                                }
                                break;
                        }
                    }
                }
                if (e.Key == Key.Down && NavigationRectangle.Margin.Top < 1020)
                {
                    NavigationRectangle.Margin = new Thickness(NavigationRectangle.Margin.Left, NavigationRectangle.Margin.Top + 60, 0, 0);
                    recallGridY++;
                    if(!isDemoMode)
                    {
                        switch (itemSetNumber)
                        {
                            case 0:
                                if (panningLandscape.GetItemSetAFull().Length > actualSearchIndex)
                                {
                                    try
                                    {
                                        await dataLogger.WriteRecallLogStamp(recallGridX, recallGridY, panningLandscape.GetItemSetAFull()[actualSearchIndex], e.Key);
                                    }
                                    catch
                                    {

                                    }
                                }
                                break;
                            case 1:
                                if (panningLandscape.GetItemSetBFull().Length > actualSearchIndex)
                                {
                                    try
                                    {
                                        await dataLogger.WriteRecallLogStamp(recallGridX, recallGridY, panningLandscape.GetItemSetBFull()[actualSearchIndex], e.Key);
                                    }
                                    catch
                                    {

                                    }
                                }
                                break;
                            case 2:
                                if (panningLandscape.GetItemSetCFull().Length > actualSearchIndex)
                                {
                                    try
                                    {
                                        await dataLogger.WriteRecallLogStamp(recallGridX, recallGridY, panningLandscape.GetItemSetCFull()[actualSearchIndex], e.Key);
                                    }
                                    catch
                                    {

                                    }
                                }
                                break;
                        }
                    }
                }
                if (e.Key == Key.Enter)
                {
                    recallGridX = 12;
                    recallGridY = 9;
                    NavigationRectangle.Margin = new Thickness(880, 480, 0, 0);
                    actualSearchIndex++;
                    if (!isDemoMode)
                    {
                        switch (itemSetNumber)
                    {
                        case 0:
                            if (panningLandscape.GetItemSetAFull().Length > actualSearchIndex)
                            {
                                Uri uri = new Uri(Directory.GetCurrentDirectory() + "\\Assets\\" + panningLandscape.GetItemSetAFull()[actualSearchIndex] + ".png");
                                BitmapImage imgSource = new BitmapImage(uri);
                                ActualRecallElement.Source = imgSource;
                            }
                            else
                            {
                                RecallEndGrid.Visibility = Visibility.Visible;
                                RecallGrid.Visibility = Visibility.Collapsed;
                                dataLogger.FlushAsync();
                            }
                            break;
                        case 1:
                            if (panningLandscape.GetItemSetBFull().Length > actualSearchIndex)
                            {
                                Uri uri = new Uri(Directory.GetCurrentDirectory() + "\\Assets\\" + panningLandscape.GetItemSetBFull()[actualSearchIndex] + ".png");
                                BitmapImage imgSource = new BitmapImage(uri);
                                ActualRecallElement.Source = imgSource;
                            }
                            else
                            {
                                RecallEndGrid.Visibility = Visibility.Visible;
                                RecallGrid.Visibility = Visibility.Collapsed;
                                dataLogger.FlushAsync();
                            }
                            break;
                        case 2:
                            if (panningLandscape.GetItemSetCFull().Length > actualSearchIndex)
                            {
                                Uri uri = new Uri(Directory.GetCurrentDirectory() + "\\Assets\\" + panningLandscape.GetItemSetCFull()[actualSearchIndex] + ".png");
                                BitmapImage imgSource = new BitmapImage(uri);
                                ActualRecallElement.Source = imgSource;
                            }
                            else
                            {
                                RecallEndGrid.Visibility = Visibility.Visible;
                                RecallGrid.Visibility = Visibility.Collapsed;
                                dataLogger.FlushAsync();
                            }
                            break;
                    }
                    }
                    else
                    {
                        if (panningLandscape.GetItemSetDemoFull().Length > actualSearchIndex)
                        {
                            Uri uri = new Uri(Directory.GetCurrentDirectory() + "\\Assets\\" + panningLandscape.GetItemSetDemoFull()[actualSearchIndex] + ".png");
                            BitmapImage imgSource = new BitmapImage(uri);
                            ActualRecallElement.Source = imgSource;
                        }
                        else
                        {
                            RecallEndGrid.Visibility = Visibility.Visible;
                            RecallGrid.Visibility = Visibility.Collapsed;
                        }
                    }
                }   
            }
        }


        // ----------------------------- Main menu UI controls -----------------------------


        /// <summary>
        /// Will be called when the "Settings" button at the main menu is clicked.
        /// </summary>
        /// <param name="sender">Object that triggers the method</param>
        /// <param name="e">Event arguments</param>
        private void OptionsMenuButton_Click(object sender, RoutedEventArgs e)
        {
            OptionsMenuGrid.Visibility = Visibility.Visible;
            MainMenuGrid.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Will be called when the "Demo" button at the main menu is clicked.
        /// </summary>
        /// <param name="sender">Object that triggers the method</param>
        /// <param name="e">Event arguments</param>
        private void DemoModeButton_Click(object sender, RoutedEventArgs e)
        {
            isDemoMode = true;
            isTaskMode = false;
            isExerciseMode = false;
            ActualSearchElement.Visibility = Visibility.Visible;
            actualSearchIndex = 0;
            countIterations = 2;
            actualIteration = 0;
            dataLogger.SetItemSetName("Item Set Demo");
            actualSearchNumber = panningLandscape.GetItemSetDemo()[0];
            SetActualCoordinates(panningLandscape.GetItemSetDemo()[0]);
            Uri uri = new Uri(Directory.GetCurrentDirectory() + "\\Assets\\" + panningLandscape.GetItemSetDemo()[0] + ".png");
            BitmapImage imgSource = new BitmapImage(uri);
            ActualSearchElement.Source = imgSource;
            lastX = panningLandscape.GetStartLeft();
            lastY = panningLandscape.GetStartTop();
            PanScrollViewer.ScrollToHorizontalOffset(panningLandscape.GetStartLeft());
            PanScrollViewer.ScrollToVerticalOffset(panningLandscape.GetStartTop());
            dataLogger.CreateLogFile();

            panningLandscape.SetDemoUI();

            Mouse.OverrideCursor = Cursors.None;
            NativeMethods.SetCursorPos(halfResolutionX, halfResolutionY);
            MainMenuGrid.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Will be called when the "Recall" button at the main menu is clicked.
        /// </summary>
        /// <param name="sender">Object that triggers the method</param>
        /// <param name="e">Event arguments</param>
        private void RecallModeButton_Click(object sender, RoutedEventArgs e)
        {
            isDemoMode = false;
            actualSearchIndex = 0;
            recallGridX = 12;
            recallGridY = 9;
            NavigationRectangle.Margin = new Thickness(880, 480, 0, 0);
            switch (itemSetNumber)
            {
                case 0:
                    Uri uri1 = new Uri(Directory.GetCurrentDirectory() + "\\Assets\\" + panningLandscape.GetItemSetAFull()[0] + ".png");
                    BitmapImage imgSource1 = new BitmapImage(uri1);
                    ActualRecallElement.Source = imgSource1;
                    break;
                case 1:
                    Uri uri2 = new Uri(Directory.GetCurrentDirectory() + "\\Assets\\" + panningLandscape.GetItemSetBFull()[0] + ".png");
                    BitmapImage imgSource2 = new BitmapImage(uri2);
                    ActualRecallElement.Source = imgSource2;
                    break;
                case 2:
                    Uri uri3 = new Uri(Directory.GetCurrentDirectory() + "\\Assets\\" + panningLandscape.GetItemSetCFull()[0] + ".png");
                    BitmapImage imgSource3 = new BitmapImage(uri3);
                    ActualRecallElement.Source = imgSource3;
                    break;
            }
            dataLogger.CreateRecallLogFile();
            RecallGrid.Visibility = Visibility.Visible;
            MainMenuGrid.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Will be called when the "Exercise" button at the main menu is clicked.
        /// </summary>
        /// <param name="sender">Object that triggers the method</param>
        /// <param name="e">Event arguments</param>
        private void ExerciseModeButton_Click(object sender, RoutedEventArgs e)
        {
            isTaskMode = false;
            isExerciseMode = true;
            isDemoMode = false;
            ActualSearchElement.Visibility = Visibility.Visible;
            actualSearchIndex = 0;
            countIterations = RepeatExerciseComboBox.SelectedIndex + 1;
            actualIteration = 0;
            dataLogger.SetItemSetName("Item Set Exercise");
            actualSearchNumber = panningLandscape.GetItemSetExercise()[0].ToString();
            SetActualCoordinates(panningLandscape.GetItemSetExercise()[0]);
            Uri uri = new Uri(Directory.GetCurrentDirectory() + "\\Assets\\" + panningLandscape.GetItemSetExercise()[0] + ".png");
            BitmapImage imgSource = new BitmapImage(uri);
            ActualSearchElement.Source = imgSource;
            lastX = panningLandscape.GetStartLeft();
            lastY = panningLandscape.GetStartTop();
            PanScrollViewer.ScrollToHorizontalOffset(panningLandscape.GetStartLeft());
            PanScrollViewer.ScrollToVerticalOffset(panningLandscape.GetStartTop());
            dataLogger.CreateLogFile();

            panningLandscape.SetExerciseUI();

            Mouse.OverrideCursor = Cursors.None;
            NativeMethods.SetCursorPos(halfResolutionX, halfResolutionY);
            MainMenuGrid.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Will be called when the "Start Task" button at the main menu is clicked.
        /// </summary>
        /// <param name="sender">Object that triggers the method</param>
        /// <param name="e">Event arguments</param>
        private void TaskModeButton_Click(object sender, RoutedEventArgs e)
        {
            isTaskMode = true;
            isExerciseMode = false;
            isDemoMode = false;
            ActualSearchElement.Visibility = Visibility.Visible;
            actualSearchIndex = 0;
            countIterations = RepeatComboBox.SelectedIndex + 1;
            actualIteration = 0;
            switch (itemSetNumber)
            {
                case 0:
                    dataLogger.SetItemSetName("Item Set A");
                    actualSearchNumber = panningLandscape.GetItemSetA()[0].ToString();
                    ItemSetAButton_Click(sender, e);
                    SetActualCoordinates(panningLandscape.GetItemSetA()[0]);
                    Uri uri = new Uri(Directory.GetCurrentDirectory() + "\\Assets\\" + panningLandscape.GetItemSetA()[0] + ".png");
                    BitmapImage imgSource = new BitmapImage(uri);
                    ActualSearchElement.Source = imgSource;
                    break;
                case 1:
                    dataLogger.SetItemSetName("Item Set B");
                    actualSearchNumber = panningLandscape.GetItemSetB()[0].ToString();
                    ItemSetBButton_Click(sender, e);
                    SetActualCoordinates(panningLandscape.GetItemSetB()[0]);
                    Uri uri2 = new Uri(Directory.GetCurrentDirectory() + "\\Assets\\" + panningLandscape.GetItemSetB()[0] + ".png");
                    BitmapImage imgSource2 = new BitmapImage(uri2);
                    ActualSearchElement.Source = imgSource2;
                    break;
                case 2:
                    dataLogger.SetItemSetName("Item Set C");
                    actualSearchNumber = panningLandscape.GetItemSetC()[0].ToString();
                    ItemSetCButton_Click(sender, e);
                    SetActualCoordinates(panningLandscape.GetItemSetC()[0]);
                    Uri uri3 = new Uri(Directory.GetCurrentDirectory() + "\\Assets\\" + panningLandscape.GetItemSetC()[0] + ".png");
                    BitmapImage imgSource3 = new BitmapImage(uri3);
                    ActualSearchElement.Source = imgSource3;
                    break;
            }
            lastX = panningLandscape.GetStartLeft();
            lastY = panningLandscape.GetStartTop();
            PanScrollViewer.ScrollToHorizontalOffset(panningLandscape.GetStartLeft());
            PanScrollViewer.ScrollToVerticalOffset(panningLandscape.GetStartTop());
            dataLogger.CreateLogFile();

            if(isTouch)
            {
                HitRectangle.IsHitTestVisible = true;
            }
            else if(isPad)
            {
                HitRectangle.IsHitTestVisible = false;
                Mouse.OverrideCursor = Cursors.None;
                NativeMethods.SetCursorPos(halfResolutionX, halfResolutionY);
            }
            else
            {
                HitRectangle.IsHitTestVisible = false;
            }
            MainMenuGrid.Visibility = Visibility.Collapsed;
        }


        // ----------------------------- Settings menu UI controls -----------------------------


        /// <summary>
        /// Will be called when the "Participant No." ComboBox selection changed.
        /// </summary>
        /// <param name="sender">Object that triggers the method</param>
        /// <param name="e">Event arguments</param>
        private void ParticipantComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (loaded)
            {
                if (isTouch)
                {
                    switch (ParticipantComboBox.SelectedIndex)
                    {
                        case 1:
                            ItemSetBButton_Click(sender, null);
                            break;
                        case 2:
                            ItemSetCButton_Click(sender, null);
                            break;
                        case 3:
                            ItemSetAButton_Click(sender, null);
                            break;
                        case 4:
                            ItemSetAButton_Click(sender, null);
                            break;
                        case 5:
                            ItemSetBButton_Click(sender, null);
                            break;
                        case 6:
                            ItemSetCButton_Click(sender, null);
                            break;
                        case 7:
                            ItemSetBButton_Click(sender, null);
                            break;
                        case 8:
                            ItemSetCButton_Click(sender, null);
                            break;
                        case 9:
                            ItemSetAButton_Click(sender, null);
                            break;
                        case 10:
                            ItemSetBButton_Click(sender, null);
                            break;
                        case 11:
                            ItemSetCButton_Click(sender, null);
                            break;
                        case 12:
                            ItemSetBButton_Click(sender, null);
                            break;
                        case 13:
                            ItemSetCButton_Click(sender, null);
                            break;
                        case 14:
                            ItemSetBButton_Click(sender, null);
                            break;
                        case 15:
                            ItemSetAButton_Click(sender, null);
                            break;
                        case 16:
                            ItemSetAButton_Click(sender, null);
                            break;
                        case 17:
                            ItemSetAButton_Click(sender, null);
                            break;
                        case 18:
                            ItemSetCButton_Click(sender, null);
                            break;
                        case 19:
                            ItemSetBButton_Click(sender, null);
                            break;
                        case 20:
                            ItemSetCButton_Click(sender, null);
                            break;
                        case 21:
                            ItemSetCButton_Click(sender, null);
                            break;
                        case 22:
                            ItemSetCButton_Click(sender, null);
                            break;
                        case 23:
                            ItemSetBButton_Click(sender, null);
                            break;
                        case 24:
                            ItemSetAButton_Click(sender, null);
                            break;
                        case 25:
                            ItemSetBButton_Click(sender, null);
                            break;
                        case 26:
                            ItemSetAButton_Click(sender, null);
                            break;
                        case 27:
                            ItemSetBButton_Click(sender, null);
                            break;
                        case 28:
                            ItemSetBButton_Click(sender, null);
                            break;
                        case 29:
                            ItemSetCButton_Click(sender, null);
                            break;
                        case 30:
                            ItemSetAButton_Click(sender, null);
                            break;
                        case 31:
                            ItemSetAButton_Click(sender, null);
                            break;
                        case 32:
                            ItemSetBButton_Click(sender, null);
                            break;
                        case 33:
                            ItemSetCButton_Click(sender, null);
                            break;
                        case 34:
                            ItemSetBButton_Click(sender, null);
                            break;
                        case 35:
                            ItemSetCButton_Click(sender, null);
                            break;
                        case 36:
                            ItemSetAButton_Click(sender, null);
                            break;
                    }
                }
                else
                {
                    switch (ParticipantComboBox.SelectedIndex)
                    {
                        case 1:
                            ItemSetAButton_Click(sender, null);
                            break;
                        case 2:
                            ItemSetBButton_Click(sender, null);
                            break;
                        case 3:
                            ItemSetCButton_Click(sender, null);
                            break;
                        case 4:
                            ItemSetCButton_Click(sender, null);
                            break;
                        case 5:
                            ItemSetAButton_Click(sender, null);
                            break;
                        case 6:
                            ItemSetBButton_Click(sender, null);
                            break;
                        case 7:
                            ItemSetCButton_Click(sender, null);
                            break;
                        case 8:
                            ItemSetAButton_Click(sender, null);
                            break;
                        case 9:
                            ItemSetBButton_Click(sender, null);
                            break;
                        case 10:
                            ItemSetCButton_Click(sender, null);
                            break;
                        case 11:
                            ItemSetBButton_Click(sender, null);
                            break;
                        case 12:
                            ItemSetAButton_Click(sender, null);
                            break;
                        case 13:
                            ItemSetAButton_Click(sender, null);
                            break;
                        case 14:
                            ItemSetAButton_Click(sender, null);
                            break;
                        case 15:
                            ItemSetCButton_Click(sender, null);
                            break;
                        case 16:
                            ItemSetBButton_Click(sender, null);
                            break;
                        case 17:
                            ItemSetCButton_Click(sender, null);
                            break;
                        case 18:
                            ItemSetBButton_Click(sender, null);
                            break;
                        case 19:
                            ItemSetCButton_Click(sender, null);
                            break;
                        case 20:
                            ItemSetBButton_Click(sender, null);
                            break;
                        case 21:
                            ItemSetAButton_Click(sender, null);
                            break;
                        case 22:
                            ItemSetAButton_Click(sender, null);
                            break;
                        case 23:
                            ItemSetAButton_Click(sender, null);
                            break;
                        case 24:
                            ItemSetBButton_Click(sender, null);
                            break;
                        case 25:
                            ItemSetAButton_Click(sender, null);
                            break;
                        case 26:
                            ItemSetCButton_Click(sender, null);
                            break;
                        case 27:
                            ItemSetCButton_Click(sender, null);
                            break;
                        case 28:
                            ItemSetAButton_Click(sender, null);
                            break;
                        case 29:
                            ItemSetBButton_Click(sender, null);
                            break;
                        case 30:
                            ItemSetCButton_Click(sender, null);
                            break;
                        case 31:
                            ItemSetCButton_Click(sender, null);
                            break;
                        case 32:
                            ItemSetAButton_Click(sender, null);
                            break;
                        case 33:
                            ItemSetBButton_Click(sender, null);
                            break;
                        case 34:
                            ItemSetCButton_Click(sender, null);
                            break;
                        case 35:
                            ItemSetAButton_Click(sender, null);
                            break;
                        case 36:
                            ItemSetBButton_Click(sender, null);
                            break;
                    }
                }
            }
        }

        /// <summary>
        /// Will be called when the "Touch" button at the settings menu is clicked.
        /// </summary>
        /// <param name="sender">Object that triggers the method</param>
        /// <param name="e">Event arguments</param>
        private void TouchButton_Click(object sender, RoutedEventArgs e)
        {
            isTouch = true;
            isPad = false;

            ParticipantComboBox_SelectionChanged(sender, null);
            SetButtonUIActive(TouchButton);
            SetButtonUIInactive(TouchpadButton);
            SetButtonUIInactive(MoveButton);
        }

        /// <summary>
        /// Will be called when the "Pad" button at the settings menu is clicked.
        /// </summary>
        /// <param name="sender">Object that triggers the method</param>
        /// <param name="e">Event arguments</param>
        private void TouchpadButton_Click(object sender, RoutedEventArgs e)
        {
            isTouch = false;
            isPad = true;

            ParticipantComboBox_SelectionChanged(sender, null);
            SetButtonUIInactive(TouchButton);
            SetButtonUIActive(TouchpadButton);
            SetButtonUIInactive(MoveButton);
        }

        /// <summary>
        /// Will be called when the "Item Set A" button at the settings menu is clicked.
        /// </summary>
        /// <param name="sender">Object that triggers the method</param>
        /// <param name="e">Event arguments</param>
        private void ItemSetAButton_Click(object sender, RoutedEventArgs e)
        {
            if(sender.Equals(ItemSetAButton))
            {
                ParticipantComboBox.SelectedIndex = 0;
            }
            SetButtonUIActive(ItemSetAButton);
            SetButtonUIInactive(ItemSetBButton);
            SetButtonUIInactive(ItemSetCButton);
            itemSetNumber = (int) ItemSet.A;
            panningLandscape.SetItemSetAUI();
        }

        /// <summary>
        /// Will be called when the "Item Set B" button at the settings menu is clicked.
        /// </summary>
        /// <param name="sender">Object that triggers the method</param>
        /// <param name="e">Event arguments</param>
        private void ItemSetBButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender.Equals(ItemSetBButton))
            {
                ParticipantComboBox.SelectedIndex = 0;
            }
            SetButtonUIInactive(ItemSetAButton);
            SetButtonUIActive(ItemSetBButton);
            SetButtonUIInactive(ItemSetCButton);
            itemSetNumber = (int) ItemSet.B;

            panningLandscape.SetItemSetBUI();
        }

        /// <summary>
        /// Will be called when the "Item Set C" button at the settings menu is clicked.
        /// </summary>
        /// <param name="sender">Object that triggers the method</param>
        /// <param name="e">Event arguments</param>
        private void ItemSetCButton_Click(object sender, RoutedEventArgs e)
        {
            if (sender.Equals(ItemSetCButton))
            {
                ParticipantComboBox.SelectedIndex = 0;
            }
            SetButtonUIInactive(ItemSetAButton);
            SetButtonUIInactive(ItemSetBButton);
            SetButtonUIActive(ItemSetCButton);
            itemSetNumber = (int) ItemSet.C;

            panningLandscape.SetItemSetCUI();
        }

        /// <summary>
        /// Will be called when the "Copy path" button at the settings menu is clicked.
        /// </summary>
        /// <param name="sender">Object that triggers the method</param>
        /// <param name="e">Event arguments</param>
        private void LogpathCopyButton_Click(object sender, RoutedEventArgs e)
        {
            System.Windows.Forms.Clipboard.SetDataObject(dataLogger.GetLogFilesPath(), true);
        }

        /// <summary>
        /// Will be called when the "Close" button at the settings menu is clicked.
        /// </summary>
        /// <param name="sender">Object that triggers the method</param>
        /// <param name="e">Event arguments</param>
        private void OptionsMenuCloseButton_Click(object sender, RoutedEventArgs e)
        {
            OptionsMenuGrid.Visibility = Visibility.Collapsed;
            MainMenuGrid.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Changes the visual appearance of the given button to active
        /// </summary>
        /// <param name="button"></param>
        private void SetButtonUIActive(Button button)
        {
            button.Background = new SolidColorBrush(Color.FromArgb(255, 75, 75, 75));
            button.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 0, 255, 0));
            button.BorderThickness = new Thickness(6, 6, 6, 6);
        }

        /// <summary>
        /// Changes the visual appearance of the given button to inactive
        /// </summary>
        /// <param name="button"></param>
        private void SetButtonUIInactive(Button button)
        {
            button.Background = new SolidColorBrush(Color.FromArgb(255, 50, 50, 50));
            button.BorderBrush = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            button.BorderThickness = new Thickness(2, 2, 2, 2);
        }


        // ----------------------------- Task and recall end menu UI controls -----------------------------


        /// <summary>
        /// Will be called when the "Close" button at the task end menu is clicked.
        /// </summary>
        /// <param name="sender">Object that triggers the method</param>
        /// <param name="e">Event arguments</param>
        private void ModeEndCloseButton_Click(object sender, RoutedEventArgs e)
        {
            ModeEndGrid.Visibility = Visibility.Collapsed;
            MainMenuGrid.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Will be called when the "Close" button at the recall end menu is clicked.
        /// </summary>
        /// <param name="sender">Object that triggers the method</param>
        /// <param name="e">Event arguments</param>
        private void RecallEndCloseButton_Click(object sender, RoutedEventArgs e)
        {
            RecallEndGrid.Visibility = Visibility.Collapsed;
            MainMenuGrid.Visibility = Visibility.Visible;
        }


        // ----------------------------- Item panning functions -----------------------------


        /// <summary>
        /// Will be called on every small panning step while panning in PanScrollViewer.
        /// </summary>
        /// <param name="sender">Object that triggers the method</param>
        /// <param name="e">Event arguments</param>
        private void PanScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (noTransition && (isDemoMode || isTaskMode || isExerciseMode) && actualLeftSearch - 100 < e.HorizontalOffset
                                   && actualLeftSearch + 100 > e.HorizontalOffset
                                   && actualTopSearch - 100 < e.VerticalOffset
                                   && actualTopSearch + 100 > e.VerticalOffset)
            {
                noTransition = false;
                isPanning = false;
                PanScrollViewer.ScrollToHorizontalOffset(actualLeftSearch);
                PanScrollViewer.ScrollToVerticalOffset(actualTopSearch);
                FoundStrokeRectangle.Visibility = Visibility.Visible;
                FoundSound.Play();
                lastX = 4800 - resolutionX / 2;
                lastY = 2700 - resolutionY / 2;
                WaitForNextElement();
            }
        }

        /// <summary>
        /// Will be called when the searched item was found and prepares everything for the next searched item or if last item finishes the panning environment.
        /// </summary>
        private async void WaitForNextElement()
        {
            await System.Threading.Tasks.Task.Delay(TimeSpan.FromSeconds(1));
            HitRectangle.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            LeftBorderNew.Visibility = Visibility.Collapsed;
            RightBorderNew.Visibility = Visibility.Collapsed;
            ActualSearchElement.Width = 500;
            ActualSearchElement.Height = 500;
            ActualSearchElement.Opacity = 1;
            WaitForAnimationGrid.Width = 667;
            WaitForAnimationGrid.Height = 500;
            WaitForAnimationGrid.Visibility = Visibility.Visible;
            FoundStrokeRectangle.Visibility = Visibility.Collapsed;
            PanScrollViewer.ScrollToHorizontalOffset(panningLandscape.GetStartLeft());
            PanScrollViewer.ScrollToVerticalOffset(panningLandscape.GetStartTop());
            if (isTaskMode)
            {
                switch (itemSetNumber)
                {
                    case 0:
                        actualSearchIndex++;
                        if (panningLandscape.GetItemSetA().Length > actualSearchIndex)
                        {
                            SetActualCoordinates(panningLandscape.GetItemSetA()[actualSearchIndex]);
                            actualSearchNumber = panningLandscape.GetItemSetA()[actualSearchIndex].ToString();
                            Uri uri = new Uri(Directory.GetCurrentDirectory() + "\\Assets\\" + panningLandscape.GetItemSetA()[actualSearchIndex] + ".png");
                            BitmapImage imgSource = new BitmapImage(uri);
                            ActualSearchElement.Source = imgSource;
                        }
                        else
                        {
                            actualIteration++;
                            if (countIterations > actualIteration)
                            {
                                actualSearchIndex = 0;
                                SetActualCoordinates(panningLandscape.GetItemSetA()[0]);
                                actualSearchNumber = panningLandscape.GetItemSetA()[0].ToString();
                                Uri uri = new Uri(Directory.GetCurrentDirectory() + "\\Assets\\" + panningLandscape.GetItemSetA()[0] + ".png");
                                BitmapImage imgSource = new BitmapImage(uri);
                                ActualSearchElement.Source = imgSource;
                            }
                            else
                            {
                                dataLogger.FlushAsync();
                                Mouse.OverrideCursor = Cursors.Arrow;
                                ModeEndGrid.Visibility = Visibility.Visible;
                            }
                        }
                        break;
                    case 1:
                        actualSearchIndex++;
                        if (panningLandscape.GetItemSetB().Length > actualSearchIndex)
                        {
                            SetActualCoordinates(panningLandscape.GetItemSetB()[actualSearchIndex]);
                            actualSearchNumber = panningLandscape.GetItemSetB()[actualSearchIndex].ToString();
                            Uri uri = new Uri(Directory.GetCurrentDirectory() + "\\Assets\\" + panningLandscape.GetItemSetB()[actualSearchIndex] + ".png");
                            BitmapImage imgSource = new BitmapImage(uri);
                            ActualSearchElement.Source = imgSource;
                        }
                        else
                        {
                            actualIteration++;
                            if (countIterations > actualIteration)
                            {
                                actualSearchIndex = 0;
                                SetActualCoordinates(panningLandscape.GetItemSetB()[0]);
                                actualSearchNumber = panningLandscape.GetItemSetB()[0].ToString();
                                Uri uri = new Uri(Directory.GetCurrentDirectory() + "\\Assets\\" + panningLandscape.GetItemSetB()[0] + ".png");
                                BitmapImage imgSource = new BitmapImage(uri);
                                ActualSearchElement.Source = imgSource;
                            }
                            else
                            {
                                dataLogger.FlushAsync();
                                Mouse.OverrideCursor = Cursors.Arrow;
                                ModeEndGrid.Visibility = Visibility.Visible;
                            }
                        }
                        break;
                    case 2:
                        actualSearchIndex++;
                        if (panningLandscape.GetItemSetC().Length > actualSearchIndex)
                        {
                            SetActualCoordinates(panningLandscape.GetItemSetC()[actualSearchIndex]);
                            actualSearchNumber = panningLandscape.GetItemSetC()[actualSearchIndex].ToString();
                            Uri uri = new Uri(Directory.GetCurrentDirectory() + "\\Assets\\" + panningLandscape.GetItemSetC()[actualSearchIndex] + ".png");
                            BitmapImage imgSource = new BitmapImage(uri);
                            ActualSearchElement.Source = imgSource;
                        }
                        else
                        {
                            actualIteration++;
                            if (countIterations > actualIteration)
                            {
                                actualSearchIndex = 0;
                                SetActualCoordinates(panningLandscape.GetItemSetC()[0]);
                                actualSearchNumber = panningLandscape.GetItemSetC()[0].ToString();
                                Uri uri = new Uri(Directory.GetCurrentDirectory() + "\\Assets\\" + panningLandscape.GetItemSetC()[0] + ".png");
                                BitmapImage imgSource = new BitmapImage(uri);
                                ActualSearchElement.Source = imgSource;
                            }
                            else
                            {
                                dataLogger.FlushAsync();
                                Mouse.OverrideCursor = Cursors.Arrow;
                                ModeEndGrid.Visibility = Visibility.Visible;
                            }
                        }
                        break;
                }
            }
            else if (isExerciseMode)
            {
                actualSearchIndex++;
                if (panningLandscape.GetItemSetExercise().Length > actualSearchIndex)
                {
                    SetActualCoordinates(panningLandscape.GetItemSetExercise()[actualSearchIndex]);
                    actualSearchNumber = panningLandscape.GetItemSetExercise()[actualSearchIndex].ToString();
                    Uri uri = new Uri(Directory.GetCurrentDirectory() + "\\Assets\\" + panningLandscape.GetItemSetExercise()[actualSearchIndex] + ".png");
                    BitmapImage imgSource = new BitmapImage(uri);
                    ActualSearchElement.Source = imgSource;
                }
                else
                {
                    actualIteration++;
                    if (countIterations > actualIteration)
                    {
                        actualSearchIndex = 0;
                        SetActualCoordinates(panningLandscape.GetItemSetExercise()[0]);
                        actualSearchNumber = panningLandscape.GetItemSetExercise()[0].ToString();
                        Uri uri = new Uri(Directory.GetCurrentDirectory() + "\\Assets\\" + panningLandscape.GetItemSetExercise()[0] + ".png");
                        BitmapImage imgSource = new BitmapImage(uri);
                        ActualSearchElement.Source = imgSource;
                    }
                    else
                    {
                        dataLogger.FlushAsync();
                        Mouse.OverrideCursor = Cursors.Arrow;
                        ModeEndGrid.Visibility = Visibility.Visible;
                    }
                }
            }
            else
            {
                actualSearchIndex++;
                if (panningLandscape.GetItemSetDemo().Length > actualSearchIndex)
                {
                    SetActualCoordinates(panningLandscape.GetItemSetDemo()[actualSearchIndex]);
                    actualSearchNumber = panningLandscape.GetItemSetDemo()[actualSearchIndex];
                    Uri uri = new Uri(Directory.GetCurrentDirectory() + "\\Assets\\" + panningLandscape.GetItemSetDemo()[actualSearchIndex] + ".png");
                    BitmapImage imgSource = new BitmapImage(uri);
                    ActualSearchElement.Source = imgSource;
                }
                else
                {
                    actualIteration++;
                    if (countIterations > actualIteration)
                    {
                        actualSearchIndex = 0;
                        SetActualCoordinates(panningLandscape.GetItemSetDemo()[0]);
                        actualSearchNumber = panningLandscape.GetItemSetDemo()[0];
                        Uri uri = new Uri(Directory.GetCurrentDirectory() + "\\Assets\\" + panningLandscape.GetItemSetDemo()[0] + ".png");
                        BitmapImage imgSource = new BitmapImage(uri);
                        ActualSearchElement.Source = imgSource;
                    }
                    else
                    {
                        dataLogger.FlushAsync();
                        actualSearchIndex = 0;
                        recallGridX = 12;
                        recallGridY = 9;
                        NavigationRectangle.Margin = new Thickness(880, 480, 0, 0);
                        Uri uri1 = new Uri(Directory.GetCurrentDirectory() + "\\Assets\\" + panningLandscape.GetItemSetDemoFull()[0] + ".png");
                        BitmapImage imgSource1 = new BitmapImage(uri1);
                        ActualRecallElement.Source = imgSource1;
                        Mouse.OverrideCursor = Cursors.Arrow;
                        RecallGrid.Visibility = Visibility.Visible;
                        MainMenuGrid.Visibility = Visibility.Collapsed;
                    }
                }
            }
            myStoryboard.Begin();
            await System.Threading.Tasks.Task.Delay(TimeSpan.FromMilliseconds(1000));
            HitRectangle.Fill = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
            WaitForAnimationGrid.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// Set the actual searched coordinates for the given element name.
        /// </summary>
        /// <param name="elementName"></param>
        private void SetActualCoordinates(string elementName)
        {
            switch (elementName)
            {
                case "A":
                    actualLeftSearch = Convert.ToInt32((7230) - (resolutionX / 2) + 90);
                    actualTopSearch = Convert.ToInt32((3240) - (resolutionY / 2) + 90);
                    break;
                case "B":
                    actualLeftSearch = Convert.ToInt32((1950) - (resolutionX / 2) + 90);
                    actualTopSearch = Convert.ToInt32((1800) - (resolutionY / 2) + 90);
                    break;
            }
        }

        /// <summary>
        /// Set the actual searched coordinates for the given element number.
        /// </summary>
        /// <param name="elementNumber"></param>
        private void SetActualCoordinates(int elementNumber)
        {
            actualLeftSearch = panningLandscape.GetElementLeftSearch(elementNumber);
            actualTopSearch = panningLandscape.GetElementTopSearch(elementNumber);
        }

        /// <summary>
        /// Will be called when the found item sound is done.
        /// </summary>
        /// <param name="sender">Object that triggers the method</param>
        /// <param name="e">Event arguments</param>
        private void FoundSound_MediaEnded(object sender, RoutedEventArgs e)
        {
            FoundSound.Stop();
        }

        public enum ItemSet
        {
            A,
            B,
            C
        };
    }
}
