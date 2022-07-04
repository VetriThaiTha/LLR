using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lrr.Shared
{
    public class SimpleConfiguration : IConfiguration
    {
        public SimpleConfiguration()
        {
            StampChargePercentage = 7.0;
            RegistrationChargePercentage = 1.0;
            AuctionDuration = 3;
            StartingValueMultiple = 1.25;
            StepValueMultiple = 0.02;
        }

        public double StampChargePercentage { get; set; }
        public double RegistrationChargePercentage { get; set; }

        public int AuctionDuration { get; set; }
        public double StartingValueMultiple { get; set; }
        public double StepValueMultiple { get; set; }
    }
}
