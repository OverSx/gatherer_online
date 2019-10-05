using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;

namespace gatherer_online_main
{
    class playing_field
    {
        private int field_width;
        private int field_height;
        private int field_stop;
        private int field_goals;
        private int[,] field;
        Field_filling field_with_elem;

        public playing_field(int field_w, int field_h, int field_s, int field_g)
        {
            field_width = field_w;
            field_height = field_h;
            field_stop = field_s;
            field_goals = field_g;
        }

        public Grid grid { private set; get; }

        private Grid Fill_field_with_images(int [,] field)
        {
            Grid myGrid = new Grid();

            for (int i = 0; i < field_width; i++)
            {
                myGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int j = 0; j < field_height; j++)
            {
                myGrid.RowDefinitions.Add(new RowDefinition());
            }
            myGrid.ShowGridLines = true;
            myGrid.Height = 500;
            myGrid.Width = 492;
            myGrid.VerticalAlignment = VerticalAlignment.Top;
            myGrid.HorizontalAlignment = HorizontalAlignment.Left;
            myGrid.SetValue(Grid.ColumnProperty, 1);


            myGrid.Children.Add(Final_goal(field));

            List<Image> myObstacles = Obstacles(field);
            for (int i = 0; i < field_stop; i++)
            {
                myGrid.Children.Add(myObstacles[i]);
            }

            List<Image> myGoals = Goals(field);
            for (int i = 0; i < field_goals; i++)
            {
                myGrid.Children.Add(myGoals[i]);
            }

            myGrid.Children.Add(Agent(field));

            this.grid = myGrid;

            return myGrid;
        }

        private Image Agent(int[,] filled_field)
        {
            Image agent = new Image();

            int x = 0;
            int y = 0;

            for (int i = 0; i < field_width; i++)
            {
                for (int j = 0; j < field_height; j++)
                {
                    if (filled_field[i, j] == 4)
                    {
                        x = i;
                        y = j;
                    }
                }
            }

            BitmapImage forAgent = new BitmapImage();
            forAgent.BeginInit();
            forAgent.UriSource = new Uri("Properties/Joy.PNG", UriKind.Relative);
            forAgent.EndInit();
            agent.Stretch = Stretch.Fill;
            agent.Source = forAgent;

            agent.SetValue(Grid.RowProperty, x);
            agent.SetValue(Grid.ColumnProperty, y);

            return agent;
        }

        private Image Final_goal(int[,] filled_field)
        {
            Image final_goal = new Image();

            int x = 0;
            int y = 0;

            for (int i = 0; i < field_width; i++)
            {
                for (int j = 0; j < field_height; j++)
                {
                    if (filled_field[i, j] == 2)
                    {
                        x = i;
                        y = j;
                    }
                }
            }

            BitmapImage forfinal_goal = new BitmapImage();
            forfinal_goal.BeginInit();
            forfinal_goal.UriSource = new Uri("Properties/final_goal.jpg", UriKind.Relative);
            forfinal_goal.EndInit();
            final_goal.Stretch = Stretch.Fill;
            final_goal.Source = forfinal_goal;

            final_goal.SetValue(Grid.RowProperty, x);
            final_goal.SetValue(Grid.ColumnProperty, y);

            return final_goal;
        }

        private List<Image> Obstacles(int[,] filled_field)
        {
            List<Image> obstacles = new List<Image>();
            List<int> obstaclesX = new List<int>();
            List<int> obstaclesY = new List<int>();

            BitmapImage forObstacles = new BitmapImage();
            forObstacles.BeginInit();
            forObstacles.UriSource = new Uri("Properties/stop_signal.png", UriKind.Relative);
            forObstacles.EndInit();

            for (int i = 0; i < field_stop; i++)
            {
                Image obstacle = new Image();
                obstacles.Add(obstacle);
            }

            for(int i = 0; i < field_width; i++)
            {
                for (int j = 0; j < field_height; j++)
                {
                    if (filled_field[i,j] == 3)
                    {
                        obstaclesX.Add(i);
                        obstaclesY.Add(j);
                    }
                }
            }

            for(int i = 0; i < field_stop; i++)
            {
                obstacles[i].Stretch = Stretch.Fill;
                obstacles[i].Source = forObstacles;
                obstacles[i].SetValue(Grid.RowProperty, obstaclesX[i]);
                obstacles[i].SetValue(Grid.ColumnProperty, obstaclesY[i]);
            }

            return obstacles;
        }

        private List<Image> Goals(int[,] filled_field)
        {
            List<Image> goals = new List<Image>();
            List<int> goalsX = new List<int>();
            List<int> goalsY = new List<int>();

            BitmapImage forGoals = new BitmapImage();
            forGoals.BeginInit();
            forGoals.UriSource = new Uri("Properties/goal.jpg", UriKind.Relative);
            forGoals.EndInit();

            for (int i = 0; i < field_goals; i++)
            {
                Image obstacle = new Image();
                goals.Add(obstacle);
            }

            for (int i = 0; i < field_width; i++)
            {
                for (int j = 0; j < field_height; j++)
                {
                    if (filled_field[i, j] == 1)
                    {
                        goalsX.Add(i);
                        goalsY.Add(j);
                    }
                }
            }

            for (int i = 0; i < field_goals; i++)
            {
                goals[i].Stretch = Stretch.Fill;
                goals[i].Source = forGoals;
                goals[i].SetValue(Grid.RowProperty, goalsX[i]);
                goals[i].SetValue(Grid.ColumnProperty, goalsY[i]);
            }

            return goals;
        }

        public Field Generate_field()
        {
            Field field_for_generate = new Field();
            Grid newGrid = new Grid();

            field_with_elem = new Field_filling(field_width, field_height, field_stop, field_goals);
            field = field_with_elem.MyField(field_width, field_height, field_stop, field_goals);

            newGrid = Fill_field_with_images(field);
            field_for_generate.MainGridField.Children.RemoveAt(0);
            field_for_generate.MainGridField.Children.Insert(0, newGrid);

            return field_for_generate;
        }
    }
}
