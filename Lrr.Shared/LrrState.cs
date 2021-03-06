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
            var config = new SimpleConfiguration();
            Calculator = new SimpleCalculator(config);
            Configuration = config;
            InputData = new InputData();
            AuctionDetails = new AuctionDetails();
            GiveUpPaymentSchedule = new GiveUpPaymentSchedule();
            MatchPaymentSchedule = new MatchPaymentSchedule();
        }
        public ICalculator Calculator { get; set; }
        public SimpleConfiguration Configuration { get; set; }
        public IInputData InputData { get; set; }

        public IAuctionDetails AuctionDetails { get; set; }
        public IGiveUpPaymentSchedule GiveUpPaymentSchedule { get; set;}
        public IMatchPaymentSchedule MatchPaymentSchedule { get; set; }
        public bool EditConfig { get; set; } = false;
        public void CalculateValues()
        {
            Calculator.UpdateAuctionDetails(InputData, AuctionDetails);
            GiveUpPaymentSchedule = Calculator.GetGiveUpPaymentSchedule(InputData);
            MatchPaymentSchedule = Calculator.GetMatchPaymentSchedule(InputData);
        }
    }
}
