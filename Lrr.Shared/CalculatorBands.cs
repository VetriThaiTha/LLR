using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lrr.Shared
{
    public class CalculatorBands : SimpleCalculator, ICalculator
    {
        private ConfigurationBands configurationBands;

        public CalculatorBands()
            :base()
        {
            configurationBands = new ConfigurationBands();
            base.configuration = configurationBands;
        }

        
    }

    public class CalculatorCurve : SimpleCalculator, ICalculator
    {
        private ConfigurationCurve configurationCurve;

        public CalculatorCurve()
            : base()
        {
            configurationCurve = new ConfigurationCurve();
            base.configuration = configurationCurve;
        }


    }
}
