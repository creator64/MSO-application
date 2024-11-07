using core.ApplicationProgram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Buttons
{
    public class MetricsCommand : ICommand
    {
        private Metrics tmetrics;
        private IDisplay tdisplay;

        public MetricsCommand(IDisplay display)
        {
            tmetrics = new Metrics(0, 0, 0);
            tdisplay = display;
        }

        public void UpdateMetrics(int commandCount, int amountOfRepeats, int maxNestingLevel)
        {
            tmetrics = new Metrics(commandCount, amountOfRepeats, maxNestingLevel);
        }

        public void Execute()
        {
            tdisplay.ShowMetrics(tmetrics);
        }
    }
}
