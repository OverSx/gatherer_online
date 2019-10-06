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
using System.Windows.Shapes;

namespace gatherer_online_main
{
    /// <summary>
    /// Логика взаимодействия для Field.xaml
    /// </summary>
    public partial class Field : Window
    {
        public Field()
        {
            InitializeComponent();
        }

        private void bt_playAll_Click(object sender, RoutedEventArgs e)
        {
            Plotter Plot = new Plotter();
            Plot.Let_find_way();
        }

        private void bt_steBYstep_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
