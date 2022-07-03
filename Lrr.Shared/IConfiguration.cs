using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lrr.Shared
{
    public interface IConfiguration
    {
        
        public double StampChargePercentage { get; set; }
        public double RegistrationChargePercentage { get; set; }

        
    }
}
