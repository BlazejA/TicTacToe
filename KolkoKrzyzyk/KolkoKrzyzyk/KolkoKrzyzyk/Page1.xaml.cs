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
    public partial class Page1 : ContentPage
    {
        public Page1(bool playerWin, bool computerWin)
        {
            InitializeComponent();
            if (playerWin)
            {
                resultLabel.Text = "Wygrałeś!";
                resultLabel.BackgroundColor = Color.LimeGreen;
            }
            else if (computerWin)
            {
                resultLabel.Text = "Przegrałeś!";
                resultLabel.BackgroundColor = Color.Firebrick;
            }
            else
            {
                resultLabel.Text = "Remis!";
                resultLabel.BackgroundColor = Color.Gold;
            }
        }

        private void newGameButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushModalAsync(new Game1());
        }
    }
}