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
        public List<string> ValidAuctionBidValues { get; set; } = new List<string>();

        public string FmtStartingValue => FmtIntVal(StartingValue);
        public string FmtStepValue => FmtIntVal(StepValue);
        public string FmtWhiteValue => FmtIntVal(WhiteValue);
        public string FmtBlackValue => FmtIntVal(BlackValue); 

        private static string FmtIntVal(int val)
        {
            if (val < 1000)
                return val.ToString("##0");

            if (val < 100000)
                return val.ToString("##\\,##0");
            if (val < 10000000)
                return val.ToString("##\\,##\\,##0");
            if (val < 1000000000)
                return val.ToString("##\\,##\\,##\\,##0");

            return val.ToString("##\\,##\\,##\\,##\\,##0");
        }


        private static string FmtIntVal(long val)
        {
            if (val < 1000)
                return val.ToString("##0");

            if (val < 100000)
                return val.ToString("##\\,##0");
            if (val < 10000000)
                return val.ToString("##\\,##\\,##0");
            if (val < 1000000000)
                return val.ToString("##\\,##\\,##\\,##0");

            return val.ToString("##\\,##\\,##\\,##\\,##0");
        }
    }
}
