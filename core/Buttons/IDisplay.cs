using core.ApplicationProgram;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace core.Buttons
{
    public interface IDisplay
    {
        void ShowMetrics(Metrics metrics);
    }
}
