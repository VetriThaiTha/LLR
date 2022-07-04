using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lrr.Shared
{


    
    public interface IPaymentSchedule
    {
        public int BrokerReceive { get; set; }
        public int OriginalSellerProfit { get; set; }
        public int GovernmentExtraTax { get; set; }
        public int GovernmentAddlProfit { get; set; }
}
    public interface IGiveUpPaymentSchedule : IPaymentSchedule
    {
        public int BidderPay { get; set; }
        public int BidderFees { get; set; }
        public int ProvBuyerCapitalRefund{ get; set; }
        public int ProvBuyerFeesRefund { get; set; }
        public int ProvBuyerIncentive { get; set; }

    }

    public interface IMatchPaymentSchedule : IPaymentSchedule
    {
        public int ProvBuyerAddCapital{ get; set; }
        public int ProvBuyerAddCapitalFee { get; set; }
        public int BidderIncentive { get; set; }
    }
}
