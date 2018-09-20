using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace MarkCalculator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
        }

        private void TextBlock_SelectionChanged(object sender, RoutedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            calculateScore();
           



        }

        private void calculateScore()
        {
            double nOT = int.Parse(numberOfTaps.Text);
            int nOW = int.Parse(numberOfWeeks.Text);
            int oTS = int.Parse(onlineTestScore.Text);
            int aTS = int.Parse(assesmentScore.Text);
            string finalMark = "";


            // It is only possible to get 4 points per tap, per week, so we need to ensure the score is correct.:
            // Note, in this version, we assume that the students are honest when calculating the score.
            // They could be submitting 5 taps one week, and 3 for another, which would return an incorrect score.

            double maxTapScore = nOW * 4;
            if(nOT > maxTapScore) nOT = maxTapScore;

            // To combat cheating, the max score for the OT is 30
            if(oTS > 30) oTS = 30;
            
            // If you set the assesmet score higher than 50, reduce it to 50.
            //if (aTS > 50) aTS = 50;

            // Calculate the number of points each TAP is worth. If you complete every single TAP, you get 20 points.
            double tapPoints = 20 / maxTapScore;
            double finalTapScore = tapPoints * nOT;

            // The OT is worth max 30 points.
            // The final assesment is the score / 2. 
            int finalAssesmentScore = (aTS / 2);

            double totalScore = finalAssesmentScore + oTS + finalTapScore;

            totalScoreText.Text = totalScore.ToString();

            // Only give a mark, if the student has passed the final assesment.
            if (finalAssesmentScore > 25)
            {
                if (totalScore > 89)
                {
                    finalMark = "A";
                }
                else if (totalScore > 79)
                {
                    finalMark = "B";
                }
                else if (totalScore > 59)
                {
                    finalMark = "C";
                }
                else if (totalScore > 49)
                {
                    finalMark = "D";
                }
                else
                {
                    finalMark = "Fail";
                }

            }
            else finalMark = "Fail";


            totalMark.Text = finalMark.ToString();





            
            

            //int finalScore = 

        }

    }
}
