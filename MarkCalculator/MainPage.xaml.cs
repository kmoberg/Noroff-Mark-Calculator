using Windows.UI.Popups;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;


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
            try { 
            double nOT = int.Parse(numberOfTaps.Text);
            int nOW = int.Parse(numberOfWeeks.Text);
            int oTS = int.Parse(onlineTestScore.Text);
            int aTS = int.Parse(assesmentScore.Text);
            string finalMark = "";

            // It is only possible to get 4 points per tap, per week, so we need to ensure the score is correct.:
            // Note, in this version, we assume that the students are honest when calculating the score.
            // They could be submitting 5 taps one week, and 3 for another, which would return an incorrect score.


            // Number of weeks in the course * 4 available points per week
            double maxTapScore = nOW * 4; 

            // Check that the points the student has entered is not higher than the maximum amount of points in the course.
            if(nOT > maxTapScore) nOT = maxTapScore;

            // Calculate the number of points each TAP is worth. If you complete every single TAP, you get 20 points.
            double tapPoints = 20 / maxTapScore;

            // Calculate the amount of TAPs submitted, but multiplying the score per TAP by the number of sumbmitted TAPs.
            double finalTapScore = tapPoints * nOT;




            // To combat cheating check that the OT score is not higher than 30.
            if (oTS > 30) oTS = 30;
            


            
            //Check that the assesment score is not higher than 100.
            if (aTS > 100) aTS = 100;

            // The final assesment is the score / 2. 
            int finalAssesmentScore = (aTS / 2);


            // Calculate the final score for the course. Course Project (assesment) + Online Test + TAP score
            double totalScore = finalAssesmentScore + oTS + finalTapScore;

            // return it in a string
            totalScoreText.Text = totalScore.ToString();



            // Give the score a grade
            // However, only give a mark, if the student has passed the final assesment.
            if (finalAssesmentScore > 24)
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

            // Return the final mark.
            totalMark.Text = finalMark.ToString();
            }

            catch
            {
                MessageDialog myMessage = new MessageDialog("You've entered something wrong...", "Error!");

                myMessage.ShowAsync();

            }



        }

    }
}
