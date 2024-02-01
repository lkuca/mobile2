using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mobile2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Start : ContentPage
    {
        public Start()
        {

            Button Entry_btn = new Button
            {
                Text= "Entry leht",
                BackgroundColor= Color.Yellow,
                TextColor= Color.Fuchsia,
            };
            Button Time_btn = new Button
            {
                Text = "timer",
                BackgroundColor = Color.Yellow,
                TextColor = Color.Fuchsia,
            };
            Button Box_btn = new Button
            {
                Text ="BoxView",
                BackgroundColor= Color.Yellow,
                TextColor= Color.Fuchsia,
            };
            StackLayout st = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                BackgroundColor = Color.Red,
            };
            st.Children.Add( Time_btn );
            st.Children.Add( Box_btn );
            st.Children.Add(Entry_btn);
            Content= st;
            Entry_btn.Clicked += Entry_btn_Cliked;
            Time_btn.Clicked += Time_btn_Clicked;
            Box_btn.Clicked += Box_btn_Clicked;
        }

        private async void Box_btn_Clicked(object sender, EventArgs e)
        {
             await Navigation.PushAsync(new BoxViewss());
        }

        private async void Time_btn_Clicked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Timepage());
        }

        private async void Entry_btn_Cliked(object sender, EventArgs e)
        {
            await Navigation.PushAsync(new Entry());
        }
    }
}