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

        public Plotter(int[,] field)
        {
            field_plotter = field;
        }

        public void Let_find_way()
        {

        }
        private List<int> FindMyAgent()
        {
            List<int> AgentCoord = new List<int>();
            bool AgentCoordIsFind = false;

            for (int i = 0; i < field_plotter.GetLength(0); i++)
            {
                for (int j = 0; j < field_plotter.GetLength(1); j++)
                {
                    if (field_plotter[i, j] == 4)
                    {
                        AgentCoord[0] = i;
                        AgentCoord[1] = j;
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
    }
}
