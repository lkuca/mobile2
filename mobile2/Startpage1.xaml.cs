﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mobile2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class Startpage1 : ContentPage
    {

        List<ContentPage> pages = new List<ContentPage>() { new Entry(), new Timepage(), new Clikker(), new Datetimepage(), new BoxViewss(), new lummememm(), new Framepage1() , new lumik(), new nullidjaristkud()};
        List<string> texs = new List<string>() { "Ava entry leht", "Ava Timer leht", "Ava clikker leht","Ava Datetimepage","Ava BoxViewss","Ava lummemmem", "ava frame","Lumik", "nullid ja ristikud" };
        StackLayout st;
        public Startpage1()
        {
            st = new StackLayout
            {
                Orientation= StackOrientation.Vertical,
                BackgroundColor= Color.White,
            };
            for (int i = 0; i <pages.Count; i++) 
            {
                Button button = new Button
                {
                    Text = texs[i],
                    BackgroundColor=Color.Black,
                    TabIndex= i,
                    TextColor = Color.White
                };
                st.Children.Add(button);
                button.Clicked += Ava_vajav_leht;
                
            }
            ScrollView sv = new ScrollView { Content = st };
            Content =sv;
        }
        private async void Ava_vajav_leht(object sender, EventArgs e)
        {
            Button btn=(Button)sender;
            await Navigation.PushAsync(pages[btn.TabIndex]);
        }
    }
        
       

}