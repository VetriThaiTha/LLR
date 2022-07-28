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
        public IBand Band1 { get; set; }
        public IBand Band2 { get; set; }
        public IBand Band3 { get; set; }
        public IBand Band4 { get; set; }
        public IBand Band5 { get; set; }
        public IBand Band6 { get; set; }
    }
    public interface ICurveConfiguration : IConfiguration
    {
        public ICurvePoint Point1 { get; set; }
        public ICurvePoint Point2 { get; set; }
        public ICurvePoint Point3 { get; set; }
        public ICurvePoint Point4 { get; set; }
        public ICurvePoint Point5 { get; set; }
        public ICurvePoint Point6 { get; set; }
        public ICurvePoint Point7 { get; set; }
    }

    public interface ICurvePoint
    {
        public int Value { get; set; }
        public double StartingValueMultiple { get; set; }
    }
    public interface IBand
    {
        public int EndValue { get; set; }
        public double StartingValueMultiple { get; set; }
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
