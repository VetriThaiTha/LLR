using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lrr.Shared
{
    public interface IAuctionDetails
    {
        public DateOnly EndDate { get; set; }
        public int StartingValue { get; set; }
        public int StepValue { get; set; }
        public double WhiteValue { get; set; }
        public double BlackValue { get; set; }
        public List<string> ValidAuctionBidValues { get; set; }

        public string FmtStartingValue { get; }
        public string FmtStepValue { get; }

    }
}
