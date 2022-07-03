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
        public double WhiteValue { get; set; }
        public double BlackValue { get; set; }
        public List<string> ValidAuctionBidValues { get; set; } = new List<string>();

        public string FmtStartingValue
        {
            get
            {

                return StartingValue.ToString("##\\,##\\,##\\,##0");
                    
            }
        }
        public string FmtStepValue
        {
            get
            {
                return string.Format(cultureInfo, "{0:c}", StepValue);
            }
        }

    }
}
