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
    public partial class nullidjaristkud : ContentPage
    {
        Grid grid;
        public nullidjaristkud()
        {
             grid= new Grid
             {
                 BackgroundColor = Color.DarkGreen,
                 HorizontalOptions = LayoutOptions.FillAndExpand,
                 VerticalOptions = LayoutOptions.FillAndExpand,
             };
            TapGestureRecognizer tap = new TapGestureRecognizer();
            tap.Tapped += Tap_tapped;
            tap.NumberOfTapsRequired = 1;

            for (int i = 0; i < 3; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
            }
            Content = grid;

        }

        private void Tap_tapped(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}