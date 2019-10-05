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
        public Field_filling(int field_w, int field_h, int field_s, int field_g)
        {
            field_size = new int[field_w, field_h];
            numGoals = field_g;
            numObstacles = field_s;

            for (int i = 0; i <= field_w; i++)
            {
                for (int j = 0; j <= field_h; j++)
                {
                    filled_field = [i]
                }
            }
        }
    }
}
