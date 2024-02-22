using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace mobile2
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class nullidjaristkud : ContentPage
    {
        //Grid grid;
        //public nullidjaristkud()
        //{
        //     grid= new Grid
        //     {
        //         BackgroundColor = Color.DarkGreen,
        //         HorizontalOptions = LayoutOptions.FillAndExpand,
        //         VerticalOptions = LayoutOptions.FillAndExpand,
        //     };
        //    TapGestureRecognizer tap = new TapGestureRecognizer();
        //    tap.Tapped += Tap_tapped;
        //    tap.NumberOfTapsRequired = 1;

        //    for (int i = 0; i < 3; i++)
        //    {
        //        grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
        //        grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });
        //    }
        //    Content = grid;

        //}

        //private void Tap_tapped(object sender, EventArgs e)
        //{
        //    throw new NotImplementedException();
        //}

        private Grid grid;
        private Button[,] buttons;
        private bool isPlayerXTurn;

        public nullidjaristkud()
        {
            InitializeComponent();
            InitializeGrid();
            ResetGame();
            InitializeLayout();




        }
        private void InitializeLayout()
        {
            
            var layout = new StackLayout();

            // Кнопка для случайного выбора первого игрока
            var backrgrounf = new Button 
            {
                Text ="vali teemat"
            };
            backrgrounf.Clicked += asdadda;
            layout.Children.Add(backrgrounf);
            var rulesButton = new Button
            {
                Text = "näita reeglid"
            };
            rulesButton.Clicked += RulesButton_Clicked;
            layout.Children.Add(rulesButton);
            var randomPlayerButton = new Button
            {
                Text = "Random esimene mängija"
            };
            randomPlayerButton.Clicked += RandomPlayerButton_Clicked;
            layout.Children.Add(randomPlayerButton);

            // Кнопка для начала новой игры
            var newGameButton = new Button
            {
                Text = "uus mäng"
            };
            newGameButton.Clicked += NewGameButton_Clicked;
            layout.Children.Add(newGameButton);

            // Добавляем разметку с кнопками и сетку на страницу
            layout.Children.Add(grid);
            Content = layout;
        }

        private void asdadda(object sender, EventArgs e)
        {
            Random rnd = new Random();
            int r = rnd.Next(0, 255);
            int g = rnd.Next(0, 255);
            int b = rnd.Next(0, 255);
            grid.BackgroundColor = Color.FromRgb(r, g, b);
            
        }

        private void RulesButton_Clicked(object sender, EventArgs e)
        {
             DisplayAlert("reeglid", "Mängureeglid: Kaks mängijat asetavad kordamööda oma sümbolid (X või O) 3x3 mänguväljale. Võidab mängija, kes reastab oma sümbolid esimesena samale horisontaalsele, vertikaalsele või diagonaaljoonele.", "OK");
        }

        private void NewGameButton_Clicked(object sender, EventArgs e)
        {
            ResetGame();
        }

        private void RandomPlayerButton_Clicked(object sender, EventArgs e)
        {
            Random random = new Random();
            isPlayerXTurn = random.Next(2) == 0;

           
        }

        private void InitializeGrid()
        {
            grid = new Grid
            {
                BackgroundColor = Color.DarkGreen,
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
            };

            buttons = new Button[3, 3];

            for (int i = 0; i < 3; i++)
            {
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) });

                for (int j = 0; j < 3; j++)
                {
                    var button = new Button
                    {
                        FontSize = 30,
                        CommandParameter = (i, j)
                    };
                    button.Clicked += Button_Clicked;

                    buttons[i, j] = button;
                    grid.Children.Add(button, j, i);
                }
            }
            Content = grid;
        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            var button = (Button)sender;
            var (row, column) = (ValueTuple<int, int>)button.CommandParameter;
            if (button.Text == "")
            {
                button.Text = isPlayerXTurn ? "X" : "O";
                button.IsEnabled = false;

                if (CheckForWin(row,column,isPlayerXTurn ? "X": "O"))
                {
                    DisplayAlert("Mäng lõppes", (isPlayerXTurn ? "X" : "O") + " võitis!", "OK");
                    ResetGame();
                    return;
                }
                if (isPlayerXTurn = !isPlayerXTurn) ;
            }
        }

        private bool CheckForWin(int row, int column, string v)
        {
            if (buttons[row, 0].Text == v && buttons[row, 1].Text == v && buttons[row, 2].Text == v)
                return true;

            // Проверка по вертикали
            if (buttons[0, column].Text == v && buttons[1, column].Text == v && buttons[2, column].Text == v)
                return true;

            // Проверка по диагоналям
            if ((buttons[0, 0].Text == v && buttons[1, 1].Text == v && buttons[2, 2].Text == v) ||
            (buttons[0, 2].Text == v && buttons[1, 1].Text == v && buttons[2, 0].Text == v))
                return true;
            return false;
        }

        private void ResetGame()
        {
            isPlayerXTurn = true;
            foreach (var button in buttons)
            {
                button.Text = "";
                button.IsEnabled = true;
            }
        }
    }
}