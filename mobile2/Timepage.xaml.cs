using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mobile2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Timepage : ContentPage
    {
        public Timepage()
        {
            InitializeComponent();
        }

        private void TapGestureRecognizer_Tapped(object sender, EventArgs e)
        {
            Kapconka.Text = "Vajutatud";
        }
        bool flag = false;
        public async void NaitaAeg()
        {
            while (flag)
            {
                Kapconka.Text = DateTime.Now.ToString("f");
                Timer.Text = DateTime.Now.ToString("T");
                await Task.Delay(1000);
            }
        }
        private void Timer_Clicked(object sender, EventArgs e)
        {
            if (flag)
            {
                flag= false;
            }
            else { flag= true;
                NaitaAeg(); 
                    }
        }
    }
}