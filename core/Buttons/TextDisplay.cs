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
            string stringMetrics = metrics.commandCount.ToString();
            string stringAmountOfRepeats = metrics.amountOfRepeats.ToString();
            string stringMaxNestingLevel = metrics.maxNestingLevel.ToString();

            Console.WriteLine("commandCount: " + metrics.commandCount);
            Console.WriteLine("amountOfRepeats: " + metrics.amountOfRepeats);
            Console.WriteLine("maxNestingLevel: " + metrics.maxNestingLevel);
        }
    }
}
