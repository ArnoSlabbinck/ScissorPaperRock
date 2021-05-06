using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace BladSteenSchaar
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string imagePaper = "https://upload.wikimedia.org/wikipedia/commons/a/af/Rock-paper-scissors_%28paper%29.png";
        string imageRock = "https://upload.wikimedia.org/wikipedia/commons/7/7e/Rock-paper-scissors_%28rock%29.png";
        string imageScissor = "https://upload.wikimedia.org/wikipedia/commons/5/5f/Rock-paper-scissors_%28scissors%29.png";
        Dictionary<string, Dictionary<string, double>> compareChoices = new Dictionary<string, Dictionary<string, double>>
        {
            //Rock chose
            {"Rock", new Dictionary<string, double> { {"Scissor", 1 }, {"Rock",0.5 }, {"Paper", 0 } } },
            {"Paper", new Dictionary<string, double>{ {"Rock", 1 }, {"Paper", 0.5 }, {"Scissor", 0 } } },
            {"Scissor", new Dictionary<string, double>{ {"Paper", 1 }, {"Scissor", 0.5 }, {"Rock", 0 } } }

        };
        int yourScore = 0;
        int computScore = 0;
        public MainWindow()
        {
            InitializeComponent();

        }
        private BitmapImage ChoiceOfRockPaperScissors(string choice)
        {

            BitmapImage bitmap = new BitmapImage();
            bitmap.BeginInit();

            bitmap.UriSource = new Uri(choice);

            bitmap.EndInit();

            return bitmap;
            
           
            

        }

        
        private string ChoiceComputer()
        {
            // A random choice between 0 and 2
            Random rnd = new Random();
            int choice = rnd.Next(0, 3);
            string Choice = string.Empty;
            switch (choice)
            {
                case 0:
                    ComputerChoice.ImageSource = ChoiceOfRockPaperScissors(imageScissor);
                    Choice = "Scissor";
                    break;
                case 1:
                    ComputerChoice.ImageSource = ChoiceOfRockPaperScissors(imageRock);
                    Choice = "Rock";
                    break;
                case 2:
                    ComputerChoice.ImageSource = ChoiceOfRockPaperScissors(imagePaper);
                    Choice = "Paper";
                    break;
            }
            // Choice determines the image
            // Then compare the images
            return Choice;
        }
        private void DecideWinner(string MyChoice, string ComputerChoice)
        {
            // Compare the choices of the computer and you
            // Every choice has a number ==> Compare the choices ==> Get the number
            // If the number is 
            var haveIWon = compareChoices[MyChoice][ComputerChoice];

            if (haveIWon == 0.5)
            {
                MessageBox.Show("There is a draw");
            }
            else if (haveIWon == 1)
            {
                MessageBox.Show("I have won");
                yourScore++;
                YouScore.Text = yourScore.ToString();

            }

            else {
                MessageBox.Show("Computer has won");
                computScore++;
                ComputerScore.Text = computScore.ToString();


            }

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            // We need to compare Rock
            var button = sender as Button;
            string myChoice = "";
            switch (button.Name)
            {
                case "ButtonRock":
                    YouChoice.ImageSource = ChoiceOfRockPaperScissors(imageRock);
                    myChoice = "Rock";
                    break;
                case "ButtonPaper":
                    YouChoice.ImageSource = ChoiceOfRockPaperScissors(imagePaper);
                    myChoice = "Paper";
                    break;
                case "ButtonScissor":
                    YouChoice.ImageSource = ChoiceOfRockPaperScissors(imageScissor);
                    myChoice = "Scissor";
                    break;

            }
    
            string TheComputerChoice = ChoiceComputer();


            // Compare choice of the computer with your choice 
            // Make an algoritm that compares choices ==> computer and me 
            // With numbers 
            // If someone won:  update the score of computer or me
            DecideWinner(myChoice, TheComputerChoice);
        }



       
    }
}
