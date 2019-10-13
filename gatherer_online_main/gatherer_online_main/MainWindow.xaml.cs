using System;
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

namespace gatherer_online_main
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool IsNumber = false;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void bt_generate_Click(object sender, RoutedEventArgs e)
        {
            if (int.Parse(tb_width.Text) < 3 || int.Parse(tb_height.Text) < 3)
            {
                WarningWindow Warn = new WarningWindow();
                Warn.ShowDialog();
            }
            else if (int.Parse(tb_stop.Text) + int.Parse(tb_goals.Text) - 2 > int.Parse(tb_width.Text) * int.Parse(tb_height.Text))
            {
                WarningWindow Warn = new WarningWindow();
                Warn.ShowDialog();
            }
            else
            {
                playing_field field = new playing_field();
                Field new_field = field.Generate_field(int.Parse(tb_width.Text), int.Parse(tb_height.Text), int.Parse(tb_stop.Text), int.Parse(tb_goals.Text));
                new_field.ShowDialog();
            }
        }

        private void tb_width_KeyDown(object sender, KeyEventArgs e)
        {
            IsNumber = false;
            if (e.Key < Key.D0 || e.Key > Key.D9 || e.Key == Key.Back)
            {
                if (e.Key < Key.NumPad0 || e.Key > Key.NumPad9)
                {
                    IsNumber = true;
                }
            }
            if (e.Key == Key.Space)
            {

            }
            if (IsNumber)
            {
                e.Handled = true;
            }

        }

        private void tb_height_KeyDown(object sender, KeyEventArgs e)
        {
            IsNumber = false;
            if (e.Key < Key.D0 || e.Key > Key.D9 || e.Key == Key.Back)
            {
                if (e.Key < Key.NumPad0 || e.Key > Key.NumPad9)
                {
                    IsNumber = true;
                }
            }
            if (e.Key == Key.Space)
            {

            }
            if (IsNumber)
            {
                e.Handled = true;
            }
        }

        private void tb_stop_KeyDown(object sender, KeyEventArgs e)
        {
            IsNumber = false;
            if (e.Key < Key.D0 || e.Key > Key.D9 || e.Key == Key.Back)
            {
                if (e.Key < Key.NumPad0 || e.Key > Key.NumPad9)
                {
                    IsNumber = true;
                }
            }
            if (e.Key == Key.Space)
            {

            }
            if (IsNumber)
            {
                e.Handled = true;
            }
        }

        private void tb_goals_KeyDown(object sender, KeyEventArgs e)
        {
            IsNumber = false;
            if (e.Key < Key.D0 || e.Key > Key.D9 || e.Key == Key.Back)
            {
                if (e.Key < Key.NumPad0 || e.Key > Key.NumPad9)
                {
                    IsNumber = true;
                }
            }
            if (e.Key == Key.Space)
            {

            }
            if (IsNumber)
            {
                e.Handled = true;
            }
        }

        private void tb_width_TextChanged(object sender, TextChangedEventArgs e)
        {
            tb_width.Text = tb_width.Text.Replace(" ", "");
            tb_width.SelectionStart = tb_width.Text.Length;
        }

        private void tb_height_TextChanged(object sender, TextChangedEventArgs e)
        {
            tb_height.Text = tb_height.Text.Replace(" ", "");
            tb_height.SelectionStart = tb_height.Text.Length;
        }

        private void tb_stop_TextChanged(object sender, TextChangedEventArgs e)
        {
            tb_stop.Text = tb_stop.Text.Replace(" ", "");
            tb_stop.SelectionStart = tb_stop.Text.Length;
        }

        private void tb_goals_TextChanged(object sender, TextChangedEventArgs e)
        {
            tb_goals.Text = tb_goals.Text.Replace(" ", "");
            tb_goals.SelectionStart = tb_goals.Text.Length;
        }
    }
}

