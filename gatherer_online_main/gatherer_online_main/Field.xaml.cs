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
        int[,] myField;
        int numGoals;
        int BeginnumGoals;
        int numObstacles;
        int step = 0;
        bool isFirstTime = true;
        Plotter Check = new Plotter();
        playing_field for_images = new playing_field();
        List<int> Agent = new List<int>();
        List<List<int>> Way_to_MAINGOAL = new List<List<int>>();
        List<List<int>> Goals = new List<List<int>>();

        public Field(int[,] field, int field_goals, int field_stop)
        {
            numGoals = field_goals;
            BeginnumGoals = field_goals;
            numObstacles = field_stop;
            myField = new int[field.GetLength(0), field.GetLength(1)];
            Check.field_filling(myField, field);
            InitializeComponent();           
        }

        private void bt_steBYstep_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
