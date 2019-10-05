using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace gatherer_online_main
{
    class Field_filling
    {
        // 0 - empty
        // 1 - goal
        // 2 - final goal
        // 3 - obstacle cell
        // 4 - agent

        int[,] field_size;
        int numGoals;
        int numObstacles;

        Random rand = new Random();
        int[,] filled_field;

        private List<int> Coordinates(int field_w, int field_h)
        {
            int x = rand.Next(field_w + 1);
            int y = rand.Next(field_h + 1);

            List<int> coordinates = new List<int> {x, y};

            return coordinates;
        }

        public Field_filling(int field_w, int field_h, int field_s, int field_g)
        {
            field_size = new int[field_w, field_h];
            numGoals = field_g;
            numObstacles = field_s;

            List<int> agent_coord = Coordinates(field_w, field_h);
            for (int i = 0; i <= field_w; i++)
            {
                for (int j = 0; j <= field_h; j++)
                {
                    if (i == agent_coord[0] && j == agent_coord[1])
                    {
                        filled_field[i, j] = 4;
                    }

                    filled_field[i, j] = 0;
                }
            }

            List<int> final_goal_coord = Coordinates(field_w, field_h);
            
            if (filled_field[final_goal_coord[0], final_goal_coord[1]] == 0)
            {
                filled_field[final_goal_coord[0], final_goal_coord[1]] = 2;
            }
            else
            {
                while(filled_field[final_goal_coord[0], final_goal_coord[1]] != 0)
                {
                    final_goal_coord = Coordinates(field_w, field_h);
                }

                filled_field[final_goal_coord[0], final_goal_coord[1]] = 2;
            }

            }
        }
    }
}
