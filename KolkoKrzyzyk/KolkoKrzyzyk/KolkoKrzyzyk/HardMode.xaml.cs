using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace KolkoKrzyzyk
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class HardMode : ContentPage
    {

        char playerSign;
        char computerSign;
        bool playerStart = false;
        public HardMode()
        {
            InitializeComponent();
        }
        private void Button_Clicked(object sender, EventArgs e)
        {
            
        }
        private void newGameButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new MainPage());
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
    }
}