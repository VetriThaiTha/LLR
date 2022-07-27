using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lrr.Shared
{
    public class AuctionDetails : IAuctionDetails
    {
        private CultureInfo cultureInfo = new CultureInfo("hi-IN");
        public DateOnly EndDate { get; set; }
        public int StartingValue { get; set; }
        public int StepValue { get; set; }
        public int WhiteValue { get; set; }
        public int BlackValue { get; set; }
        public Dictionary<int, string> ValidAuctionBidValues { get; set; } = new Dictionary<int, string>();


        public string FmtStartingValue => FormattingHelper.CommaSeperated(StartingValue);
        public string FmtStepValue => FormattingHelper.CommaSeperated(StepValue);
        public string FmtWhiteValue => FormattingHelper.CommaSeperated(WhiteValue);
        public string FmtBlackValue => FormattingHelper.CommaSeperated(BlackValue); 

        


        
    }
}
