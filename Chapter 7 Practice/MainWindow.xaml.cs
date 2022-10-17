using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Chapter_7_Practice
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NoteToSelf()
        { 
            /// If I do decide to use an ARRAY (at this moment I don't know if it can be 
            /// used to read thorugh a list and then return a true/false value. BUTTTTT
            /// if I do decide to use it, remember:
                /// The [] follows the data type
                /// You can initialize the number of elements in the array with a const int variable
                /// You can include the elements in the intialization
                    /// EXAMPLE:
                    /// const int SIZE = 4;
                    /// string[] whatAmIDoing = new string[SIZE] { "this", "that", "not this", "not that"};
            /// I do need to double check that the elements are kept separate by commas and not semi-colons.
            /// Also, the element begins at [0] and ends at [desired total - 1].
        }

        private void randomNumberButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                /// How can I use RANDOMS with the element project? What can I take from this?
                /// Create a LOWER_BOUND and UPPER_BOUND variable. Remember that the
                /// UPPER_BOUND variable number desn't reflect the full range of the variable.
                /// The full range of the variable is UPPER_BOUND minus 1.
                Random rand = new Random();
                var lowerBound = 0;
                var upperBound = 201;

                int num = rand.Next(lowerBound, upperBound);
                int fifty = 50;
                int oneHundred = 100;
                int oneFifty = 150;
                int twoHundred = 200;

                if (num <= fifty)
                {
                    randomNumberLabel.Content = "D";
                }

                else if (num <= oneHundred)
                {
                    randomNumberLabel.Content = "C";
                }
                    
                else if (num <= oneFifty)
                {
                    randomNumberLabel.Content = "B";
                }

                else if (num <= twoHundred)
                {
                    randomNumberLabel.Content = "A";
                }

                else
                {
                    randomNumberLabel.Content = num;
                }
            }

            catch
            {
                MessageBox.Show("Error");
            }
        }

        private void arrayToFile_Click(object sender, RoutedEventArgs e)
        {
            /// This prints an array onto a file. 
            try
            {
            
                string[] randomSong = new string[] { "Girl", ",", "put", "your", "records", "on", ".", " ", "Tell", 
                    "me", "your", "favorite", "song", ".", " ", "You", "go", "ahead", ",", "let", "your", "hair", "down", "."};

                StreamWriter lyrics = File.CreateText(@"C:/Users/Public/Practicing C#/lyrics.txt");

                foreach(string word in randomSong)
                {
                    lyrics.WriteLine(word);
                }

                lyrics.Close();
            }

            catch
            {
                MessageBox.Show("Error with writing");
            }
        }

        private void StringToArray(string[] arrayedFile)
        {

        }

        private void fileToArray_Click(object sender, RoutedEventArgs e)
        {
            /// This reads a file and turns it into an array and reads it into a listbox
            /// ...
            /// ...
            /// ...
            /// It literally took me two hours to figure out that all I needed was to write three lines
            /// ...
            /// ...
            /// Bruh...
            try
            {
                string[] readBack = System.IO.File.ReadAllLines(@"C:/Users/Public/Practicing C#/lyrics.txt");
                lyricsListBox.Items.Clear();

                foreach(string line in readBack)
                {
                    lyricsListBox.Items.Add(line);
                }
            }

            catch
            {
                MessageBox.Show("Error with reading");
            }
           
        }

        private void createTestScores_Click(object sender, RoutedEventArgs e)
        {
            //This is the creation of a test scores file with the intention of 
            // reading it into a listbox.
            try
            {
                StreamWriter testScores = File.CreateText (@"C:/Users/Public/Practicing C#/Scores.txt");

                testScores.WriteLine("78.9");
                testScores.WriteLine("93.7");
                testScores.WriteLine("88.9");
                testScores.WriteLine("79.9");
                testScores.WriteLine("81.2");
                testScores.WriteLine("90.0");

                testScores.Close();
            }

            catch
            {
                MessageBox.Show("Error occurred!");
            }
        }

        private void processScores_Click(object sender, RoutedEventArgs e)
        {
            // Here, we are creating an array to hold the items from the 
            // file we just created. That array will then be read into
            // the listbox. The array in this example will hold more
            // elements that what will actually be used. The goal is to
            // only read the defined elements into the listbox

            StreamReader readScores = File.OpenText(@"C:/Users/Public/Practicing C#/Scores.txt");
            const int ARRAY_SIZE = 100;

            double[] scoreHolder = new double[ARRAY_SIZE];
            int count = 0;
            double total = 0.0;
            double average;

            testScoresListBox.Items.Clear();

            while(count < scoreHolder.Length && !readScores.EndOfStream)
            {
                scoreHolder[count] = double.Parse(readScores.ReadLine());
                count++;
            }

            readScores.Close();

            testScoresListBox.Items.Add("There are " + count + " test scores.");
            testScoresListBox.Items.Add(" ");

            for(int index = 0; index < count; index++)
            {
                    testScoresListBox.Items.Add(scoreHolder[index]);
                    total += scoreHolder[index];
            }
            
            average = total / count;

            testScoresListBox.Items.Add("");
            testScoresListBox.Items.Add("The score average is " + average.ToString("n2"));
        }

        private void initializeRows_ColmsButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                /// Observation:
                /// For some reaseon, this gives me 3*5 instead of 4*6 sets of numbers.
                /// I don't believe that in this case the first element is [0]. It appears
                /// to be [1] instead. 

                /// NEVERMIND!!! I forgot that arrays are "SPECIFIED_SIZE - 1".

                Random content = new Random();
                const int ROWS = 3;
                const int COLUMNS = 5;
                int[,] rowsNColumns = new int[ROWS, COLUMNS];
                const int MAX_RANDOM = 100;
                const int MIN_RANDOM = 0;

                
                for (int rows = 0; rows < ROWS; rows++)
                {
                    for (int columns = 0; columns < COLUMNS; columns++)
                    {
                        rowsNColumns[rows, columns] = content.Next(MIN_RANDOM, MAX_RANDOM);
                    }
                }

                rNcListBox.Items.Add(rowsNColumns[2, 3].ToString());
                rNcListBox.Items.Add(rowsNColumns[0, 1].ToString());
                rNcListBox.Items.Add(rowsNColumns[1, 4].ToString());
                rNcListBox.Items.Add(rowsNColumns[0, 0].ToString());

            }
            catch
            {
                MessageBox.Show("Try Again!");
            }


        }

        private void surpriseButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string[] thisAgain = System.IO.File.ReadAllLines(@"C:/Users/Public/Practicing C#/lyrics.txt");

                List<string> myFirstList = new List<string>(thisAgain);

                lyricsListBox.Items.Clear();

                foreach(string line in myFirstList)
                {
                    lyricsListBox.Items.Add(line);
                }

                // This is the REMOVE_AT function at work.
                myFirstList.RemoveAt(4);
                foreach(string line in myFirstList)
                {
                    testScoresListBox.Items.Add(line);
                }

                // This is the REMOVE function at work.
                myFirstList.Remove("favorite");
                foreach(string line in myFirstList)
                {
                    rNcListBox.Items.Add(line);
                }
            }

            catch
            {
                MessageBox.Show("Nice try");
            }

        }

        private void AlphabeticalOrder(List<char> alphabet)
        {
            /// The assignment question for this set of work. I'm still struggling to believe
            /// that I did this correctly:

            /// Create a List object that uses the binary search algorithm to search for the 
            /// string "A". Display a message box indicating whether the value was found.

            /// I decided to start from a string in a random order; turned it into a 
            /// character List that would allow me to sort the letters in ascending order;
            /// and then ran a binary search algorithm. 

            try
            {
                int minIndex;
                int alphabetCount = alphabet.Count;
                int minValue;

                for (int startScan = 0; startScan < alphabetCount - 1; startScan++)
                {
                    minIndex = startScan;
                    minValue = alphabet[startScan];

                    for (int index = startScan + 1; index < alphabetCount; index++)
                    {

                        if (alphabet[index] < minValue)
                        {
                            minValue = alphabet[index];
                            minIndex = index;
                        }

                        Swap(minIndex, startScan);
                    }

                }

            }

            catch
            {
                MessageBox.Show("Error at Sorting");
            }
        }

        private void Swap(int a, int b)
        {
            try
            {
                int temp = a;
                a = b;
                b = temp;
            }
            catch
            {
                MessageBox.Show("Error at Swapping");
            }
        }

        private void Results(bool found)
        {
            if (found == true)
            {
                MessageBox.Show("CONGRATULATIONS!!!!");
            }

            if(found == false)
            {
                MessageBox.Show("Back to the drawing board, but good job");
            }
        }
        private void yetAnotherButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string abcs = "CPQRFAHJ";
                List<char> letters = new List<char>();
                letters.AddRange(abcs);
                char searchFor = 'A';

                int first = 0;
                int last = letters.Count - 1;
                int middle;
                int position = -1;
                bool found = false;
                AlphabeticalOrder(letters);

                while (!found && first <= last)
                {
                    middle = (first + last) / 2;

                    if (letters[middle] == searchFor)
                    {
                        found = true;
                        position = middle;
                    }

                    else if (letters[middle] < searchFor)
                    {
                        last = middle - 1;
                    }

                    else
                    {
                        first = middle - 1;
                    }
                }

                Results(found);

            }

            catch
            {
                MessageBox.Show("I hope we figure this out in time");
            }
        }
    }
}
