using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KolkoKrzyzyk
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Game1 : ContentPage
    {
        char playerSign;
        char computerSign;
        bool playerStart = false;
        bool playerWin = false;
        bool computerWin = false;

        public Game1()
        {
            InitializeComponent();
            RandomSign();
            if (!playerStart)
                ComputerMove();
        }

        public void RandomSign()
        {
            Random random = new Random();
            int i = random.Next(0, 2);
            playerSign = i == 0 ? 'X' : 'O';
            if (playerSign == 'X')
            {
                computerSign = 'O';
                playerStart = true;
            }
            else
                computerSign = 'X';

            signLabel.Text = "Twój znak: " + playerSign;
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
           Button btn = (Button)sender;
            if (btn.Text == null)
            {
                WhoWin();
                btn.Text = playerSign.ToString();
                WhoWin();
                if (!IsTableFull() && !playerWin)
                    ComputerMove();                
            }
            else
                DisplayAlert("Błąd", "Miejsce zajęte!", "OK"); 
        }
        private void ComputerMove()
        {
            WhoWin();
            Button[] btnTab = { b1, b2, b3, b4, b5, b6, b7, b8, b9 };
            bool isFilled = false;
            Random random = new Random();
            do
            {
                int i = random.Next(0, 9);
                if (btnTab[i].Text == "" || btnTab[i].Text == null)
                {
                    btnTab[i].Text = computerSign.ToString();
                    isFilled = true;
                }

            } while (!isFilled);
            WhoWin();
        }
        private void WhoWin()
        {
            if ((b1.Text == playerSign.ToString() && b2.Text == playerSign.ToString() && b3.Text == playerSign.ToString()) ||
               (b4.Text == playerSign.ToString() && b5.Text == playerSign.ToString() && b6.Text == playerSign.ToString()) ||
               (b7.Text == playerSign.ToString() && b8.Text == playerSign.ToString() && b9.Text == playerSign.ToString()) ||
               (b1.Text == playerSign.ToString() && b4.Text == playerSign.ToString() && b7.Text == playerSign.ToString()) ||
               (b2.Text == playerSign.ToString() && b5.Text == playerSign.ToString() && b8.Text == playerSign.ToString()) ||
               (b3.Text == playerSign.ToString() && b6.Text == playerSign.ToString() && b9.Text == playerSign.ToString()) ||
               (b1.Text == playerSign.ToString() && b5.Text == playerSign.ToString() && b9.Text == playerSign.ToString()) ||
               (b3.Text == playerSign.ToString() && b5.Text == playerSign.ToString() && b7.Text == playerSign.ToString()))
                playerWin = true;
            else if ((b1.Text == computerSign.ToString() && b2.Text == computerSign.ToString() && b3.Text == computerSign.ToString()) ||
               (b4.Text == computerSign.ToString() && b5.Text == computerSign.ToString() && b6.Text == computerSign.ToString()) ||
               (b7.Text == computerSign.ToString() && b8.Text == computerSign.ToString() && b9.Text == computerSign.ToString()) ||
               (b1.Text == computerSign.ToString() && b4.Text == computerSign.ToString() && b7.Text == computerSign.ToString()) ||
               (b2.Text == computerSign.ToString() && b5.Text == computerSign.ToString() && b8.Text == computerSign.ToString()) ||
               (b3.Text == computerSign.ToString() && b6.Text == computerSign.ToString() && b9.Text == computerSign.ToString()) ||
               (b1.Text == computerSign.ToString() && b5.Text == computerSign.ToString() && b9.Text == computerSign.ToString()) ||
               (b3.Text == computerSign.ToString() && b5.Text == computerSign.ToString() && b7.Text == computerSign.ToString()))
                computerWin = true;
           

            if (playerWin || computerWin)
                Navigation.PushModalAsync(new Page1(playerWin, computerWin));
            IsTableFull();
            
        }

        private bool IsTableFull()
        {            
            Button[] btnTab = { b1, b2, b3, b4, b5, b6, b7, b8, b9 };
            int licz = 0;
            for(int i = 0; i < btnTab.Length; i++)
            {
                if (btnTab[i].Text != null)
                    licz++;
                else
                    return false;
            }
            if (licz == 9 && !playerWin && !computerWin)
            {
                Navigation.PushModalAsync(new Page1(playerWin, computerWin));
                return true;                
            }            
            return false;
            
        }

             

    }




}
