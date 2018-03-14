﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace GraWżycie
{

    public partial class MainWindow : Window
    {
        Engine engine;
        List<Button> ButtonList;
        public MainWindow()
        {
            InitializeComponent();

            engine = new Engine();

            RozmiarX.TextChanged += new TextChangedEventHandler(XChanged);
            RozmiarY.TextChanged += new TextChangedEventHandler(YChanged);

            SetPlansza(Convert.ToInt32(RozmiarX.Text), Convert.ToInt32(RozmiarY.Text));

            start.Click += new RoutedEventHandler(Start);
        }

        private void XChanged(object sender, EventArgs e)
        {
            var txtbox = (TextBox)sender;
            int x = Convert.ToInt32(txtbox.Text);

            SetPlansza(x, Convert.ToInt32(RozmiarY.Text));
        }

        private void YChanged(object sender, EventArgs e)
        {
            var txtbox = (TextBox)sender;
            int y = Convert.ToInt32(txtbox.Text);

            SetPlansza(Convert.ToInt32(RozmiarX.Text), y);
        }

        private void Start(object sender, EventArgs e)
        {
            engine.game();
            ConvertCells();
        }

        private void OnClick(object sender, EventArgs e)
        {
            int x = -1, y = -1;
            var button = (Button)sender;

            if (button.Background == Brushes.DarkBlue)
                button.Background = Brushes.Gray;
            else
                button.Background = Brushes.DarkBlue;

            GetCord(button.Name, out x, out y);

            engine.cell[y][x] = !engine.cell[y][x];
        }

        private void ConvertCells()
        {
            Button temp;
            for (int i = 1; i < engine.oknoY - 1; i++)
                for (int j = 1; j < engine.oknoX - 1; j++)
                {
                    temp = ButtonList.SingleOrDefault(r => r.Name == "I" + i + "I" + j);
                    if (temp != null)
                    {
                        if (!engine.cell[j][i])
                            temp.Background = Brushes.Gray;
                        else
                            temp.Background = Brushes.DarkBlue;
                    }

                }
        }

        private void GetCord(string name, out int x, out int y)
        {
            string[] Cord = name.Split('I');
            y = Convert.ToInt32(Cord[1]);
            x = Convert.ToInt32(Cord[2]);
        }

        private void SetPlansza(int x, int y)
        {
            Button pole;
            ButtonList = new List<Button>();
            plansza.RowDefinitions.Clear();
            plansza.ColumnDefinitions.Clear();
            plansza.Children.Clear();

            for (int j = 0; j < x; j++)
                plansza.ColumnDefinitions.Add(new ColumnDefinition());

            for (int i = 0; i < y; i++)
                plansza.RowDefinitions.Add(new RowDefinition());

            for (int i = 1; i < y + 1; i++)
                for (int j = 1; j < x + 1; j++)
                {
                    pole = new Button();
                    pole.Background = Brushes.Gray;
                    pole.Name = "I" + i + "I" + j;
                    pole.SetValue(Grid.RowProperty, i - 1);
                    pole.SetValue(Grid.ColumnProperty, j - 1);
                    pole.Click += new RoutedEventHandler(OnClick);
                    pole.Content = pole.Name;
                    ButtonList.Add(pole);

                    plansza.Children.Add(pole);
                }

            engine.set_(x, y, 3, 2, 3, 3);
        }

    }
}