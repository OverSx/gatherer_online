using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gatherer_online_main
{
    class Plotter
    {
        int[,] field_plotter;

        //public Plotter(int[,] field)
        //{
        //    field_plotter = field;
        //}

        public List<List<int>> Let_find_way(int [,] field, int NumGoals)
        {
            List<List<int>> FinalWay = new List<List<int>>();
            List<int> FinalWayX = new List<int>();
            List<int> FinalWayY = new List<int>();
            List<int> collected_goalX = new List<int>();
            List<int> collected_goalY = new List<int>();
            List<int> Agent = new List<int>();
            int[,] newField = new int[field.GetLength(0), field.GetLength(1)];
            field_filling(newField, field);
            Agent = FindMyAgent(newField);

            for (int i = 0; i < NumGoals; i++)
            {
                FinalWay = Waves(newField);

                if (FinalWay.Count == 0)
                {
                    return FinalWay;
                }

                for (int j = 0; j < FinalWay[0].Count; j++)
                {
                    FinalWayX.Add(FinalWay[0][j]);
                    FinalWayY.Add(FinalWay[1][j]);
                }
                collected_goalX.Add(FinalWayX[FinalWayX.Count - 1]);
                collected_goalY.Add(FinalWayY[FinalWayY.Count - 1]);
                field_filling(newField, field);
                newField[Agent[0], Agent[1]] = 0;
                for(int k = 0; k < collected_goalX.Count; k++)
                {
                    newField[collected_goalX[k], collected_goalY[k]] = 0;
                }
                newField[FinalWayX[FinalWayX.Count - 1], FinalWayY[FinalWayY.Count - 1]] = 4;
            }

            //Собрал все цели, кроме последней и имею два списка, один содержит x - координаты, другой - y координаты движения агента
            //Теперь надо дойти до последней цели и занести в список координаты передвижения моего агента
            FinalWay = Last_wave(newField);
            if (FinalWay.Count == 0)
            {
                return FinalWay;
            }

            for (int j = 0; j < FinalWay[0].Count; j++)
            {
                FinalWayX.Add(FinalWay[0][j]);
                FinalWayY.Add(FinalWay[1][j]);
            }
            //Кладем обратно в переменную Final_Way весь наш путь
            FinalWay[0] = FinalWayX;
            FinalWay[1] = FinalWayY;

            return FinalWay;
        }

        public List<int> FindMyAgent(int [,] field)
        {
            List<int> AgentCoord = new List<int>();
            bool AgentCoordIsFind = false;

            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i, j] == 4)
                    {
                        AgentCoord.Add(i);
                        AgentCoord.Add(j);
                        AgentCoordIsFind = true;
                        break;
                    }
                }
                if (AgentCoordIsFind)
                {
                    break;
                }
            }

            return AgentCoord;
        }

        public List<List<int>> FindGoals(int[,] field)
        {
            List<List<int>> Goals = new List<List<int>>();
            List<int> GoalsX = new List<int>();
            List<int> GoalsY = new List<int>();

            for (int i = 0; i < field.GetLength(0); i++)
            {
                for (int j = 0; j < field.GetLength(1); j++)
                {
                    if (field[i, j] == 1)
                    {
                        GoalsX.Add(i);
                        GoalsY.Add(j);
                    }
                }
            }
            Goals.Add(GoalsX);
            Goals.Add(GoalsY);

            return Goals;
        }

        private List<List<int>> Waves(int [,] field)
        {
            int[,] newField = field;
            List<List<int>> WayIsHere = new List<List<int>>();
            List<int> WaytoGoalX = new List<int>();
            List<int> WaytoGoalY = new List<int>();
            bool add = true;
            bool WayIsExist = false;
            int step = 4;
            List<int> Agent = new List<int>();
            List<int> GoalsX = new List<int>();
            List<int> GoalsY = new List<int>();

            while (add)
            {
                WayIsExist = false;
                add = false;
                for (int i = 0; i < newField.GetLength(0); i++)
                {
                    for(int j = 0; j < newField.GetLength(1); j++)
                    {
                        if(newField[i,j] == step)
                        {
                            if (i - 1 >= 0 && newField[i - 1, j] != 3)
                            {
                                if (newField[i - 1, j] == 1)
                                {
                                    GoalsX.Add(i - 1);
                                    GoalsY.Add(j);
                                    WayIsExist = true;
                                }
                                if (newField[i - 1, j] == 0)
                                {
                                    newField[i - 1, j] = step + 1;
                                    WayIsExist = true;
                                }
                            }

                            if (j - 1 >= 0 && newField[i, j - 1] != 3)
                            {
                                if (newField[i, j - 1] == 1)
                                {
                                    GoalsX.Add(i);
                                    GoalsY.Add(j - 1);
                                    WayIsExist = true;
                                }
                                if (newField[i, j - 1] == 0)
                                {
                                    newField[i, j - 1] = step + 1;
                                    WayIsExist = true;
                                }
                            }

                            if (i + 1 < newField.GetLength(0) && newField[i + 1, j] != 3)
                            {
                                if (newField[i + 1, j] == 1)
                                {
                                    GoalsX.Add(i + 1);
                                    GoalsY.Add(j);
                                    WayIsExist = true;
                                }
                                if (newField[i + 1, j] == 0)
                                {
                                    newField[i + 1, j] = step + 1;
                                    WayIsExist = true;
                                }
                            }

                            if (j + 1 < newField.GetLength(1) && newField[i, j + 1] != 3)
                            {
                                if (newField[i, j + 1] == 1)
                                {
                                    GoalsX.Add(i);
                                    GoalsY.Add(j + 1);
                                    WayIsExist = true;
                                }
                                if (newField[i, j + 1] == 0)
                                {
                                    newField[i, j + 1] = step + 1;
                                    WayIsExist = true;
                                }
                            }
                        }
                    }
                }
                if (WayIsExist == false)
                {
                    break;
                }
                add = true;
                if (GoalsX.Count != 0)
                {
                    break;
                }
                step++;
            }

            if (WayIsExist == false)
            {
                return WayIsHere;
            }
            Agent = FindMyAgent(newField);
            WayIsHere = finding_way(newField, GoalsX[0], GoalsY[0], Agent[0], Agent[1], step);
            return WayIsHere;
        }

        private List<List<int>> Last_wave(int[,] field)
        {
            int[,] newField = field;
            List<List<int>> WayIsHere = new List<List<int>>();
            List<int> WaytoGoalX = new List<int>();
            List<int> WaytoGoalY = new List<int>();
            bool add = true;
            bool WayIsExist = false;
            int step = 4;
            List<int> Agent = new List<int>();
            List<int> GoalsX = new List<int>();
            List<int> GoalsY = new List<int>();

            while (add)
            {
                WayIsExist = false;
                add = false;
                for (int i = 0; i < newField.GetLength(0); i++)
                {
                    for (int j = 0; j < newField.GetLength(1); j++)
                    {
                        if (newField[i, j] == step)
                        {
                            if (i - 1 >= 0 && newField[i - 1, j] != 3)
                            {
                                if (newField[i - 1, j] == 2)
                                {
                                    GoalsX.Add(i - 1);
                                    GoalsY.Add(j);
                                    WayIsExist = true;
                                }
                                if (newField[i - 1, j] == 0)
                                {
                                    newField[i - 1, j] = step + 1;
                                    WayIsExist = true;
                                }
                            }

                            if (j - 1 >= 0 && newField[i, j - 1] != 3)
                            {
                                if (newField[i, j - 1] == 2)
                                {
                                    GoalsX.Add(i);
                                    GoalsY.Add(j - 1);
                                    WayIsExist = true;
                                }
                                if (newField[i, j - 1] == 0)
                                {
                                    newField[i, j - 1] = step + 1;
                                    WayIsExist = true;
                                }
                            }

                            if (i + 1 < newField.GetLength(0) && newField[i + 1, j] != 3)
                            {
                                if (newField[i + 1, j] == 2)
                                {
                                    GoalsX.Add(i + 1);
                                    GoalsY.Add(j);
                                    WayIsExist = true;
                                }
                                if (newField[i + 1, j] == 0)
                                {
                                    newField[i + 1, j] = step + 1;
                                    WayIsExist = true;
                                }
                            }

                            if (j + 1 < newField.GetLength(1) && newField[i, j + 1] != 3)
                            {
                                if (newField[i, j + 1] == 2)
                                {
                                    GoalsX.Add(i);
                                    GoalsY.Add(j + 1);
                                    WayIsExist = true;
                                }
                                if (newField[i, j + 1] == 0)
                                {
                                    newField[i, j + 1] = step + 1;
                                    WayIsExist = true;
                                }
                            }
                        }
                    }
                }
                if (WayIsExist == false)
                {
                    break;
                }
                add = true;
                if (GoalsX.Count != 0)
                {
                    break;
                }
                step++;
            }

            if (WayIsExist == false)
            {
                return WayIsHere;
            }
            Agent = FindMyAgent(newField);
            WayIsHere = finding_way(newField, GoalsX[0], GoalsY[0], Agent[0], Agent[1], step);
            return WayIsHere;
        }

        private List<List<int>> finding_way(int [,]field, int GoalX, int GoalY, int AgentX, int AgentY, int step)
        {
            List<List<int>> WAY = new List<List<int>>();
            int[,] newField = field;
            int Up, Down, Left, Right;
            int Agent_x = GoalX;
            int Agent_y = GoalY;
            int NextStep = step;
            List<int> WayX = new List<int>();
            List<int> WayY = new List<int>();


            while (Agent_x != AgentX || Agent_y != AgentY)
            {
                Up = -50;
                Down = -50;
                Left = -50;
                Right = -50;
                WayX.Add(Agent_x);
                WayY.Add(Agent_y);

                if (Agent_x - 1 >= 0)
                {
                    Up = newField[Agent_x - 1, Agent_y];
                }
                if (Agent_x + 1 < newField.GetLength(0))
                {
                    Down = newField[Agent_x + 1, Agent_y];
                }
                if (Agent_y - 1 >= 0)
                {
                    Left = newField[Agent_x, Agent_y - 1];
                }
                if (Agent_y + 1 < newField.GetLength(1))
                {
                    Right = newField[Agent_x, Agent_y + 1];
                }

                if (NextStep == Up)
                {
                    Agent_x = Agent_x - 1;
                }
                else if (NextStep == Down)
                {
                    Agent_x = Agent_x + 1;
                }
                else if (NextStep == Left)
                {
                    Agent_y = Agent_y - 1;
                }
                else if (NextStep == Right)
                {
                    Agent_y = Agent_y + 1;
                }
                else
                {
                    return WAY;
                }
                NextStep--;
            }

            WayX.Reverse();
            WayY.Reverse();
            WAY.Add(WayX);
            WAY.Add(WayY);

            return WAY;
        }

        public void field_filling(int [,] recipient, int [,] donor)
        {
            for (int i = 0; i < donor.GetLength(0); i++)
            {
                for (int j = 0; j < donor.GetLength(1); j++)
                {
                    recipient[i,j] = donor[i,j];
                }
            }
        }
    }
}
