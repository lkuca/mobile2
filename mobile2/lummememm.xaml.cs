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
    public partial class lummememm : ContentPage
    {
        Label StepperSlider;
        Slider sld;
        Slider red1;
        Slider Green1;
        Slider blue1;
        Stepper stp;
        Stepper backgroundchange;
        BoxView box;
        int r;
        int g;
        int b;
        public lummememm()
        {
           

            box = new BoxView

            {
                
                
                WidthRequest = 200,
                HeightRequest = 400,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };



            StepperSlider = new Label
            {
                Text="...",
                HorizontalOptions= LayoutOptions.Center,
                VerticalOptions= LayoutOptions.CenterAndExpand
            };
            red1 = new Slider 
            {
                Minimum = 0,
                Maximum = 255,
                Value = 30,
                MinimumTrackColor = Color.White,
                MaximumTrackColor = Color.Black,
                ThumbColor = Color.Blue,
            };
            
            
            Green1 = new Slider
            {
                Minimum = 0,
                Maximum = 255,
                Value = 30,
                MinimumTrackColor = Color.White,
                MaximumTrackColor = Color.Black,
                ThumbColor = Color.Blue,
            };
           
            blue1 = new Slider 
            {
                Minimum = 0,
                Maximum = 255,
                Value = 30,
                MinimumTrackColor = Color.White,
                MaximumTrackColor = Color.Black,
                ThumbColor = Color.Blue,
            };
            
            red1.ValueChanged += redvaluechanged;
            Green1.ValueChanged += greenvaluechanged;
            blue1.ValueChanged += bluevaluechanged;
            backgroundchange = new Stepper
            {
                Minimum = 0,
                Maximum = 100,
                Increment = 10,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.CenterAndExpand
            };
            backgroundchange.ValueChanged += BackgroundColorchange;
            sld = new Slider
            {
                Minimum= 0,
                Maximum= 100,
                Value = 30,
                MinimumTrackColor= Color.White,
                MaximumTrackColor= Color.Black,
                ThumbColor= Color.Red,
            };
            sld.ValueChanged += Sld_ValueChanged;
            stp = new Stepper
            {
                Minimum = 0,
                Maximum = 100,
                Increment = 1,
                HorizontalOptions= LayoutOptions.Center,
                VerticalOptions= LayoutOptions.CenterAndExpand
            };
            stp.ValueChanged += Stp_Valuechanged;
            StackLayout st = new StackLayout
            {
                Children= { backgroundchange,sld,red1,Green1,blue1,box, StepperSlider,stp }
            };
            Content= st;
        }

        private void bluevaluechanged(object sender, ValueChangedEventArgs e)
        {
            box.BackgroundColor = Color.FromRgb((int)red1.Value, (int)Green1.Value, (int)blue1.Value);
        }

        private void greenvaluechanged(object sender, ValueChangedEventArgs e)
        {
            box.BackgroundColor = Color.FromRgb((int)red1.Value, (int)Green1.Value, (int)blue1.Value);
        }

        private void redvaluechanged(object sender, ValueChangedEventArgs e)
        {
            box.BackgroundColor = Color.FromRgb((int)red1.Value, (int)Green1.Value, (int)blue1.Value);
        }

        private void Stp_Valuechanged(object sender, ValueChangedEventArgs e)
        {
            StepperSlider.Text = String.Format("Valitud: {0:F1}", e.NewValue);
            StepperSlider.FontSize = e.NewValue;
            StepperSlider.Rotation= e.NewValue;
        }

        private void Sld_ValueChanged(object sender, ValueChangedEventArgs e)
        {
            StepperSlider.Text = String.Format("Valitud: {0:F1}", e.NewValue);
            StepperSlider.FontSize = e.NewValue;
            StepperSlider.Rotation = e.NewValue;
        }
        private void BackgroundColorchange(object sender, ValueChangedEventArgs e)
        {
            red1.BackgroundColor = Color.FromRgb((int)red1.Value, (int)Green1.Value, (int)blue1.Value);
            Green1.BackgroundColor = Color.FromRgb((int)red1.Value, (int)Green1.Value, (int)blue1.Value);
            blue1.BackgroundColor = Color.FromRgb((int)red1.Value, (int)Green1.Value, (int)blue1.Value);
        }


    }
}