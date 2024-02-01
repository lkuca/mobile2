using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static System.Net.Mime.MediaTypeNames;

namespace mobile2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Entry : ContentPage
    {
        Label lbl;
        Editor editor;
        public Entry()
        {

            Button exit = new Button()
            {
                Text = "Back",
                BackgroundColor = Color.Yellow,
                TextColor = Color.Fuchsia,
            };

            lbl = new Label
            {
                Text = "Mingi tekst",
                BackgroundColor = Color.Green,
                TextColor = Color.Blue,
            };

            editor = new Editor()
            {
                Placeholder="Sissesta siia text",
                BackgroundColor = Color.Green,
                TextColor= Color.Blue,
                
            };

            StackLayout st = new StackLayout
            {
                Orientation = StackOrientation.Vertical,
                BackgroundColor = Color.Red,
                Children = {lbl, exit, editor},
                VerticalOptions = LayoutOptions.End
            };

           



            
            Content = st;
            exit.Clicked += exit_btn_Cliked;
            editor.TextChanged += Editor_TextChanged;
        }
        private async void exit_btn_Cliked(object sender, EventArgs e)
        {
            await Navigation.PopAsync();
        }
        private async void Editor_TextChanged(object sender, EventArgs e)
        {
            lbl.Text = editor.Text;
        }
    }
}