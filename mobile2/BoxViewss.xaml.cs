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
    public partial class BoxViewss : ContentPage
    {
        BoxView box;
        Label clickCountLabel;
        int clickCount;
        public BoxViewss()
        {
            int r=0, g=0, b=0;
            box = new BoxView
            
            {
                Color= Color.Red,
                CornerRadius= 10,
                WidthRequest=200, HeightRequest=400,
                HorizontalOptions= LayoutOptions.Center,
                VerticalOptions= LayoutOptions.CenterAndExpand
            };
            TapGestureRecognizer tap = new TapGestureRecognizer();
            
                tap.Tapped += Tap_tapped;
            box.GestureRecognizers.Add(tap);

            clickCountLabel = new Label
            {
                Text = "Klikid: 0",
                FontSize= 20,
                HorizontalOptions = LayoutOptions.CenterAndExpand,
                VerticalOptions = LayoutOptions.CenterAndExpand

            };

            StackLayout st = new StackLayout { Children= { box } };
            Content = st;

        }
        Random rnd;
        private void Tap_tapped(object sender, EventArgs e)
        {
            clickCount++;
            rnd = new Random();
            box.Color = Color.FromRgb(rnd.Next(0,255),rnd.Next(0,255), rnd.Next(0,255));
            box.RotateTo(box.Rotation + 45, 250);
            UpdateClickCountLabel();
        }
        private void UpdateClickCountLabel()
        {
            clickCountLabel.Text = $"klikid: {clickCount}";
        }
    }
}