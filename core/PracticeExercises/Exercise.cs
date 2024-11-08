using core.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.PracticeExercises
{
    public class Exercise
    {
        //this class needs to be able to create a grid on its own, with a certain length and width (finite)
        //it also needs to place the character on a starting spot

        Grid.Grid tgrid;

        //public Character Character { get; } we need to know about the character to check if it has reached the finish line for example

        public Exercise(Grid.Grid grid)
        {
            tgrid = grid;
            //Character = new Character();
        }

        public void CheckPosition()
        {
            //check if the character walks outside the grid
            if (/*condition*/false)
            {
                throw new OutOfBoundsException();
            }

            //check if the character walks to a blocked cell
            if (/*condition*/false)
            {
                throw new BlockedCellException();
            }
        }

        public void CheckSuccess()
        {
            //check if the character has reached the finish line, this method is only called after all the users moves have been applied
            if (/*condition*/false)
            {
                Console.WriteLine("You reached the finish");
            }
            else
            {
                Console.WriteLine("You didn't reach the finish");
            }
        }
    }
}
