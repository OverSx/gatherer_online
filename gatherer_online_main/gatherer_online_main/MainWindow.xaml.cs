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
        public MainWindow()
        {
            InitializeComponent();
        }

        private void bt_generate_Click(object sender, RoutedEventArgs e)
        {
            playing_field field = new playing_field(int.Parse(tb_width.Text), int.Parse(tb_height.Text), int.Parse(tb_stop.Text), int.Parse(tb_goals.Text));
            Field new_field = field.Generate_field();
            new_field.ShowDialog();
        }
    }
}
