using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lrr.Shared
{
    public interface ISimpleConfiguration : IConfiguration
    {
        public double StartingValueMultiple { get; }

    }

    public interface ISimpleConfigurationWithStep : IConfiguration, ISimpleConfiguration
    {
        public double StepValueMultiple { get; }

    }

    public interface IBandConfiguration : IConfiguration
    {

    }
    public interface ICurveConfiguration : IConfiguration
    {

    }
    public interface IBand
    {
        public int startValue { get; set; }
        public double StartingValueMultiple { get; }
    }

    public interface IConfiguration
    {
        
        public double StampChargePercentage { get;  }
        public double RegistrationChargePercentage { get;  }

        public int AuctionDuration { get;  }
        

        public double GetStartingValueMultiple(int regValue);


        public double GiveUpProvBuyerIncentiveRatio { get; }
        public double GiveUpSellerIncentiveRatio { get; }
        public double Brokerage { get; }

        public double MatchSellerIncentiveRatio { get; }
        public double MatchBidderIncentiveRatio { get; }


    }
}
