using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lrr.Shared
{
    public interface IConfiguration
    {
        
        public double StampChargePercentage { get;  }
        public double RegistrationChargePercentage { get;  }

        public int AuctionDuration { get;  }
        public double StartingValueMultiple { get;  }
        public double StepValueMultiple { get;  }


        public double GiveUpProvBuyerIncentiveRatio { get; }
        public double GiveUpSellerIncentiveRatio { get; }
        public double Brokerage { get; }

        public double MatchSellerIncentiveRatio { get; }
        public double MatchBidderIncentiveRatio { get; }


    }
}
