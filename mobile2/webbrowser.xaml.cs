using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using static System.Net.WebRequestMethods;

namespace mobile2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class webbrowser : ContentPage
    {
        StackLayout st;
        Frame frame;
        Picker picker,picker2;
        WebView webView;
        string sri = "";
        Button bt,bt1,History_bt;
        string[] lehed = new string[3] { "https://www.tthk.ee/", "https://www.youtube.com/", "https://moodle.edu.ee/" };
        string[] nimetused = new string[3] { "tthk", "YOUTUBE", "Moodle" };
        string[] lehed1 = new string[4] { "https://www.tthk.ee/", "https://www.youtube.com/", "https://moodle.edu.ee/", "https://www.w3schools.com/" };
        List<string> history = new List<string> {};
        public webbrowser()
        {
            picker2 = new Picker
            {
                Title = "History",
                 IsVisible = false
            };
            foreach (string skidish in history)
            {
                picker2.Items.Add(skidish);
            }
            picker = new Picker
            {
                Title = "Veebileht"
            };
            foreach ( string leht in nimetused)
            {
                picker.Items.Add( leht );
            }
            webView = new WebView
            {
                Source = new UrlWebViewSource { Url = "https://www.w3schools.com/" },
                
                HeightRequest = 500,
                WidthRequest = 200,
            };
            webView.Navigated += WebView_Navigated;
            frame = new Frame
            {
                BorderColor =Color.Gray,
                HasShadow= true,
                HeightRequest= 200,
                WidthRequest= 200,
            };
            bt = new Button
            {
                BorderColor = Color.Gray,
                HeightRequest= 55,
                WidthRequest= 30,
                Text = "Koduleht"
            };
            bt1 = new Button
            {
                BorderColor = Color.Gray,
                HeightRequest = 55,
                WidthRequest = 30,
                
            };
            History_bt = new Button
            {
                BorderColor = Color.Gray,
                HeightRequest = 55,
                WidthRequest = 30,
            };

            bt1.ImageSource = (@"pictures\back-modern-flat-icon-600nw-242284795.webp");
            SwipeGestureRecognizer swipe = new SwipeGestureRecognizer
            {
                Direction = SwipeDirection.Right
            };
            SwipeGestureRecognizer swipe1 = new SwipeGestureRecognizer
            {
                Direction = SwipeDirection.Left
            };
            st = new StackLayout
            {
                Children = { picker, webView }
            };

            frame.GestureRecognizers.Add( swipe );
            frame.GestureRecognizers.Add( swipe1 );
            Content= st;
            bt.Clicked += Home_page;
            bt1.Clicked += Back_button;
            History_bt.Clicked += historyView;
            swipe.Swiped += Swipe_Swiped;
            swipe1.Swiped+= Swipe_Swiped;
            //webView.GestureRecognizers.Add( swipe );
            picker.SelectedIndexChanged += Valime_leht_avamiseks;

            Content = new StackLayout
            {
                Children = {picker,picker2,bt,bt1,History_bt,webView,frame,}
            };
        }

        private void WebView_Navigated(object sender, WebNavigatedEventArgs e)
        {
            if(e.Url == "https://www.w3schools.com/")
            {
                history.Add("https://www.w3schools.com/");
            }
            if (picker.SelectedIndex == 0)
            {
                history.Add("https://www.tthk.ee/");
            }
            if (picker.SelectedIndex == 1)
            {
                history.Add("https://www.youtube.com/");
            }
            if (picker.SelectedIndex == 2)
            {
                history.Add("https://moodle.edu.ee/");
            }

        }

        private void historyView(object sender, EventArgs e)
        {

            webView.Source = new UrlWebViewSource { Url = history[picker2.SelectedIndex] };
        }

        private void Back_button(object sender, EventArgs e)
        {
            
        }

        private void Home_page(object sender, EventArgs e)
        {
            webView.Source = new UrlWebViewSource { Url = "https://www.w3schools.com/" };
        }

        private void Swipe_Swiped(object sender, SwipedEventArgs e)
        {

            //webView.Source = new UrlWebViewSource { Url = lehed[picker.SelectedIndex] };
            switch(e.Direction)
            {
                case SwipeDirection.Right:
                    if (picker.SelectedIndex ==lehed.Length-1)
                    {
                        picker.SelectedIndex = 0;
                    }
                    else { picker.SelectedIndex += 1; }
                    //webView.GoBack();
                    //picker.SelectedIndex -= 1;
                    break;
                case SwipeDirection.Left:
                    if (picker.SelectedIndex == 0)
                    {
                        picker.SelectedIndex = lehed.Length - 1;
                    }
                    else { picker.SelectedIndex -= 1; }
                    break;
               
            }

        }

        private void Valime_leht_avamiseks(object sender, EventArgs e)
        {
            webView.Source = new UrlWebViewSource { Url = lehed[picker.SelectedIndex] };
                        
        }
    }
}