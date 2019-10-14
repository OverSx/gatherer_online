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

        int[,] filled_field;
        int[,] field_size;
        int numGoals;
        int numObstacles;

        Random rand = new Random();

        //Функция для рандома координат
        private List<int> Coordinates(int field_w, int field_h)
        {
            int x = rand.Next(field_h);
            int y = rand.Next(field_w);

            List<int> coordinates = new List<int> {x, y};

            return coordinates;
        }

        //Заполнение поля предметами
        private int[,] Filling(int field_w, int field_h, int field_s, int field_g)
        {
            filled_field = new int[field_h, field_w];
            numGoals = field_g;
            numObstacles = field_s;

            //Агент и проходы
            List<int> agent_coord = Coordinates(field_w, field_h);

            for (int i = 0; i < field_h; i++)
            {
                for (int j = 0; j < field_w; j++)
                {
                    if (i == agent_coord[0] && j == agent_coord[1])
                    {
                        filled_field[i, j] = 4;
                        continue;
                    }

                    filled_field[i, j] = 0;
                }
            }

            // Конечная цель
            List<int> final_goal_coord = Coordinates(field_w, field_h);

            while (filled_field[final_goal_coord[0], final_goal_coord[1]] != 0)
            {
                final_goal_coord = Coordinates(field_w, field_h);
            }

            filled_field[final_goal_coord[0], final_goal_coord[1]] = 2;

            //Преграды
            List<int> Obstacles_coord = Coordinates(field_w, field_h);

            for (int num = 0; num < numObstacles; num++)
            {
                while (filled_field[Obstacles_coord[0], Obstacles_coord[1]] != 0)
                {
                    Obstacles_coord = Coordinates(field_w, field_h);
                }

                filled_field[Obstacles_coord[0], Obstacles_coord[1]] = 3;
            }

            //Цели
            List<int> Goals_coord = Coordinates(field_w, field_h);

            for (int num = 0; num < numGoals; num++)
            {
                while (filled_field[Goals_coord[0], Goals_coord[1]] != 0)
                {
                    Goals_coord = Coordinates(field_w, field_h);
                }

                filled_field[Goals_coord[0], Goals_coord[1]] = 1;
            }

            return filled_field;
        }

        //Инициализация класса
        public Field_filling(int field_w, int field_h, int field_s, int field_g)
        {
            field_size = new int[field_h, field_w];
            numGoals = field_g;
            numObstacles = field_s;

        }

        //Вызов функции из окна
        public int[,] MyField(int field_w, int field_h, int field_s, int field_g)
        {
            filled_field = Filling(field_w, field_h, field_s, field_g);
            return filled_field;
        }
    }
}
