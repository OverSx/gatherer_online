using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace gatherer_online_main
{
    class playing_field
    {
        private int field_width;
        private int field_height;
        private int field_stop;
        private int field_goals;

        public playing_field(int field_w, int field_h, int field_s, int field_g)
        {
            field_width = field_w;
            field_height = field_h;
            field_stop = field_s;
            field_goals = field_g;
        }

        public Field generate_field()
        {
            Field field_for_generate = new Field();
            
            for (int i = 0; i <= field_width; i++)
            {
                field_for_generate.Playing_grid.ColumnDefinitions.Add(new ColumnDefinition());
            }

            for (int j = 0; j <= field_height; j++)
            {
                field_for_generate.Playing_grid.RowDefinitions.Add(new RowDefinition());
            }

            field_for_generate.Playing_grid.ShowGridLines = true;


            return field_for_generate;
        }
    }
}
