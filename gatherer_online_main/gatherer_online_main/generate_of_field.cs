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

        private int[,] field;
        Field_filling field_with_elem;

        //public playing_field(int field_w, int field_h, int field_s, int field_g)
        //{
        //    field_width = field_w;
        //    field_height = field_h;
        //    field_stop = field_s;
        //    field_goals = field_g;
        //}

        public Grid grid { private set; get; }

        public Grid Fill_field_with_images(int [,] field, int field_g, int field_s)
        {
            Grid myGrid = new Grid();

            for (int i = 0; i < field.GetLength(0); i++)
            {
                myGrid.RowDefinitions.Add(new RowDefinition());
            }

            for (int j = 0; j < field.GetLength(1); j++)
            {
                myGrid.ColumnDefinitions.Add(new ColumnDefinition());
            }
            myGrid.ShowGridLines = true;
            myGrid.Height = 500;
            myGrid.Width = 492;
            myGrid.VerticalAlignment = VerticalAlignment.Top;
            myGrid.HorizontalAlignment = HorizontalAlignment.Left;


            myGrid.Children.Add(Final_goal(field));

            List<Image> myObstacles = Obstacles(field, field_s);
            for (int i = 0; i < field_s; i++)
            {
                myGrid.Children.Add(myObstacles[i]);
            }

            List<Image> myGoals = Goals(field, field_g);
            for (int i = 0; i < field_g; i++)
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
            bool bryaka = false;

            for (int i = 0; i < filled_field.GetLength(0); i++)
            {
                for (int j = 0; j < filled_field.GetLength(1); j++)
                {
                    if (filled_field[i, j] == 4)
                    {
                        x = i;
                        y = j;
                        bryaka = true;
                        break;
                    }
                }
                if(bryaka)
                {
                    break;
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
            bool bryaka = false;
            bool finalGoalIsExist = false;

            for (int i = 0; i < filled_field.GetLength(0); i++)
            {
                for (int j = 0; j < filled_field.GetLength(1); j++)
                {
                    if (filled_field[i, j] == 2)
                    {
                        x = i;
                        y = j;
                        finalGoalIsExist = true;
                        bryaka = true;
                        break;
                    }
                }
                if (bryaka)
                {
                    break;
                }
            }
            if(finalGoalIsExist == false)
            {
                return final_goal;
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

        private List<Image> Obstacles(int[,] filled_field, int field_s)
        {
            List<Image> obstacles = new List<Image>();
            List<int> obstaclesX = new List<int>();
            List<int> obstaclesY = new List<int>();

            BitmapImage forObstacles = new BitmapImage();
            forObstacles.BeginInit();
            forObstacles.UriSource = new Uri("Properties/stop_signal.png", UriKind.Relative);
            forObstacles.EndInit();

            for (int i = 0; i < field_s; i++)
            {
                Image obstacle = new Image();
                obstacles.Add(obstacle);
            }

            for(int i = 0; i < filled_field.GetLength(0); i++)
            {
                for (int j = 0; j < filled_field.GetLength(1); j++)
                {
                    if (filled_field[i,j] == 3)
                    {
                        obstaclesX.Add(i);
                        obstaclesY.Add(j);
                    }
                }
            }

            for(int i = 0; i < field_s; i++)
            {
                obstacles[i].Stretch = Stretch.Fill;
                obstacles[i].Source = forObstacles;
                obstacles[i].SetValue(Grid.RowProperty, obstaclesX[i]);
                obstacles[i].SetValue(Grid.ColumnProperty, obstaclesY[i]);
            }

            return obstacles;
        }

        private List<Image> Goals(int[,] filled_field, int field_g)
        {
            List<Image> goals = new List<Image>();
            List<int> goalsX = new List<int>();
            List<int> goalsY = new List<int>();

            BitmapImage forGoals = new BitmapImage();
            forGoals.BeginInit();
            forGoals.UriSource = new Uri("Properties/goal.jpg", UriKind.Relative);
            forGoals.EndInit();

            for (int i = 0; i < field_g; i++)
            {
                Image goal = new Image();
                goals.Add(goal);
            }

            for (int i = 0; i < filled_field.GetLength(0); i++)
            {
                for (int j = 0; j < filled_field.GetLength(1); j++)
                {
                    if (filled_field[i, j] == 1)
                    {
                        goalsX.Add(i);
                        goalsY.Add(j);
                    }
                }
            }
            if (goalsX.Count == 0)
            {
                field_g = 0;
            }

            for (int i = 0; i < field_g; i++)
            {
                goals[i].Stretch = Stretch.Fill;
                goals[i].Source = forGoals;
                goals[i].SetValue(Grid.RowProperty, goalsX[i]);
                goals[i].SetValue(Grid.ColumnProperty, goalsY[i]);
            }

            return goals;
        }

        public Field Generate_field(int field_w, int field_h, int field_s, int field_g)
        {
            Grid newGrid = new Grid();

            field_with_elem = new Field_filling(field_w, field_h, field_s, field_g);
            field = field_with_elem.MyField(field_w, field_h, field_s, field_g);

            Field field_for_generate = new Field(field, field_g, field_s);

            newGrid = Fill_field_with_images(field, field_g, field_s);
            field_for_generate.MainGridField.Children.RemoveAt(0);
            field_for_generate.MainGridField.Children.Insert(0, newGrid);

            return field_for_generate;
        }

        public int[,] GetField()
        {
            return field;
        }

        public int[,] Step_field(int step, int [,] this_is_current_field, List<List<int>> list_with_way)
        {
            bool AgentCoordIsFind = false;
            int [,] tempField = this_is_current_field;

            for (int i = 0; i < tempField.GetLength(0); i++)
            {
                for (int j = 0; j < tempField.GetLength(1); j++)
                {
                    if (tempField[i, j] == 4)
                    {
                        tempField[i, j] = 0;
                        AgentCoordIsFind = true;
                        break;
                    }
                }
                if (AgentCoordIsFind)
                {
                    break;
                }
            }
            if (list_with_way[0].Count != step)
            {
                tempField[list_with_way[0][step], list_with_way[1][step]] = 4;
            }

            return tempField;
        }
    }
}
