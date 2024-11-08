using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Buttons
{
    public class LoadExerciseCommand : ICommand
    {

        public LoadExerciseCommand()
        {
        }

        public void Execute()
        {
            //code for loading the exercise and displaying it in a grid on screen


            //once the button is pressed the state of run changes to an exercise run
            ApplicationProgram.ApplicationProgram.isExercise = true;
        }
    }
}
