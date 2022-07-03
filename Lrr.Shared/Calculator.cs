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

        public IAuctionDetails GetAuction(IInputData inputData)
        {
            var aDetails = new AuctionDetails
            {
                EndDate = inputData.RegistrationDate.AddMonths(configuration.AuctionDuration),
                StepValue = (int)Math.Ceiling( inputData.PurchaseValue * configuration.StepValueMultiple),
                StartingValue = (int)Math.Ceiling(GetWhiteValue(inputData) * configuration.StartingValueMultiple),
                WhiteValue = GetWhiteValue(inputData) ,
                BlackValue = (inputData.PurchaseValue - GetWhiteValue(inputData)) ,
                
            };

            var validValues = new List<string>();

            for (uint i = 0; i < 100; i++)
            {
                validValues.Add((aDetails.StartingValue +  aDetails.StepValue * i).ToString("##\\,##\\,##\\,##0"));
            }
            aDetails.ValidAuctionBidValues = validValues;
            return aDetails;
        }

        private int GetWhiteValue(IInputData inputData)
        {
            ulong tmp = (ulong)inputData.PurchaseValue * (ulong) inputData.WhiteBlackRatio;
            
            return (int) (tmp / 100);
        }
    }
}
