using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mobile2
{
    public class Telefon
    {
        public string  Nimetus { get; set; }
        public string Tootja { get; set; }
        public int Hind { get; set; }

        public string Pilt { get; set; }
    }
    public partial class List_Page : ContentPage
    {
        public ObservableCollection<Telefon> telefons { get; set; }
        Label lbl_list;
        ListView list;
        Button lisa, kustuta;
        public List_Page()
        {
            InitializeComponent();
            //telefons = new List<Telefon> 
            //{
            //    new Telefon {Nimetus="Samsung Galaxy S21 Ultra", Tootja="Samsung", Hind=1349},
            //    new Telefon {Nimetus="Xiaomi Mi11 Lite 5G", Tootja="Xiaomi", Hind=399},
            //    new Telefon {Nimetus="Xiaomi Mi11 Lite 5G NE", Tootja="Xiaomi", Hind=560},
            //    new Telefon {Nimetus="Iphone 13", Tootja="Apple", Hind=1400}
            //};
            telefons = new ObservableCollection<Telefon>
            {
                new Telefon {Nimetus="Saksamaa", Pilt="s21.jpg"},
                new Telefon {Nimetus="Itaalia", Pilt ="Xiaomi.jpg"},
                new Telefon {Nimetus="Prantsusmaa", Pilt ="Xiaomi.jpg"},
                new Telefon {Nimetus="Holland", Pilt = "iphone13.jpg"}
            };
            list = new ListView()
            {
                SeparatorColor = Color.Orange,
                Header = "Minu oma kolektsion:",
                Footer = DateTime.Now.ToString("T"),


                HasUnevenRows= true,
                ItemsSource = telefons,
                ItemTemplate = new DataTemplate(()=>
                {
                    ImageCell imageCell = new ImageCell { TextColor = Color.Red, DetailColor = Color.Green };
                    imageCell.SetBinding(ImageCell.TextProperty, "Nimetus");
                    //Binding companyBinding = new Binding { Path = "Tootja", StringFormat = "Tore telefon firmalt {0}" };
                    //imageCell.SetBinding(ImageCell.DetailProperty, companyBinding);
                    imageCell.SetBinding(ImageCell.ImageSourceProperty, "Pilt");
                    return imageCell;
                    //Label nimetus = new Label { FontSize = 20 };
                    //nimetus.SetBinding(Label.TextProperty, "Nimetus");

                    //Label tootja = new Label();
                    //tootja.SetBinding(Label.TextProperty, "Tootja");

                    //Label hind = new Label();
                    //hind.SetBinding(Label.TextProperty, "Hind");

                    //return new ViewCell
                    //{
                    //    View = new StackLayout 
                    //    {
                    //        Padding = new Thickness(0,5),
                    //        Orientation = StackOrientation.Vertical,
                    //        Children= {nimetus, tootja, hind }
                    //    }
                    //};
                })
            };
            lisa = new Button { Text = "Lisa riik" };
            kustuta = new Button { Text = "Kustuta riik" };
            lisa.Clicked += Lisa_Clicked;
            kustuta.Clicked += Kustuta_Clicked;
            lbl_list = new Label()
            {
                Text = "riikide loetelu",
                HorizontalOptions = LayoutOptions.Center,
                FontSize = Device.GetNamedSize(NamedSize.Large, typeof(Label))
            };
            
            list.ItemTapped += List_Itemselected;
            this.Content = new StackLayout { Children = {lbl_list, list ,lisa, kustuta} };

        }

        private async void List_Itemselected(object sender, ItemTappedEventArgs e)
        {
           Telefon selectedPhone = e.Item as Telefon;
           if( selectedPhone != null)
            {
                await DisplayAlert("teha model", $"{selectedPhone.Tootja} - {selectedPhone.Nimetus}", "OK");
            }
        }
        private void Kustuta_Clicked(object sender, EventArgs e)
        {
            Telefon phone = list.SelectedItem as Telefon;
            if ( phone != null )
            {
                telefons.Remove(phone);
                list.SelectedItem = null;
            }
        }
        private void Lisa_Clicked(object sender, EventArgs e)
        {
            telefons.Add(new Telefon { Nimetus = "Telefon", Tootja = "Tootja", Hind = 1 });
        }

    }
}