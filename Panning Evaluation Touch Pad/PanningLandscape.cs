using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;

namespace Panning_Evaluation_Touch_Pad
{
    /// <summary>
    /// Provides functions, variables and hard coded information of the panning landscape.
    /// </summary>
    class PanningLandscape
    {
        private MainWindow mainWindow; // Referred to the MainWindow class of the program
        private int[] itemSetA = new int[] { 37, 35, 48, 13, 26, 40, 5, 32 }; // IDs of the searched elements of item set A
        private int[] itemSetAFull = new int[] { 37, 35, 48, 13, 26, 40, 5, 32, 9, 11, 16, 30, 33, 42, 49, 50, 66, 72 }; // IDs of all item set A elements (for recall)
        private int[] itemSetB = new int[] { 17, 23, 3, 2, 46, 34, 4, 45 }; // IDs of the searched elements of item set B
        private int[] itemSetBFull = new int[] { 17, 23, 3, 2, 46, 34, 4, 45, 6, 8, 19, 22, 27, 39, 43, 52, 54, 68 }; // IDs of all item set B elements (for recall)
        private int[] itemSetC = new int[] { 12, 51, 7, 21, 28, 36, 38, 14 }; // IDs of the searched elements of item set C
        private int[] itemSetCFull = new int[] { 12, 51, 7, 21, 28, 36, 38, 14, 1, 10, 15, 20, 24, 31, 44, 47, 55, 69 }; // IDs of all item set C elements (for recall)
        private string[] itemSetDemo = new string[] { "A", "B" }; // IDs of the searched elements of the demo item set
        private string[] itemSetDemoFull = new string[] { "A", "B" }; // IDs of all demo item set elements (for recall)
        private int[] itemSetExercise = new int[] { 71, 59, 25, 41 }; // alternative: 73, 60, 61, 29 // IDs of the searched elements of the exercise item set
        private double startLeft = 3840; // Start position on the panning landscape from the left
        private double startTop = 2160; // Start position on the panning landscape from the top

        /// <summary>
        /// Constructor of PanningLandscape
        /// </summary>
        public PanningLandscape()
        {
            mainWindow = (MainWindow)Application.Current.MainWindow;
        }

        /// <summary>
        /// Returns the position of an element in the panning landscape from the left.
        /// </summary>
        /// <param name="elementNumber">Element ID</param>
        /// <returns>Position of the element in the panning landcape from left</returns>
        public int GetElementLeftSearch(int elementNumber)
        {
            switch (elementNumber)
            {
                case 1:
                    return Convert.ToInt32((4350) - (mainWindow.resolutionX / 2) + 90);
                case 2:
                    return Convert.ToInt32((3390) - (mainWindow.resolutionX / 2) + 90);
                case 3:
                    return Convert.ToInt32((6270) - (mainWindow.resolutionX / 2) + 90);                    
                case 4:
                    return Convert.ToInt32((3390) - (mainWindow.resolutionX / 2) + 90);                    
                case 5:
                    return Convert.ToInt32((7230) - (mainWindow.resolutionX / 2) + 90);                    
                case 6:
                    return Convert.ToInt32((5790) - (mainWindow.resolutionX / 2) + 90);                    
                case 7:
                    return Convert.ToInt32((6750) - (mainWindow.resolutionX / 2) + 90);                   
                case 8:
                    return Convert.ToInt32((2910) - (mainWindow.resolutionX / 2) + 90);                    
                case 9:
                    return Convert.ToInt32((2430) - (mainWindow.resolutionX / 2) + 90);                    
                case 10:
                    return Convert.ToInt32((5790) - (mainWindow.resolutionX / 2) + 90);                    
                case 11:
                    return Convert.ToInt32((5790) - (mainWindow.resolutionX / 2) + 90);                    
                case 12:
                    return Convert.ToInt32((3390) - (mainWindow.resolutionX / 2) + 90);                   
                case 13:
                    return Convert.ToInt32((5310) - (mainWindow.resolutionX / 2) + 90);                    
                case 14:
                    return Convert.ToInt32((6270) - (mainWindow.resolutionX / 2) + 90);                    
                case 15:
                    return Convert.ToInt32((1950) - (mainWindow.resolutionX / 2) + 90);                   
                case 16:
                    return Convert.ToInt32((7230) - (mainWindow.resolutionX / 2) + 90);                   
                case 17:
                    return Convert.ToInt32((5310) - (mainWindow.resolutionX / 2) + 90);                   
                case 18:
                    return Convert.ToInt32((6750) - (mainWindow.resolutionX / 2) + 90);                    
                case 19:
                    return Convert.ToInt32((4350) - (mainWindow.resolutionX / 2) + 90);                    
                case 20:
                    return Convert.ToInt32((6270) - (mainWindow.resolutionX / 2) + 90);                    
                case 21:
                    return Convert.ToInt32((4830) - (mainWindow.resolutionX / 2) + 90);                    
                case 22:
                    return Convert.ToInt32((2430) - (mainWindow.resolutionX / 2) + 90);                    
                case 23:
                    return Convert.ToInt32((1950) - (mainWindow.resolutionX / 2) + 90);                    
                case 24:
                    return Convert.ToInt32((7230) - (mainWindow.resolutionX / 2) + 90);                    
                case 25:
                    return Convert.ToInt32((6270) - (mainWindow.resolutionX / 2) + 90);                    
                case 26:
                    return Convert.ToInt32((6750) - (mainWindow.resolutionX / 2) + 90);                    
                case 27:
                    return Convert.ToInt32((1950) - (mainWindow.resolutionX / 2) + 90);                    
                case 28:
                    return Convert.ToInt32((1950) - (mainWindow.resolutionX / 2) + 90);                    
                case 29:
                    return Convert.ToInt32((2430) - (mainWindow.resolutionX / 2) + 90);                    
                case 30:
                    return Convert.ToInt32((6270) - (mainWindow.resolutionX / 2) + 90);                    
                case 31:
                    return Convert.ToInt32((2430) - (mainWindow.resolutionX / 2) + 90);                    
                case 32:
                    return Convert.ToInt32((3390) - (mainWindow.resolutionX / 2) + 90);                    
                case 33:
                    return Convert.ToInt32((3870) - (mainWindow.resolutionX / 2) + 90);                   
                case 34:
                    return Convert.ToInt32((4830) - (mainWindow.resolutionX / 2) + 90);                    
                case 35:
                    return Convert.ToInt32((1950) - (mainWindow.resolutionX / 2) + 90);                  
                case 36:
                    return Convert.ToInt32((2910) - (mainWindow.resolutionX / 2) + 90);                    
                case 37:
                    return Convert.ToInt32((6270) - (mainWindow.resolutionX / 2) + 90);                    
                case 38:
                    return Convert.ToInt32((5310) - (mainWindow.resolutionX / 2) + 90);                    
                case 39:
                    return Convert.ToInt32((7230) - (mainWindow.resolutionX / 2) + 90);                    
                case 40:
                    return Convert.ToInt32((2910) - (mainWindow.resolutionX / 2) + 90);                    
                case 41:
                    return Convert.ToInt32((3870) - (mainWindow.resolutionX / 2) + 90);                    
                case 42:
                    return Convert.ToInt32((4350) - (mainWindow.resolutionX / 2) + 90);                    
                case 43:
                    return Convert.ToInt32((2910) - (mainWindow.resolutionX / 2) + 90);                    
                case 44:
                    return Convert.ToInt32((3870) - (mainWindow.resolutionX / 2) + 90);                   
                case 45:
                    return Convert.ToInt32((1950) - (mainWindow.resolutionX / 2) + 90);                   
                case 46:
                    return Convert.ToInt32((6750) - (mainWindow.resolutionX / 2) + 90);                    
                case 47:
                    return Convert.ToInt32((6750) - (mainWindow.resolutionX / 2) + 90);                   
                case 48:
                    return Convert.ToInt32((2910) - (mainWindow.resolutionX / 2) + 90);                   
                case 49:
                    return Convert.ToInt32((4830) - (mainWindow.resolutionX / 2) + 90);                    
                case 50:
                    return Convert.ToInt32((1950) - (mainWindow.resolutionX / 2) + 90);                    
                case 51:
                    return Convert.ToInt32((1950) - (mainWindow.resolutionX / 2) + 90);                    
                case 52:
                    return Convert.ToInt32((6270) - (mainWindow.resolutionX / 2) + 90);                    
                case 53:
                    return Convert.ToInt32((1950) - (mainWindow.resolutionX / 2) + 90);                    
                case 54:
                    return Convert.ToInt32((6750) - (mainWindow.resolutionX / 2) + 90);                   
                case 55:
                    return Convert.ToInt32((7230) - (mainWindow.resolutionX / 2) + 90);                    
                case 57:
                    return Convert.ToInt32((1950) - (mainWindow.resolutionX / 2) + 90);                   
                case 58:
                    return Convert.ToInt32((7230) - (mainWindow.resolutionX / 2) + 90);                    
                case 59:
                    return Convert.ToInt32((4350) - (mainWindow.resolutionX / 2) + 90);                   
                case 60:
                    return Convert.ToInt32((6270) - (mainWindow.resolutionX / 2) + 90);                    
                case 61:
                    return Convert.ToInt32((6750) - (mainWindow.resolutionX / 2) + 90);                    
                case 62:
                    return Convert.ToInt32((5310) - (mainWindow.resolutionX / 2) + 90);                    
                case 66:
                    return Convert.ToInt32((6750) - (mainWindow.resolutionX / 2) + 90);                    
                case 67:
                    return Convert.ToInt32((2910) - (mainWindow.resolutionX / 2) + 90);                    
                case 68:
                    return Convert.ToInt32((7230) - (mainWindow.resolutionX / 2) + 90);                    
                case 69:
                    return Convert.ToInt32((2910) - (mainWindow.resolutionX / 2) + 90);                    
                case 70:
                    return Convert.ToInt32((7230) - (mainWindow.resolutionX / 2) + 90);                   
                case 71:
                    return Convert.ToInt32((5790) - (mainWindow.resolutionX / 2) + 90);                   
                case 72:
                    return Convert.ToInt32((1950) - (mainWindow.resolutionX / 2) + 90);                    
                case 73:
                    return Convert.ToInt32((2910) - (mainWindow.resolutionX / 2) + 90);                    
                case 74:
                    return Convert.ToInt32((4830) - (mainWindow.resolutionX / 2) + 90);                    
                case 75:
                    return Convert.ToInt32((1950) - (mainWindow.resolutionX / 2) + 90);                    
                case 76:
                    return Convert.ToInt32((2910) - (mainWindow.resolutionX / 2) + 90);                    
                default:
                    return 2160;
            }
        }

        /// <summary>
        /// Returns the position of an element in the panning landscape from the top.
        /// </summary>
        /// <param name="elementNumber">Element ID</param>
        /// <returns>Position of the element in the panning landcape from top</returns>
        public int GetElementTopSearch(int elementNumber)
        {
            switch (elementNumber)
            {
                case 1:
                    return Convert.ToInt32((1440) - (mainWindow.resolutionY / 2) + 90);                   
                case 2:
                    return Convert.ToInt32((3960) - (mainWindow.resolutionY / 2) + 90);                    
                case 3:
                    return Convert.ToInt32((2880) - (mainWindow.resolutionY / 2) + 90);                   
                case 4:
                    return Convert.ToInt32((1440) - (mainWindow.resolutionY / 2) + 90);                    
                case 5:
                    return Convert.ToInt32((3240) - (mainWindow.resolutionY / 2) + 90);                   
                case 6:
                    return Convert.ToInt32((3960) - (mainWindow.resolutionY / 2) + 90);                   
                case 7:
                    return Convert.ToInt32((2160) - (mainWindow.resolutionY / 2) + 90);                    
                case 8:
                    return Convert.ToInt32((3240) - (mainWindow.resolutionY / 2) + 90);                    
                case 9:
                    return Convert.ToInt32((2880) - (mainWindow.resolutionY / 2) + 90);                    
                case 10:
                    return Convert.ToInt32((3960) - (mainWindow.resolutionY / 2) + 90);                    
                case 11:
                    return Convert.ToInt32((1440) - (mainWindow.resolutionY / 2) + 90);                    
                case 12:
                    return Convert.ToInt32((1080) - (mainWindow.resolutionY / 2) + 90);                    
                case 13:
                    return Convert.ToInt32((3600) - (mainWindow.resolutionY / 2) + 90);                    
                case 14:
                    return Convert.ToInt32((3240) - (mainWindow.resolutionY / 2) + 90);                    
                case 15:
                    return Convert.ToInt32((3600) - (mainWindow.resolutionY / 2) + 90);                    
                case 16:
                    return Convert.ToInt32((1800) - (mainWindow.resolutionY / 2) + 90);                   
                case 17:
                    return Convert.ToInt32((1080) - (mainWindow.resolutionY / 2) + 90);                    
                case 18:
                    return Convert.ToInt32((1080) - (mainWindow.resolutionY / 2) + 90);                    
                case 19:
                    return Convert.ToInt32((1440) - (mainWindow.resolutionY / 2) + 90);
                case 20:
                    return Convert.ToInt32((1080) - (mainWindow.resolutionY / 2) + 90);                    
                case 21:
                    return Convert.ToInt32((3600) - (mainWindow.resolutionY / 2) + 90);                    
                case 22:
                    return Convert.ToInt32((1080) - (mainWindow.resolutionY / 2) + 90);                    
                case 23:
                    return Convert.ToInt32((2160) - (mainWindow.resolutionY / 2) + 90);                    
                case 24:
                    return Convert.ToInt32((3240) - (mainWindow.resolutionY / 2) + 90);                    
                case 25:
                    return Convert.ToInt32((2880) - (mainWindow.resolutionY / 2) + 90);                    
                case 26:
                    return Convert.ToInt32((1080) - (mainWindow.resolutionY / 2) + 90);                    
                case 27:
                    return Convert.ToInt32((2880) - (mainWindow.resolutionY / 2) + 90);                    
                case 28:
                    return Convert.ToInt32((1440) - (mainWindow.resolutionY / 2) + 90);                    
                case 29:
                    return Convert.ToInt32((2160) - (mainWindow.resolutionY / 2) + 90);                    
                case 30:
                    return Convert.ToInt32((2880) - (mainWindow.resolutionY / 2) + 90);                    
                case 31:
                    return Convert.ToInt32((2160) - (mainWindow.resolutionY / 2) + 90);                    
                case 32:
                    return Convert.ToInt32((3600) - (mainWindow.resolutionY / 2) + 90);                    
                case 33:
                    return Convert.ToInt32((1440) - (mainWindow.resolutionY / 2) + 90);                   
                case 34:
                    return Convert.ToInt32((3600) - (mainWindow.resolutionY / 2) + 90);                    
                case 35:
                    return Convert.ToInt32((3600) - (mainWindow.resolutionY / 2) + 90);                    
                case 36:
                    return Convert.ToInt32((3960) - (mainWindow.resolutionY / 2) + 90);
                case 37:
                    return Convert.ToInt32((2160) - (mainWindow.resolutionY / 2) + 90);
                case 38:
                    return Convert.ToInt32((1440) - (mainWindow.resolutionY / 2) + 90);
                case 39:
                    return Convert.ToInt32((2160) - (mainWindow.resolutionY / 2) + 90);
                case 40:
                    return Convert.ToInt32((2160) - (mainWindow.resolutionY / 2) + 90);
                case 41:
                    return Convert.ToInt32((1440) - (mainWindow.resolutionY / 2) + 90);
                case 42:
                    return Convert.ToInt32((3960) - (mainWindow.resolutionY / 2) + 90);
                case 43:
                    return Convert.ToInt32((2160) - (mainWindow.resolutionY / 2) + 90);
                case 44:
                    return Convert.ToInt32((3600) - (mainWindow.resolutionY / 2) + 90);
                case 45:
                    return Convert.ToInt32((3600) - (mainWindow.resolutionY / 2) + 90);
                case 46:
                    return Convert.ToInt32((1440) - (mainWindow.resolutionY / 2) + 90);
                case 47:
                    return Convert.ToInt32((3960) - (mainWindow.resolutionY / 2) + 90);
                case 48:
                    return Convert.ToInt32((1080) - (mainWindow.resolutionY / 2) + 90);
                case 49:
                    return Convert.ToInt32((1080) - (mainWindow.resolutionY / 2) + 90);
                case 50:
                    return Convert.ToInt32((2160) - (mainWindow.resolutionY / 2) + 90);
                case 51:
                    return Convert.ToInt32((2880) - (mainWindow.resolutionY / 2) + 90);
                case 52:
                    return Convert.ToInt32((2160) - (mainWindow.resolutionY / 2) + 90);
                case 53:
                    return Convert.ToInt32((2880) - (mainWindow.resolutionY / 2) + 90);
                case 54:
                    return Convert.ToInt32((3960) - (mainWindow.resolutionY / 2) + 90);
                case 55:
                    return Convert.ToInt32((1440) - (mainWindow.resolutionY / 2) + 90);
                case 57:
                    return Convert.ToInt32((3600) - (mainWindow.resolutionY / 2) + 90);
                case 58:
                    return Convert.ToInt32((2880) - (mainWindow.resolutionY / 2) + 90);
                case 59:
                    return Convert.ToInt32((3600) - (mainWindow.resolutionY / 2) + 90);
                case 60:
                    return Convert.ToInt32((1800) - (mainWindow.resolutionY / 2) + 90);
                case 61:
                    return Convert.ToInt32((3600) - (mainWindow.resolutionY / 2) + 90);
                case 62:
                    return Convert.ToInt32((3960) - (mainWindow.resolutionY / 2) + 90);
                case 66:
                    return Convert.ToInt32((3960) - (mainWindow.resolutionY / 2) + 90);
                case 67:
                    return Convert.ToInt32((1080) - (mainWindow.resolutionY / 2) + 90);
                case 68:
                    return Convert.ToInt32((3240) - (mainWindow.resolutionY / 2) + 90);
                case 69:
                    return Convert.ToInt32((3240) - (mainWindow.resolutionY / 2) + 90);
                case 70:
                    return Convert.ToInt32((2160) - (mainWindow.resolutionY / 2) + 90);
                case 71:
                    return Convert.ToInt32((1080) - (mainWindow.resolutionY / 2) + 90);
                case 72:
                    return Convert.ToInt32((1440) - (mainWindow.resolutionY / 2) + 90);
                case 73:
                    return Convert.ToInt32((3960) - (mainWindow.resolutionY / 2) + 90);
                case 74:
                    return Convert.ToInt32((1440) - (mainWindow.resolutionY / 2) + 90);
                case 75:
                    return Convert.ToInt32((1440) - (mainWindow.resolutionY / 2) + 90);
                case 76:
                    return Convert.ToInt32((3240) - (mainWindow.resolutionY / 2) + 90);
                default:
                    return 3840;
            }
        }

        /// <summary>
        /// Returns the IDs of the searched elements of item set A.
        /// </summary>
        /// <returns>Searched item set A IDs</returns>
        public int[] GetItemSetA()
        {
            return itemSetA;
        }

        /// <summary>
        /// Returns the IDs of all elements of item set A.
        /// </summary>
        /// <returns>All item set A IDs</returns>
        public int[] GetItemSetAFull()
        {
            return itemSetAFull;
        }

        /// <summary>
        /// Returns the IDs of the searched elements of item set B.
        /// </summary>
        /// <returns>Searched item set B IDs</returns>
        public int[] GetItemSetB()
        {
            return itemSetB;
        }

        /// <summary>
        /// Returns the IDs of all elements of item set B.
        /// </summary>
        /// <returns>All item set B IDs</returns>
        public int[] GetItemSetBFull()
        {
            return itemSetBFull;
        }

        /// <summary>
        /// Returns the IDs of the searched elements of item set C.
        /// </summary>
        /// <returns>Searched item set C IDs</returns>
        public int[] GetItemSetC()
        {
            return itemSetC;
        }

        /// <summary>
        /// Returns the IDs of all elements of item set C.
        /// </summary>
        /// <returns>All item set C IDs</returns>
        public int[] GetItemSetCFull()
        {
            return itemSetCFull;
        }

        /// <summary>
        /// Returns the IDs of the searched elements of the demo item set.
        /// </summary>
        /// <returns>Searched demo item set IDs</returns>
        public string[] GetItemSetDemo()
        {
            return itemSetDemo;
        }

        /// <summary>
        /// Returns the IDs of all elements of the demo item set.
        /// </summary>
        /// <returns>All demo item set IDs</returns>
        public string[] GetItemSetDemoFull()
        {
            return itemSetDemoFull;
        }

        /// <summary>
        /// Returns the IDs of the searched elements of the exercise item set.
        /// </summary>
        /// <returns>Searched exercise item set IDs</returns>
        public int[] GetItemSetExercise()
        {
            return itemSetExercise;
        }

        /// <summary>
        /// Returns the start position on the panning landscape from the left.
        /// </summary>
        /// <returns>Start position from left</returns>
        public double GetStartLeft()
        {
            return startLeft;
        }

        /// <summary>
        /// Returns the start position on the panning landscape from the top.
        /// </summary>
        /// <returns>Start position from top</returns>
        public double GetStartTop()
        {
            return startTop;
        }

        /// <summary>
        /// Makes the demo item set visible and all other itemsets collapsed (invisible).
        /// </summary>
        public void SetDemoUI()
        {
            //Item Set Demo
            mainWindow.Image_Apng_13_23.Visibility = Visibility.Visible;
            mainWindow.Image_Bpng_05_01.Visibility = Visibility.Visible;
            mainWindow.Image_Cpng_11_01.Visibility = Visibility.Visible;
            mainWindow.Image_Dpng_03_19.Visibility = Visibility.Visible;
            mainWindow.Image_Epng_17_13.Visibility = Visibility.Visible;
            mainWindow.Image_Fpng_07_21.Visibility = Visibility.Visible;
            mainWindow.Image_Gpng_15_09.Visibility = Visibility.Visible;
            mainWindow.Image_Hpng_03_05.Visibility = Visibility.Visible;
            mainWindow.Image_Ipng_15_19.Visibility = Visibility.Visible;
            mainWindow.Image_Jpng_01_11.Visibility = Visibility.Visible;
            mainWindow.Image_Kpng_17_05.Visibility = Visibility.Visible;
            mainWindow.Image_Lpng_03_15.Visibility = Visibility.Visible;

            //Item Set Übung
            mainWindow.Image_67png_01_05.Visibility = Visibility.Collapsed;
            mainWindow.Image_71png_01_17.Visibility = Visibility.Collapsed;
            mainWindow.Image_18png_01_21.Visibility = Visibility.Collapsed;
            mainWindow.Image_75png_03_01.Visibility = Visibility.Collapsed;
            mainWindow.Image_41png_03_09.Visibility = Visibility.Collapsed;
            mainWindow.Image_74png_03_13.Visibility = Visibility.Collapsed;
            mainWindow.Image_60png_05_19.Visibility = Visibility.Collapsed;
            mainWindow.Image_29png_07_03.Visibility = Visibility.Collapsed;
            mainWindow.Image_70png_07_23.Visibility = Visibility.Collapsed;
            mainWindow.Image_53png_11_01.Visibility = Visibility.Collapsed;
            mainWindow.Image_25png_11_19.Visibility = Visibility.Collapsed;
            mainWindow.Image_58png_11_23.Visibility = Visibility.Collapsed;
            mainWindow.Image_76png_13_05.Visibility = Visibility.Collapsed;
            mainWindow.Image_57png_15_01.Visibility = Visibility.Collapsed;
            mainWindow.Image_59png_15_11.Visibility = Visibility.Collapsed;
            mainWindow.Image_61png_15_21.Visibility = Visibility.Collapsed;
            mainWindow.Image_73png_17_05.Visibility = Visibility.Collapsed;
            mainWindow.Image_62png_17_15.Visibility = Visibility.Collapsed;

            //Item Set A
            mainWindow.Image_48png_01_05.Visibility = Visibility.Collapsed;
            mainWindow.Image_49png_01_13.Visibility = Visibility.Collapsed;
            mainWindow.Image_26png_01_21.Visibility = Visibility.Collapsed;
            mainWindow.Image_72png_03_01.Visibility = Visibility.Collapsed;
            mainWindow.Image_33png_03_09.Visibility = Visibility.Collapsed;
            mainWindow.Image_11png_03_17.Visibility = Visibility.Collapsed;
            mainWindow.Image_16png_05_23.Visibility = Visibility.Collapsed;
            mainWindow.Image_50png_07_01.Visibility = Visibility.Collapsed;
            mainWindow.Image_40png_07_05.Visibility = Visibility.Collapsed;
            mainWindow.Image_37png_07_19.Visibility = Visibility.Collapsed;
            mainWindow.Image_9png_11_03.Visibility = Visibility.Collapsed;
            mainWindow.Image_30png_11_19.Visibility = Visibility.Collapsed;
            mainWindow.Image_5png_13_23.Visibility = Visibility.Collapsed;
            mainWindow.Image_35png_15_01.Visibility = Visibility.Collapsed;
            mainWindow.Image_32png_15_07.Visibility = Visibility.Collapsed;
            mainWindow.Image_13png_15_15.Visibility = Visibility.Collapsed;
            mainWindow.Image_42png_17_11.Visibility = Visibility.Collapsed;
            mainWindow.Image_66png_17_21.Visibility = Visibility.Collapsed;

            //Item Set B
            mainWindow.Image_22png_01_03.Visibility = Visibility.Collapsed;
            mainWindow.Image_17png_01_15.Visibility = Visibility.Collapsed;
            mainWindow.Image_4png_03_07.Visibility = Visibility.Collapsed;
            mainWindow.Image_19png_03_11.Visibility = Visibility.Collapsed;
            mainWindow.Image_46png_03_21.Visibility = Visibility.Collapsed;
            mainWindow.Image_23png_07_01.Visibility = Visibility.Collapsed;
            mainWindow.Image_43png_07_05.Visibility = Visibility.Collapsed;
            mainWindow.Image_52png_07_19.Visibility = Visibility.Collapsed;
            mainWindow.Image_39png_07_23.Visibility = Visibility.Collapsed;
            mainWindow.Image_27png_11_01.Visibility = Visibility.Collapsed;
            mainWindow.Image_3png_11_19.Visibility = Visibility.Collapsed;
            mainWindow.Image_8png_13_05.Visibility = Visibility.Collapsed;
            mainWindow.Image_68png_13_23.Visibility = Visibility.Collapsed;
            mainWindow.Image_45png_15_01.Visibility = Visibility.Collapsed;
            mainWindow.Image_34png_15_13.Visibility = Visibility.Collapsed;
            mainWindow.Image_2png_17_07.Visibility = Visibility.Collapsed;
            mainWindow.Image_6png_17_17.Visibility = Visibility.Collapsed;
            mainWindow.Image_54png_17_21.Visibility = Visibility.Collapsed;

            //Item Set C
            mainWindow.Image_12png_01_07.Visibility = Visibility.Collapsed;
            mainWindow.Image_20png_01_19.Visibility = Visibility.Collapsed;
            mainWindow.Image_28png_03_01.Visibility = Visibility.Collapsed;
            mainWindow.Image_1png_03_11.Visibility = Visibility.Collapsed;
            mainWindow.Image_38png_03_15.Visibility = Visibility.Collapsed;
            mainWindow.Image_55png_03_23.Visibility = Visibility.Collapsed;
            mainWindow.Image_31png_07_03.Visibility = Visibility.Collapsed;
            mainWindow.Image_7png_07_21.Visibility = Visibility.Collapsed;
            mainWindow.Image_51png_11_01.Visibility = Visibility.Collapsed;
            mainWindow.Image_69png_13_05.Visibility = Visibility.Collapsed;
            mainWindow.Image_14png_13_19.Visibility = Visibility.Collapsed;
            mainWindow.Image_24png_13_23.Visibility = Visibility.Collapsed;
            mainWindow.Image_15png_15_01.Visibility = Visibility.Collapsed;
            mainWindow.Image_44png_15_09.Visibility = Visibility.Collapsed;
            mainWindow.Image_21png_15_13.Visibility = Visibility.Collapsed;
            mainWindow.Image_36png_17_05.Visibility = Visibility.Collapsed;
            mainWindow.Image_10png_17_17.Visibility = Visibility.Collapsed;
            mainWindow.Image_47png_17_21.Visibility = Visibility.Collapsed;

            mainWindow.Rectangle_01_03.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_01_05.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_01_07.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_01_11.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_01_13.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_01_15.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_01_17.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_01_19.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_01_21.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_03_01.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_03_05.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_03_07.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_03_09.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_03_11.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_03_13.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_03_15.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_03_17.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_03_19.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_03_21.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_03_23.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_05_01.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_05_19.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_05_23.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_07_01.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_07_03.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_07_05.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_07_19.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_07_21.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_07_23.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_11_01.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_11_03.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_11_19.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_11_23.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_13_05.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_13_19.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_13_23.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_15_01.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_15_07.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_15_09.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_15_11.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_15_13.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_15_15.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_15_19.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_15_21.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_17_05.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_17_07.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_17_11.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_17_13.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_17_15.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_17_17.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_17_21.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        }

        /// <summary>
        /// Makes the exercise item set visible and all other itemsets collapsed (invisible).
        /// </summary>
        public void SetExerciseUI()
        {
            //Item Set Demo
            mainWindow.Image_Apng_13_23.Visibility = Visibility.Collapsed;
            mainWindow.Image_Bpng_05_01.Visibility = Visibility.Collapsed;
            mainWindow.Image_Cpng_11_01.Visibility = Visibility.Collapsed;
            mainWindow.Image_Dpng_03_19.Visibility = Visibility.Collapsed;
            mainWindow.Image_Epng_17_13.Visibility = Visibility.Collapsed;
            mainWindow.Image_Fpng_07_21.Visibility = Visibility.Collapsed;
            mainWindow.Image_Gpng_15_09.Visibility = Visibility.Collapsed;
            mainWindow.Image_Hpng_03_05.Visibility = Visibility.Collapsed;
            mainWindow.Image_Ipng_15_19.Visibility = Visibility.Collapsed;
            mainWindow.Image_Jpng_01_11.Visibility = Visibility.Collapsed;
            mainWindow.Image_Kpng_17_05.Visibility = Visibility.Collapsed;
            mainWindow.Image_Lpng_03_15.Visibility = Visibility.Collapsed;

            //Item Set Übung
            mainWindow.Image_67png_01_05.Visibility = Visibility.Visible;
            mainWindow.Image_71png_01_17.Visibility = Visibility.Visible;
            mainWindow.Image_18png_01_21.Visibility = Visibility.Visible;
            mainWindow.Image_75png_03_01.Visibility = Visibility.Visible;
            mainWindow.Image_41png_03_09.Visibility = Visibility.Visible;
            mainWindow.Image_74png_03_13.Visibility = Visibility.Visible;
            mainWindow.Image_60png_05_19.Visibility = Visibility.Visible;
            mainWindow.Image_29png_07_03.Visibility = Visibility.Visible;
            mainWindow.Image_70png_07_23.Visibility = Visibility.Visible;
            mainWindow.Image_53png_11_01.Visibility = Visibility.Visible;
            mainWindow.Image_25png_11_19.Visibility = Visibility.Visible;
            mainWindow.Image_58png_11_23.Visibility = Visibility.Visible;
            mainWindow.Image_76png_13_05.Visibility = Visibility.Visible;
            mainWindow.Image_57png_15_01.Visibility = Visibility.Visible;
            mainWindow.Image_59png_15_11.Visibility = Visibility.Visible;
            mainWindow.Image_61png_15_21.Visibility = Visibility.Visible;
            mainWindow.Image_73png_17_05.Visibility = Visibility.Visible;
            mainWindow.Image_62png_17_15.Visibility = Visibility.Visible;

            //Item Set A
            mainWindow.Image_48png_01_05.Visibility = Visibility.Collapsed;
            mainWindow.Image_49png_01_13.Visibility = Visibility.Collapsed;
            mainWindow.Image_26png_01_21.Visibility = Visibility.Collapsed;
            mainWindow.Image_72png_03_01.Visibility = Visibility.Collapsed;
            mainWindow.Image_33png_03_09.Visibility = Visibility.Collapsed;
            mainWindow.Image_11png_03_17.Visibility = Visibility.Collapsed;
            mainWindow.Image_16png_05_23.Visibility = Visibility.Collapsed;
            mainWindow.Image_50png_07_01.Visibility = Visibility.Collapsed;
            mainWindow.Image_40png_07_05.Visibility = Visibility.Collapsed;
            mainWindow.Image_37png_07_19.Visibility = Visibility.Collapsed;
            mainWindow.Image_9png_11_03.Visibility = Visibility.Collapsed;
            mainWindow.Image_30png_11_19.Visibility = Visibility.Collapsed;
            mainWindow.Image_5png_13_23.Visibility = Visibility.Collapsed;
            mainWindow.Image_35png_15_01.Visibility = Visibility.Collapsed;
            mainWindow.Image_32png_15_07.Visibility = Visibility.Collapsed;
            mainWindow.Image_13png_15_15.Visibility = Visibility.Collapsed;
            mainWindow.Image_42png_17_11.Visibility = Visibility.Collapsed;
            mainWindow.Image_66png_17_21.Visibility = Visibility.Collapsed;

            //Item Set B
            mainWindow.Image_22png_01_03.Visibility = Visibility.Collapsed;
            mainWindow.Image_17png_01_15.Visibility = Visibility.Collapsed;
            mainWindow.Image_4png_03_07.Visibility = Visibility.Collapsed;
            mainWindow.Image_19png_03_11.Visibility = Visibility.Collapsed;
            mainWindow.Image_46png_03_21.Visibility = Visibility.Collapsed;
            mainWindow.Image_23png_07_01.Visibility = Visibility.Collapsed;
            mainWindow.Image_43png_07_05.Visibility = Visibility.Collapsed;
            mainWindow.Image_52png_07_19.Visibility = Visibility.Collapsed;
            mainWindow.Image_39png_07_23.Visibility = Visibility.Collapsed;
            mainWindow.Image_27png_11_01.Visibility = Visibility.Collapsed;
            mainWindow.Image_3png_11_19.Visibility = Visibility.Collapsed;
            mainWindow.Image_8png_13_05.Visibility = Visibility.Collapsed;
            mainWindow.Image_68png_13_23.Visibility = Visibility.Collapsed;
            mainWindow.Image_45png_15_01.Visibility = Visibility.Collapsed;
            mainWindow.Image_34png_15_13.Visibility = Visibility.Collapsed;
            mainWindow.Image_2png_17_07.Visibility = Visibility.Collapsed;
            mainWindow.Image_6png_17_17.Visibility = Visibility.Collapsed;
            mainWindow.Image_54png_17_21.Visibility = Visibility.Collapsed;

            //Item Set C
            mainWindow.Image_12png_01_07.Visibility = Visibility.Collapsed;
            mainWindow.Image_20png_01_19.Visibility = Visibility.Collapsed;
            mainWindow.Image_28png_03_01.Visibility = Visibility.Collapsed;
            mainWindow.Image_1png_03_11.Visibility = Visibility.Collapsed;
            mainWindow.Image_38png_03_15.Visibility = Visibility.Collapsed;
            mainWindow.Image_55png_03_23.Visibility = Visibility.Collapsed;
            mainWindow.Image_31png_07_03.Visibility = Visibility.Collapsed;
            mainWindow.Image_7png_07_21.Visibility = Visibility.Collapsed;
            mainWindow.Image_51png_11_01.Visibility = Visibility.Collapsed;
            mainWindow.Image_69png_13_05.Visibility = Visibility.Collapsed;
            mainWindow.Image_14png_13_19.Visibility = Visibility.Collapsed;
            mainWindow.Image_24png_13_23.Visibility = Visibility.Collapsed;
            mainWindow.Image_15png_15_01.Visibility = Visibility.Collapsed;
            mainWindow.Image_44png_15_09.Visibility = Visibility.Collapsed;
            mainWindow.Image_21png_15_13.Visibility = Visibility.Collapsed;
            mainWindow.Image_36png_17_05.Visibility = Visibility.Collapsed;
            mainWindow.Image_10png_17_17.Visibility = Visibility.Collapsed;
            mainWindow.Image_47png_17_21.Visibility = Visibility.Collapsed;

            mainWindow.Rectangle_01_03.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_01_05.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_01_07.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_01_11.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_01_13.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_01_15.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_01_17.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_01_19.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_01_21.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_03_01.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_03_05.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_03_07.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_03_09.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_03_11.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_03_13.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_03_15.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_03_17.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_03_19.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_03_21.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_03_23.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_05_01.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_05_19.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_05_23.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_07_01.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_07_03.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_07_05.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_07_19.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_07_21.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_07_23.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_11_01.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_11_03.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_11_19.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_11_23.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_13_05.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_13_19.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_13_23.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_15_01.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_15_07.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_15_09.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_15_11.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_15_13.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_15_15.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_15_19.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_15_21.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_17_05.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_17_07.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_17_11.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_17_13.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_17_15.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_17_17.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_17_21.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
        }

        /// <summary>
        /// Makes item set A visible and all other itemsets collapsed (invisible).
        /// </summary>
        public void SetItemSetAUI()
        {
            //Item Set Demo
            mainWindow.Image_Apng_13_23.Visibility = Visibility.Collapsed;
            mainWindow.Image_Bpng_05_01.Visibility = Visibility.Collapsed;
            mainWindow.Image_Cpng_11_01.Visibility = Visibility.Collapsed;
            mainWindow.Image_Dpng_03_19.Visibility = Visibility.Collapsed;
            mainWindow.Image_Epng_17_13.Visibility = Visibility.Collapsed;
            mainWindow.Image_Fpng_07_21.Visibility = Visibility.Collapsed;
            mainWindow.Image_Gpng_15_09.Visibility = Visibility.Collapsed;
            mainWindow.Image_Hpng_03_05.Visibility = Visibility.Collapsed;
            mainWindow.Image_Ipng_15_19.Visibility = Visibility.Collapsed;
            mainWindow.Image_Jpng_01_11.Visibility = Visibility.Collapsed;
            mainWindow.Image_Kpng_17_05.Visibility = Visibility.Collapsed;
            mainWindow.Image_Lpng_03_15.Visibility = Visibility.Collapsed;

            //Item Set Übung
            mainWindow.Image_67png_01_05.Visibility = Visibility.Collapsed;
            mainWindow.Image_71png_01_17.Visibility = Visibility.Collapsed;
            mainWindow.Image_18png_01_21.Visibility = Visibility.Collapsed;
            mainWindow.Image_75png_03_01.Visibility = Visibility.Collapsed;
            mainWindow.Image_41png_03_09.Visibility = Visibility.Collapsed;
            mainWindow.Image_74png_03_13.Visibility = Visibility.Collapsed;
            mainWindow.Image_60png_05_19.Visibility = Visibility.Collapsed;
            mainWindow.Image_29png_07_03.Visibility = Visibility.Collapsed;
            mainWindow.Image_70png_07_23.Visibility = Visibility.Collapsed;
            mainWindow.Image_53png_11_01.Visibility = Visibility.Collapsed;
            mainWindow.Image_25png_11_19.Visibility = Visibility.Collapsed;
            mainWindow.Image_58png_11_23.Visibility = Visibility.Collapsed;
            mainWindow.Image_76png_13_05.Visibility = Visibility.Collapsed;
            mainWindow.Image_57png_15_01.Visibility = Visibility.Collapsed;
            mainWindow.Image_59png_15_11.Visibility = Visibility.Collapsed;
            mainWindow.Image_61png_15_21.Visibility = Visibility.Collapsed;
            mainWindow.Image_73png_17_05.Visibility = Visibility.Collapsed;
            mainWindow.Image_62png_17_15.Visibility = Visibility.Collapsed;

            //Item Set A
            mainWindow.Image_48png_01_05.Visibility = Visibility.Visible;
            mainWindow.Image_49png_01_13.Visibility = Visibility.Visible;
            mainWindow.Image_26png_01_21.Visibility = Visibility.Visible;
            mainWindow.Image_72png_03_01.Visibility = Visibility.Visible;
            mainWindow.Image_33png_03_09.Visibility = Visibility.Visible;
            mainWindow.Image_11png_03_17.Visibility = Visibility.Visible;
            mainWindow.Image_16png_05_23.Visibility = Visibility.Visible;
            mainWindow.Image_50png_07_01.Visibility = Visibility.Visible;
            mainWindow.Image_40png_07_05.Visibility = Visibility.Visible;
            mainWindow.Image_37png_07_19.Visibility = Visibility.Visible;
            mainWindow.Image_9png_11_03.Visibility = Visibility.Visible;
            mainWindow.Image_30png_11_19.Visibility = Visibility.Visible;
            mainWindow.Image_5png_13_23.Visibility = Visibility.Visible;
            mainWindow.Image_35png_15_01.Visibility = Visibility.Visible;
            mainWindow.Image_32png_15_07.Visibility = Visibility.Visible;
            mainWindow.Image_13png_15_15.Visibility = Visibility.Visible;
            mainWindow.Image_42png_17_11.Visibility = Visibility.Visible;
            mainWindow.Image_66png_17_21.Visibility = Visibility.Visible;

            //Item Set B
            mainWindow.Image_22png_01_03.Visibility = Visibility.Collapsed;
            mainWindow.Image_17png_01_15.Visibility = Visibility.Collapsed;
            mainWindow.Image_4png_03_07.Visibility = Visibility.Collapsed;
            mainWindow.Image_19png_03_11.Visibility = Visibility.Collapsed;
            mainWindow.Image_46png_03_21.Visibility = Visibility.Collapsed;
            mainWindow.Image_23png_07_01.Visibility = Visibility.Collapsed;
            mainWindow.Image_43png_07_05.Visibility = Visibility.Collapsed;
            mainWindow.Image_52png_07_19.Visibility = Visibility.Collapsed;
            mainWindow.Image_39png_07_23.Visibility = Visibility.Collapsed;
            mainWindow.Image_27png_11_01.Visibility = Visibility.Collapsed;
            mainWindow.Image_3png_11_19.Visibility = Visibility.Collapsed;
            mainWindow.Image_8png_13_05.Visibility = Visibility.Collapsed;
            mainWindow.Image_68png_13_23.Visibility = Visibility.Collapsed;
            mainWindow.Image_45png_15_01.Visibility = Visibility.Collapsed;
            mainWindow.Image_34png_15_13.Visibility = Visibility.Collapsed;
            mainWindow.Image_2png_17_07.Visibility = Visibility.Collapsed;
            mainWindow.Image_6png_17_17.Visibility = Visibility.Collapsed;
            mainWindow.Image_54png_17_21.Visibility = Visibility.Collapsed;

            //Item Set C
            mainWindow.Image_12png_01_07.Visibility = Visibility.Collapsed;
            mainWindow.Image_20png_01_19.Visibility = Visibility.Collapsed;
            mainWindow.Image_28png_03_01.Visibility = Visibility.Collapsed;
            mainWindow.Image_1png_03_11.Visibility = Visibility.Collapsed;
            mainWindow.Image_38png_03_15.Visibility = Visibility.Collapsed;
            mainWindow.Image_55png_03_23.Visibility = Visibility.Collapsed;
            mainWindow.Image_31png_07_03.Visibility = Visibility.Collapsed;
            mainWindow.Image_7png_07_21.Visibility = Visibility.Collapsed;
            mainWindow.Image_51png_11_01.Visibility = Visibility.Collapsed;
            mainWindow.Image_69png_13_05.Visibility = Visibility.Collapsed;
            mainWindow.Image_14png_13_19.Visibility = Visibility.Collapsed;
            mainWindow.Image_24png_13_23.Visibility = Visibility.Collapsed;
            mainWindow.Image_15png_15_01.Visibility = Visibility.Collapsed;
            mainWindow.Image_44png_15_09.Visibility = Visibility.Collapsed;
            mainWindow.Image_21png_15_13.Visibility = Visibility.Collapsed;
            mainWindow.Image_36png_17_05.Visibility = Visibility.Collapsed;
            mainWindow.Image_10png_17_17.Visibility = Visibility.Collapsed;
            mainWindow.Image_47png_17_21.Visibility = Visibility.Collapsed;

            mainWindow.Rectangle_01_03.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_01_05.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_01_07.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_01_11.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_01_13.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_01_15.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_01_17.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_01_19.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_01_21.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_03_01.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_03_05.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_03_07.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_03_09.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_03_11.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_03_13.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_03_15.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_03_17.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_03_19.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_03_21.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_03_23.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_05_01.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_05_19.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_05_23.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_07_01.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_07_03.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_07_05.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_07_19.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_07_21.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_07_23.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_11_01.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_11_03.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_11_19.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_11_23.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_13_05.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_13_19.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_13_23.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_15_01.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_15_07.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_15_09.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_15_11.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_15_13.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_15_15.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_15_19.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_15_21.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_17_05.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_17_07.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_17_13.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_17_11.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_17_15.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_17_17.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_17_21.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
        }

        /// <summary>
        /// Makes item set B visible and all other itemsets collapsed (invisible).
        /// </summary>
        public void SetItemSetBUI()
        {
            //Item Set Demo
            mainWindow.Image_Apng_13_23.Visibility = Visibility.Collapsed;
            mainWindow.Image_Bpng_05_01.Visibility = Visibility.Collapsed;
            mainWindow.Image_Cpng_11_01.Visibility = Visibility.Collapsed;
            mainWindow.Image_Dpng_03_19.Visibility = Visibility.Collapsed;
            mainWindow.Image_Epng_17_13.Visibility = Visibility.Collapsed;
            mainWindow.Image_Fpng_07_21.Visibility = Visibility.Collapsed;
            mainWindow.Image_Gpng_15_09.Visibility = Visibility.Collapsed;
            mainWindow.Image_Hpng_03_05.Visibility = Visibility.Collapsed;
            mainWindow.Image_Ipng_15_19.Visibility = Visibility.Collapsed;
            mainWindow.Image_Jpng_01_11.Visibility = Visibility.Collapsed;
            mainWindow.Image_Kpng_17_05.Visibility = Visibility.Collapsed;
            mainWindow.Image_Lpng_03_15.Visibility = Visibility.Collapsed;

            //Item Set Übung
            mainWindow.Image_67png_01_05.Visibility = Visibility.Collapsed;
            mainWindow.Image_71png_01_17.Visibility = Visibility.Collapsed;
            mainWindow.Image_18png_01_21.Visibility = Visibility.Collapsed;
            mainWindow.Image_75png_03_01.Visibility = Visibility.Collapsed;
            mainWindow.Image_41png_03_09.Visibility = Visibility.Collapsed;
            mainWindow.Image_74png_03_13.Visibility = Visibility.Collapsed;
            mainWindow.Image_60png_05_19.Visibility = Visibility.Collapsed;
            mainWindow.Image_29png_07_03.Visibility = Visibility.Collapsed;
            mainWindow.Image_70png_07_23.Visibility = Visibility.Collapsed;
            mainWindow.Image_53png_11_01.Visibility = Visibility.Collapsed;
            mainWindow.Image_25png_11_19.Visibility = Visibility.Collapsed;
            mainWindow.Image_58png_11_23.Visibility = Visibility.Collapsed;
            mainWindow.Image_76png_13_05.Visibility = Visibility.Collapsed;
            mainWindow.Image_57png_15_01.Visibility = Visibility.Collapsed;
            mainWindow.Image_59png_15_11.Visibility = Visibility.Collapsed;
            mainWindow.Image_61png_15_21.Visibility = Visibility.Collapsed;
            mainWindow.Image_73png_17_05.Visibility = Visibility.Collapsed;
            mainWindow.Image_62png_17_15.Visibility = Visibility.Collapsed;

            //Item Set A
            mainWindow.Image_48png_01_05.Visibility = Visibility.Collapsed;
            mainWindow.Image_49png_01_13.Visibility = Visibility.Collapsed;
            mainWindow.Image_26png_01_21.Visibility = Visibility.Collapsed;
            mainWindow.Image_72png_03_01.Visibility = Visibility.Collapsed;
            mainWindow.Image_33png_03_09.Visibility = Visibility.Collapsed;
            mainWindow.Image_11png_03_17.Visibility = Visibility.Collapsed;
            mainWindow.Image_16png_05_23.Visibility = Visibility.Collapsed;
            mainWindow.Image_50png_07_01.Visibility = Visibility.Collapsed;
            mainWindow.Image_40png_07_05.Visibility = Visibility.Collapsed;
            mainWindow.Image_37png_07_19.Visibility = Visibility.Collapsed;
            mainWindow.Image_9png_11_03.Visibility = Visibility.Collapsed;
            mainWindow.Image_30png_11_19.Visibility = Visibility.Collapsed;
            mainWindow.Image_5png_13_23.Visibility = Visibility.Collapsed;
            mainWindow.Image_35png_15_01.Visibility = Visibility.Collapsed;
            mainWindow.Image_32png_15_07.Visibility = Visibility.Collapsed;
            mainWindow.Image_13png_15_15.Visibility = Visibility.Collapsed;
            mainWindow.Image_42png_17_11.Visibility = Visibility.Collapsed;
            mainWindow.Image_66png_17_21.Visibility = Visibility.Collapsed;

            //Item Set B
            mainWindow.Image_22png_01_03.Visibility = Visibility.Visible;
            mainWindow.Image_17png_01_15.Visibility = Visibility.Visible;
            mainWindow.Image_4png_03_07.Visibility = Visibility.Visible;
            mainWindow.Image_19png_03_11.Visibility = Visibility.Visible;
            mainWindow.Image_46png_03_21.Visibility = Visibility.Visible;
            mainWindow.Image_23png_07_01.Visibility = Visibility.Visible;
            mainWindow.Image_43png_07_05.Visibility = Visibility.Visible;
            mainWindow.Image_52png_07_19.Visibility = Visibility.Visible;
            mainWindow.Image_39png_07_23.Visibility = Visibility.Visible;
            mainWindow.Image_27png_11_01.Visibility = Visibility.Visible;
            mainWindow.Image_3png_11_19.Visibility = Visibility.Visible;
            mainWindow.Image_8png_13_05.Visibility = Visibility.Visible;
            mainWindow.Image_68png_13_23.Visibility = Visibility.Visible;
            mainWindow.Image_45png_15_01.Visibility = Visibility.Visible;
            mainWindow.Image_34png_15_13.Visibility = Visibility.Visible;
            mainWindow.Image_2png_17_07.Visibility = Visibility.Visible;
            mainWindow.Image_6png_17_17.Visibility = Visibility.Visible;
            mainWindow.Image_54png_17_21.Visibility = Visibility.Visible;

            //Item Set C
            mainWindow.Image_12png_01_07.Visibility = Visibility.Collapsed;
            mainWindow.Image_20png_01_19.Visibility = Visibility.Collapsed;
            mainWindow.Image_28png_03_01.Visibility = Visibility.Collapsed;
            mainWindow.Image_1png_03_11.Visibility = Visibility.Collapsed;
            mainWindow.Image_38png_03_15.Visibility = Visibility.Collapsed;
            mainWindow.Image_55png_03_23.Visibility = Visibility.Collapsed;
            mainWindow.Image_31png_07_03.Visibility = Visibility.Collapsed;
            mainWindow.Image_7png_07_21.Visibility = Visibility.Collapsed;
            mainWindow.Image_51png_11_01.Visibility = Visibility.Collapsed;
            mainWindow.Image_69png_13_05.Visibility = Visibility.Collapsed;
            mainWindow.Image_14png_13_19.Visibility = Visibility.Collapsed;
            mainWindow.Image_24png_13_23.Visibility = Visibility.Collapsed;
            mainWindow.Image_15png_15_01.Visibility = Visibility.Collapsed;
            mainWindow.Image_44png_15_09.Visibility = Visibility.Collapsed;
            mainWindow.Image_21png_15_13.Visibility = Visibility.Collapsed;
            mainWindow.Image_36png_17_05.Visibility = Visibility.Collapsed;
            mainWindow.Image_10png_17_17.Visibility = Visibility.Collapsed;
            mainWindow.Image_47png_17_21.Visibility = Visibility.Collapsed;

            mainWindow.Rectangle_01_03.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_01_05.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_01_07.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_01_11.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_01_13.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_01_15.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_01_17.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_01_19.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_01_21.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_03_01.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_03_05.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_03_07.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_03_09.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_03_11.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_03_13.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_03_15.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_03_17.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_03_19.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_03_21.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_03_23.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_05_01.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_05_19.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_05_23.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_07_01.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_07_03.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_07_05.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_07_19.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_07_21.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_07_23.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_11_01.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_11_03.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_11_19.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_11_23.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_13_05.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_13_19.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_13_23.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_15_01.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_15_07.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_15_09.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_15_11.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_15_13.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_15_15.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_15_19.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_15_21.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_17_05.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_17_07.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_17_11.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_17_13.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_17_15.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_17_17.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_17_21.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
        }

        /// <summary>
        /// Makes item set C visible and all other itemsets collapsed (invisible).
        /// </summary>
        public void SetItemSetCUI()
        {
            //Item Set Demo
            mainWindow.Image_Apng_13_23.Visibility = Visibility.Collapsed;
            mainWindow.Image_Bpng_05_01.Visibility = Visibility.Collapsed;
            mainWindow.Image_Cpng_11_01.Visibility = Visibility.Collapsed;
            mainWindow.Image_Dpng_03_19.Visibility = Visibility.Collapsed;
            mainWindow.Image_Epng_17_13.Visibility = Visibility.Collapsed;
            mainWindow.Image_Fpng_07_21.Visibility = Visibility.Collapsed;
            mainWindow.Image_Gpng_15_09.Visibility = Visibility.Collapsed;
            mainWindow.Image_Hpng_03_05.Visibility = Visibility.Collapsed;
            mainWindow.Image_Ipng_15_19.Visibility = Visibility.Collapsed;
            mainWindow.Image_Jpng_01_11.Visibility = Visibility.Collapsed;
            mainWindow.Image_Kpng_17_05.Visibility = Visibility.Collapsed;
            mainWindow.Image_Lpng_03_15.Visibility = Visibility.Collapsed;

            //Item Set Übung
            mainWindow.Image_67png_01_05.Visibility = Visibility.Collapsed;
            mainWindow.Image_71png_01_17.Visibility = Visibility.Collapsed;
            mainWindow.Image_18png_01_21.Visibility = Visibility.Collapsed;
            mainWindow.Image_75png_03_01.Visibility = Visibility.Collapsed;
            mainWindow.Image_41png_03_09.Visibility = Visibility.Collapsed;
            mainWindow.Image_74png_03_13.Visibility = Visibility.Collapsed;
            mainWindow.Image_60png_05_19.Visibility = Visibility.Collapsed;
            mainWindow.Image_29png_07_03.Visibility = Visibility.Collapsed;
            mainWindow.Image_70png_07_23.Visibility = Visibility.Collapsed;
            mainWindow.Image_53png_11_01.Visibility = Visibility.Collapsed;
            mainWindow.Image_25png_11_19.Visibility = Visibility.Collapsed;
            mainWindow.Image_58png_11_23.Visibility = Visibility.Collapsed;
            mainWindow.Image_76png_13_05.Visibility = Visibility.Collapsed;
            mainWindow.Image_57png_15_01.Visibility = Visibility.Collapsed;
            mainWindow.Image_59png_15_11.Visibility = Visibility.Collapsed;
            mainWindow.Image_61png_15_21.Visibility = Visibility.Collapsed;
            mainWindow.Image_73png_17_05.Visibility = Visibility.Collapsed;
            mainWindow.Image_62png_17_15.Visibility = Visibility.Collapsed;

            //Item Set A
            mainWindow.Image_48png_01_05.Visibility = Visibility.Collapsed;
            mainWindow.Image_49png_01_13.Visibility = Visibility.Collapsed;
            mainWindow.Image_26png_01_21.Visibility = Visibility.Collapsed;
            mainWindow.Image_72png_03_01.Visibility = Visibility.Collapsed;
            mainWindow.Image_33png_03_09.Visibility = Visibility.Collapsed;
            mainWindow.Image_11png_03_17.Visibility = Visibility.Collapsed;
            mainWindow.Image_16png_05_23.Visibility = Visibility.Collapsed;
            mainWindow.Image_50png_07_01.Visibility = Visibility.Collapsed;
            mainWindow.Image_40png_07_05.Visibility = Visibility.Collapsed;
            mainWindow.Image_37png_07_19.Visibility = Visibility.Collapsed;
            mainWindow.Image_9png_11_03.Visibility = Visibility.Collapsed;
            mainWindow.Image_30png_11_19.Visibility = Visibility.Collapsed;
            mainWindow.Image_5png_13_23.Visibility = Visibility.Collapsed;
            mainWindow.Image_35png_15_01.Visibility = Visibility.Collapsed;
            mainWindow.Image_32png_15_07.Visibility = Visibility.Collapsed;
            mainWindow.Image_13png_15_15.Visibility = Visibility.Collapsed;
            mainWindow.Image_42png_17_11.Visibility = Visibility.Collapsed;
            mainWindow.Image_66png_17_21.Visibility = Visibility.Collapsed;

            //Item Set B
            mainWindow.Image_22png_01_03.Visibility = Visibility.Collapsed;
            mainWindow.Image_17png_01_15.Visibility = Visibility.Collapsed;
            mainWindow.Image_4png_03_07.Visibility = Visibility.Collapsed;
            mainWindow.Image_19png_03_11.Visibility = Visibility.Collapsed;
            mainWindow.Image_46png_03_21.Visibility = Visibility.Collapsed;
            mainWindow.Image_23png_07_01.Visibility = Visibility.Collapsed;
            mainWindow.Image_43png_07_05.Visibility = Visibility.Collapsed;
            mainWindow.Image_52png_07_19.Visibility = Visibility.Collapsed;
            mainWindow.Image_39png_07_23.Visibility = Visibility.Collapsed;
            mainWindow.Image_27png_11_01.Visibility = Visibility.Collapsed;
            mainWindow.Image_3png_11_19.Visibility = Visibility.Collapsed;
            mainWindow.Image_8png_13_05.Visibility = Visibility.Collapsed;
            mainWindow.Image_68png_13_23.Visibility = Visibility.Collapsed;
            mainWindow.Image_45png_15_01.Visibility = Visibility.Collapsed;
            mainWindow.Image_34png_15_13.Visibility = Visibility.Collapsed;
            mainWindow.Image_2png_17_07.Visibility = Visibility.Collapsed;
            mainWindow.Image_6png_17_17.Visibility = Visibility.Collapsed;
            mainWindow.Image_54png_17_21.Visibility = Visibility.Collapsed;

            //Item Set C
            mainWindow.Image_12png_01_07.Visibility = Visibility.Visible;
            mainWindow.Image_20png_01_19.Visibility = Visibility.Visible;
            mainWindow.Image_28png_03_01.Visibility = Visibility.Visible;
            mainWindow.Image_1png_03_11.Visibility = Visibility.Visible;
            mainWindow.Image_38png_03_15.Visibility = Visibility.Visible;
            mainWindow.Image_55png_03_23.Visibility = Visibility.Visible;
            mainWindow.Image_31png_07_03.Visibility = Visibility.Visible;
            mainWindow.Image_7png_07_21.Visibility = Visibility.Visible;
            mainWindow.Image_51png_11_01.Visibility = Visibility.Visible;
            mainWindow.Image_69png_13_05.Visibility = Visibility.Visible;
            mainWindow.Image_14png_13_19.Visibility = Visibility.Visible;
            mainWindow.Image_24png_13_23.Visibility = Visibility.Visible;
            mainWindow.Image_15png_15_01.Visibility = Visibility.Visible;
            mainWindow.Image_44png_15_09.Visibility = Visibility.Visible;
            mainWindow.Image_21png_15_13.Visibility = Visibility.Visible;
            mainWindow.Image_36png_17_05.Visibility = Visibility.Visible;
            mainWindow.Image_10png_17_17.Visibility = Visibility.Visible;
            mainWindow.Image_47png_17_21.Visibility = Visibility.Visible;

            mainWindow.Rectangle_01_03.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_01_05.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_01_07.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_01_11.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_01_13.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_01_15.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_01_17.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_01_19.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_01_21.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_03_01.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_03_05.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_03_07.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_03_09.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_03_11.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_03_13.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_03_15.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_03_17.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_03_19.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_03_21.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_03_23.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_05_01.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_05_19.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_05_23.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_07_01.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_07_03.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_07_05.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_07_19.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_07_21.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_07_23.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_11_01.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_11_03.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_11_19.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_11_23.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_13_05.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_13_19.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_13_23.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_15_01.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_15_07.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_15_09.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_15_11.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_15_13.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_15_15.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_15_19.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_15_21.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_17_05.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_17_07.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_17_11.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_17_13.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_17_15.Fill = new SolidColorBrush(Color.FromArgb(255, 255, 255, 255));
            mainWindow.Rectangle_17_17.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
            mainWindow.Rectangle_17_21.Fill = new SolidColorBrush(Color.FromArgb(255, 0, 0, 0));
        }
    }
}
