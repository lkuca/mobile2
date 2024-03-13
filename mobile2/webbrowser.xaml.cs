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
        
        Button bt,bt1, favoritesButton;
        string[] lehed = new string[3] { "https://www.tthk.ee/", "https://www.youtube.com/", "https://moodle.edu.ee/" };
        string[] nimetused = new string[3] { "tthk", "YOUTUBE", "Moodle" };
        string[] lehed1 = new string[4] { "https://www.tthk.ee/", "https://www.youtube.com/", "https://moodle.edu.ee/", "https://www.w3schools.com/" };
        List<string> favorites = new List<string>();
        Entry searchentry;

        string vali;
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
            picker2 = new Picker
            {
                Title = "lemmikud browse"
            };
            foreach (string currentUrl in favorites)
            {
                picker2.Items.Add(currentUrl);
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
                Text ="Tagasi"
                
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
            SearchBar searchbar = new SearchBar
            {
                Placeholder ="Sissestage sait",
                HorizontalOptions = LayoutOptions.FillAndExpand
            };
            searchbar.TextChanged += Searchbar_TextChanged;

            frame.GestureRecognizers.Add( swipe );
            frame.GestureRecognizers.Add( swipe1 );
            Content= st;
            bt.Clicked += Home_page;
            bt1.Clicked += Back_button;
           
            swipe.Swiped += Swipe_Swiped;
            swipe1.Swiped+= Swipe_Swiped;
            //webView.GestureRecognizers.Add( swipe );
            picker.SelectedIndexChanged += Valime_leht_avamiseks;
            picker2.SelectedIndexChanged += azoza;
            favoritesButton = new Button
            {
                Text = "lemmikud"
            };
            favoritesButton.Clicked += FavoritesButton_Clicked;
            

            Content = new StackLayout
            {
                Children = {searchbar,picker,picker2,bt,bt1,favoritesButton,webView, frame,}
            };
        }

        private void Searchbar_TextChanged(object sender, TextChangedEventArgs e)
        {
            var searchbar = sender as SearchBar;
            if (searchbar != null)
            {
                var searctext = searchbar.Text;
                if (!string.IsNullOrWhiteSpace(searctext))
                {
                    var url = "https://" + searctext;
                    webView.Source = new UrlWebViewSource { Url = url };

                    var index = Array.IndexOf(lehed, url);
                    if (index != -1)
                    {
                        picker.SelectedIndex = index;
                    }
                }

            }
        }

            private void WebView_Navigated(object sender, WebNavigatedEventArgs e)
        {
            vali = e.Url;
        }

        private void azoza(object sender, EventArgs e)
        {
            webView.Source = new UrlWebViewSource { Url = lehed1[picker2.SelectedIndex] };
        }

        private void FavoritesButton_Clicked(object sender, EventArgs e)
        {
            if (!favorites.Contains(vali))
            {
                picker2.Items.Add(vali);
                // Optionally, display a message or indicator that the URL is added to favorites
            }
        }

        private void Back_button(object sender, EventArgs e)
        {
            webView.GoBack();
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