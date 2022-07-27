using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lrr.Shared
{
    public interface IInputData
    {
        public int WhiteBlackRatio { get; set; }
        public int PurchaseValue { get; set;}
        public DateOnly RegistrationDate { get; set; }
        public int HighestBidIndex { get; set; }
        public int HighestBid { get; set; }
        public DecisionEnum Decision { get; set; }


    }
}
