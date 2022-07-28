using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lrr.Shared
{
    public class SimpleCalculator : ICalculator
    {
        protected IConfiguration configuration;

        public SimpleCalculator()
        {
            configuration = new SimpleConfiguration();
        }

        public IConfiguration Configuration { get { return configuration; } } 
        public virtual void UpdateAuctionDetails(IInputData inputData, IAuctionDetails auctionDetails)
        {
            auctionDetails.EndDate = inputData.RegistrationDate.AddMonths(configuration.AuctionDuration);
            auctionDetails.StepValue = 0;
            auctionDetails.StartingValue = GetStartingValue(inputData, configuration);
            auctionDetails.WhiteValue = GetWhiteValue(inputData);
            auctionDetails.BlackValue = (inputData.PurchaseValue - GetWhiteValue(inputData));
            auctionDetails.ValidAuctionBidValues = new Dictionary<int, string>(); 


        }

        public IGiveUpPaymentSchedule GetGiveUpPaymentSchedule(IInputData inputData)
        {
            var rtnVal = new GiveUpPaymentSchedule();

            var newPurchaseValue = GetNewPurchaseValue(inputData, configuration);
            var oldPurchaseValue = GetWhiteValue(inputData);
            var increasedPurchaseValue = newPurchaseValue - oldPurchaseValue;

            var provIncentive = (int)Math.Ceiling(increasedPurchaseValue * configuration.GiveUpProvBuyerIncentiveRatio);
            var sellerAddProfit = (int)Math.Ceiling(increasedPurchaseValue * configuration.GiveUpSellerIncentiveRatio);
            var brokerage = (int)Math.Ceiling(increasedPurchaseValue * configuration.Brokerage);

            rtnVal.BidderPay = newPurchaseValue;
            rtnVal.BidderFees = GetFees(newPurchaseValue, configuration);
                        
            rtnVal.ProvBuyerCapitalRefund = oldPurchaseValue;
            rtnVal.ProvBuyerFeesRefund = GetFees(oldPurchaseValue, configuration);
            rtnVal.ProvBuyerIncentive = provIncentive;

            rtnVal.OriginalSellerProfit = sellerAddProfit;
            rtnVal.BrokerReceive = brokerage;
            rtnVal.GovernmentAddlProfit = increasedPurchaseValue - (provIncentive + sellerAddProfit + brokerage);

            return rtnVal;
        }

        public IMatchPaymentSchedule GetMatchPaymentSchedule(IInputData inputData)
        {
            var rtnVal = new MatchPaymentSchedule();
            var newPurchaseValue = GetNewPurchaseValue(inputData, configuration);
            var oldPurchaseValue = GetWhiteValue(inputData);
            var increasedPurchaseValue = newPurchaseValue - oldPurchaseValue;

            rtnVal.ProvBuyerAddCapital = increasedPurchaseValue;
            rtnVal.ProvBuyerAddCapitalFee = GetFees(newPurchaseValue, configuration) - GetFees(oldPurchaseValue, configuration);
            

            var bidderIncentive = (int)Math.Ceiling(increasedPurchaseValue * configuration.MatchBidderIncentiveRatio);
            var sellerAddProfit = (int)Math.Ceiling(increasedPurchaseValue * configuration.MatchSellerIncentiveRatio);
            var brokerage = (int)Math.Ceiling(increasedPurchaseValue * configuration.Brokerage);

            rtnVal.BrokerReceive = brokerage;
            rtnVal.OriginalSellerProfit = sellerAddProfit;
            rtnVal.BidderIncentive = bidderIncentive;

            rtnVal.GovernmentAddlProfit = increasedPurchaseValue - (bidderIncentive + sellerAddProfit + brokerage);

            return rtnVal;
        }

        private static int GetFees(int value, IConfiguration configuration)
        {
            var stampCharge = value * configuration.StampChargePercentage;
            var regFees = value * configuration.RegistrationChargePercentage;
            return (int) Math.Ceiling( stampCharge + regFees);
        }

        private static int GetNewPurchaseValue(IInputData inputData, IConfiguration configuration)
        {
            return inputData.HighestBid;
        }

        protected static int GetStartingValue(IInputData inputData, IConfiguration configuration)
        {
            var registrationValue = GetWhiteValue(inputData);
            return (int)Math.Ceiling(registrationValue * configuration .GetStartingValueMultiple(registrationValue) );
        }


        protected static int GetWhiteValue(IInputData inputData)
        {
            ulong tmp = (ulong)inputData.PurchaseValue * (ulong) inputData.WhiteBlackRatio;
            
            return (int) (tmp / 100);
        }
    }
}
