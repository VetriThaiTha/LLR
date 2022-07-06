using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lrr.Shared
{
    public class SimpleCalculator : ICalculator
    {
        protected SimpleConfiguration configuration;

        public SimpleCalculator(SimpleConfiguration simpleConfiguration)
        {
            configuration = simpleConfiguration;
        }

        public void UpdateAuctionDetails(IInputData inputData, IAuctionDetails auctionDetails)
        {


            auctionDetails.EndDate = inputData.RegistrationDate.AddMonths(configuration.AuctionDuration);
            auctionDetails.StepValue = GetStepValue(inputData, configuration);
            auctionDetails.StartingValue = GetStartingValue(inputData, configuration);
            auctionDetails.WhiteValue = GetWhiteValue(inputData);
            auctionDetails.BlackValue = (inputData.PurchaseValue - GetWhiteValue(inputData));
                

            var validValues = new Dictionary<int,string>();


            for (int i = 0; i <= 100; i++)
            {
                int val = auctionDetails.StartingValue + (i * auctionDetails.StepValue);
                validValues.Add(i, "₹ " + AuctionDetails.FmtIntVal(val));
            }
            auctionDetails.ValidAuctionBidValues = validValues;


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
            var stepValue = GetStepValue(inputData, configuration);
            var startingValue = GetStartingValue(inputData, configuration);
            var newPurchaseValue = startingValue + (inputData.HighestBidIndex * stepValue);
            return newPurchaseValue;
        }

        private static int GetStartingValue(IInputData inputData, IConfiguration configuration)
        {
            return (int)Math.Ceiling(GetWhiteValue(inputData) * configuration.StartingValueMultiple);
        }

        private static int GetStepValue(IInputData inputData, IConfiguration configuration)
        {
            return (int)Math.Ceiling(inputData.PurchaseValue * configuration.StepValueMultiple);
        }

        private static int GetWhiteValue(IInputData inputData)
        {
            ulong tmp = (ulong)inputData.PurchaseValue * (ulong) inputData.WhiteBlackRatio;
            
            return (int) (tmp / 100);
        }
    }
}
