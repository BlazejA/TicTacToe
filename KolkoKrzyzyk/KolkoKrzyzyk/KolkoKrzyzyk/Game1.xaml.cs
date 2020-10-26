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
    public partial class Game1 : ContentPage
    {
        public Game1()
        {
            InitializeComponent();
            randomSign();
            
            
        }
        char playerSign;
        char computerSign;

        public void randomSign()
        {
            Random random = new Random();
            int i = random.Next(0, 2);
            playerSign = i == 0 ? 'X' : 'O';
            if (playerSign == 'X')
                computerSign = 'O';
            else
                computerSign = 'X';

            signLabel.Text = "Twój znak: " + playerSign;
        }

        private void button_Clicked(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            btn.Text = playerSign.ToString();
        }
    }




}
