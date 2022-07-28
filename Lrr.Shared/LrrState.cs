using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lrr.Shared
{
    public class LrrState
    {
        public LrrState()
        {
            Calculator = new SimpleCalculatorWithStep();
            InputData = new InputData();
            AuctionDetails = new AuctionDetails();
            GiveUpPaymentSchedule = new GiveUpPaymentSchedule();
            MatchPaymentSchedule = new MatchPaymentSchedule();
        }
        public ICalculator Calculator { get; set; }
        public IConfiguration Configuration { get { return Calculator.Configuration; } }
        public IInputData InputData { get; set; }

        public IAuctionDetails AuctionDetails { get; set; }
        public IGiveUpPaymentSchedule GiveUpPaymentSchedule { get; set;}
        public IMatchPaymentSchedule MatchPaymentSchedule { get; set; }
        public FormattingHelper FmtHelper { get; } = new FormattingHelper();
        public bool EditConfig { get; set; } = false;
        public void CalculateValues()
        {
            Calculator.UpdateAuctionDetails(InputData, AuctionDetails);
            GiveUpPaymentSchedule = Calculator.GetGiveUpPaymentSchedule(InputData);
            MatchPaymentSchedule = Calculator.GetMatchPaymentSchedule(InputData);
        }

        public bool HasValidBid()
        {
            if (InputData.HighestBidIndex > 0 )
                return true;

            if (InputData.HighestBid >= AuctionDetails.StartingValue)
                return true;

            return false;
        }

        public double GetStartingValueMultiple()
        {
            return Configuration.GetStartingValueMultiple(AuctionDetails.WhiteValue);
        }
    }
}
