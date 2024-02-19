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
    public partial class Framepage1 : ContentPage
    {
        Grid grid;
        Random random = new Random();
        Frame fr;
        Label lbl;
        Image image;
        Switch sw;
        public Framepage1()
        {
            grid = new Grid
            {
                BackgroundColor = Color.DarkGreen,
                HorizontalOptions= LayoutOptions.FillAndExpand,
                VerticalOptions= LayoutOptions.FillAndExpand,
            };
            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.Tapped += Tap_tapped;
            tap.NumberOfTapsRequired = 1;
            
            for (int i = 0; i <10; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    grid.Children.Add(fr = new Frame { BackgroundColor = Color.FromRgb(random.Next(0, 2555), random.Next(0, 255), random.Next(0, 255)) }, i, j);
                    fr.GestureRecognizers.Add(tap);
                }
            }
            lbl = new Label { Text = "Tekst" ,FontSize=Device.GetNamedSize(NamedSize.Subtitle,typeof(Label))};
            grid.Children.Add(lbl, 0,6);
            Grid.SetRowSpan(lbl, 6);

            image = new Image { Source = "su57.jpg" };
            sw = new Switch { IsToggled = false };
            sw.Toggled += Image_On_Off;
            grid.Children.Add(sw, 0, 7);
            grid.Children.Add(image, 1, 7);


            Content = grid;
        }

        private void Image_On_Off(object sender, ToggledEventArgs e)
        {
            if (e.Value)
            {
                image.IsVisible = true;
            }
            else { image.IsVisible = false; }
        }

        private void Tap_tapped(object sender, EventArgs e)
        {
            Frame fr = (Frame)sender;
            var r = Grid.GetRow(fr);
            var c = Grid.GetColumn(fr);
            lbl.Text = "Rida: " + r.ToString() + "veerg: " + c.ToString();
        }
    }
}