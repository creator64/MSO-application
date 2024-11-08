using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Buttons
{
    public class SuperButton
    {
        private readonly ICommand tcommand;
        public SuperButton(ICommand command)
        {
            tcommand = command;
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
