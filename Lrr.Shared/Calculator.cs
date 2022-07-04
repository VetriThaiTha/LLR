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

        public SimpleCalculator()
        {
            configuration = new SimpleConfiguration();
        }

        public void UpdateAuctionDetails(IInputData inputData, IAuctionDetails auctionDetails)
        {

            auctionDetails.EndDate = inputData.RegistrationDate.AddMonths(configuration.AuctionDuration);
            auctionDetails.StepValue = (int)Math.Ceiling(inputData.PurchaseValue * configuration.StepValueMultiple);
            auctionDetails.StartingValue = (int)Math.Ceiling(GetWhiteValue(inputData) * configuration.StartingValueMultiple);
            auctionDetails.WhiteValue = GetWhiteValue(inputData);
            auctionDetails.BlackValue = (inputData.PurchaseValue - GetWhiteValue(inputData));
                

            var validValues = new Dictionary<int,string>();

            for (int i = 0; i <= 100; i++)
            {
                int val = auctionDetails.StartingValue + (i * auctionDetails.StepValue);
                validValues.Add(i, AuctionDetails.FmtIntVal(val));
            }
            auctionDetails.ValidAuctionBidValues = validValues;
        }

        private int GetWhiteValue(IInputData inputData)
        {
            ulong tmp = (ulong)inputData.PurchaseValue * (ulong) inputData.WhiteBlackRatio;
            
            return (int) (tmp / 100);
        }
    }
}
