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

        //Передаем с инициализацией класса в него все необходимые данные
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
            if (numGoals != -1)
            {
                Grid next_step_grid = new Grid();
                if (isFirstTime)
                {
                    isFirstTime = false;
                    Way_to_MAINGOAL = Check.Let_find_way(myField, numGoals);
                    Goals = Check.FindGoals(myField);
                }

                if (Way_to_MAINGOAL.Count == 0)
                {
                    MessageBox.Show("Я не смог((");
                    this.Close();

                }
                else
                {
                    myField = for_images.Step_field(step, myField, Way_to_MAINGOAL);
                    Agent = Check.FindMyAgent(myField);
                    for (int i = 0; i < BeginnumGoals; i++)
                    {
                        if (Agent[0] == Goals[0][i] && Agent[1] == Goals[1][i])
                        {
                            numGoals--;
                            Goals[0].RemoveAt(i);
                            Goals[1].RemoveAt(i);
                            BeginnumGoals--;
                        }
                    }
                    next_step_grid = for_images.Fill_field_with_images(myField, numGoals, numObstacles);
                    MainGridField.Children.RemoveAt(0);
                    MainGridField.Children.Insert(0, next_step_grid);
                    if (step < Way_to_MAINGOAL[0].Count - 1)
                    {
                        step++;
                    }
                    else
                    {
                        numGoals = -1;
                    }
                }
            }
            else
            {
                MessageBox.Show("Я закончил!");
            }
        }
    }
}
