using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lrr.Shared
{
    public abstract class PaymentSchedule : IPaymentSchedule
    {
        public int BrokerReceive { get; set; }
        public int OriginalSellerProfit { get; set; }
        public int GovernmentExtraTax { get; set; }
        public int GovernmentAddlProfit { get; set; }
    }

    public class GiveUpPaymentSchedule : PaymentSchedule, IGiveUpPaymentSchedule
    {
        public int BidderPay { get; set; }
        public int BidderFees { get; set; }
        public int ProvBuyerCapitalRefund { get; set; }
        public int ProvBuyerFeesRefund { get; set; }
        public int ProvBuyerIncentive { get; set; }
    }

    public class MatchPaymentSchedule : PaymentSchedule, IMatchPaymentSchedule
    {
        public int ProvBuyerAddCapital { get; set; }
        public int ProvBuyerAddCapitalFee { get; set; }
        public int BidderIncentive { get; set; }
    }
}
