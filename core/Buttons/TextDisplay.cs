using core.ApplicationProgram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Buttons
{
    public class TextDisplay : IDisplay
    {
        public void ShowMetrics(Metrics metrics)
        {
            Console.WriteLine("Command Count: " + metrics.commandCount);
            Console.WriteLine("Amount of Repeats: " + metrics.amountOfRepeats);
            Console.WriteLine("Max Nesting Level: " + metrics.maxNestingLevel);
        }
    }
}
