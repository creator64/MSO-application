using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Buttons
{
    public class SuperButton
    {
        //this class represents the loadExercise button, when clicked, the command should be triggered

        private readonly ICommand tcommand;
        private (int, int) tlocation;

        public SuperButton(ICommand command, (int, int) location)
        {
            tcommand = command;
            tlocation = location;
        }

        protected void Draw()
        {
            //code to draw a button on screen
        }

        public void Press()
        {
            tcommand.Execute();
        }
    }
}
