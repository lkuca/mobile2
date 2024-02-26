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
        Picker picker;
        WebView webView;
        string[] lehed = new string[3] { "https://www.tthk.ee/", "https://www.youtube.com/", "https://moodle.edu.ee/" };
        string[] nimetused = new string[3] { "tthk", "YOUTUBE", "Moodle" };
        
        public webbrowser()
        {
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
            frame = new Frame
            {
                BorderColor =Color.Gray,
                HasShadow= true,
                HeightRequest= 200,
                WidthRequest= 200,
            };
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
            swipe.Swiped += Swipe_Swiped;
            swipe1.Swiped+= Swipe_Swiped;
            //webView.GestureRecognizers.Add( swipe );
            picker.SelectedIndexChanged += Valime_leht_avamiseks;
            Content = new StackLayout
            {
                Children = {picker, webView,frame}
            };
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