using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace KolkoKrzyzyk
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_Clicked(object sender, EventArgs e)
        {
            
            if (picker.SelectedItem == null)
                await DisplayAlert("Błąd", "Nie wybrano poziomu trudności!", "OK");
            else if (picker.SelectedItem.ToString() == "Trudny")
                await Navigation.PushModalAsync(new HardMode());
            else if (picker.SelectedItem.ToString() == "Łatwy")
                await Navigation.PushModalAsync(new Game1());

        }
    }
}
