using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace core.Grid
{
    public class Grid
    {
        public char[,] Cells { get; private set; }
        public int Rows { get; private set; } 
        public int Columns { get; private set; } 
        public (int, int) Finish { get; private set; }

        public Grid(string fp)
        {
            LoadFromFile(fp);
        }

        private void LoadFromFile(string fp)
        {
            //read all lines from a text file and count amount of rows and columns
            string[] lines;
            lines = File.ReadAllLines(fp);
            Rows = lines.Length;
            Columns = lines[0].Length;

            Cells = new char[Rows, Columns];

            //possibly has to be removed/changed to XAML
            for (int y = 0; y < Rows; y++)
            {
                for (int x = 0; x < Columns; x++)
                {
                    Cells[x, y] = lines[x][y]; //change chars in text file to type Cells, keeping the same structure

                    if (Cells[x, y] == 'x') //search the one cell that is the finish
                    {
                        Finish = (x, y); 
                    }
                    Console.Write(lines[x + y]);
                }
                Console.WriteLine();
            }
        }
    }
}
