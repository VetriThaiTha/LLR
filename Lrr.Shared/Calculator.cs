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
                StepValue = (int) Math.Ceiling( inputData.PurchaseValue * configuration.StepValueMultiple),
                StartingValue = (int)Math.Ceiling(GetWhiteValue(inputData) * configuration.StartingValueMultiple),
                WhiteValue = GetWhiteValue(inputData) ,
                BlackValue = inputData.PurchaseValue * ((100 - inputData.WhiteBlackRatio )/ 100.0),
                
            };

            var validValues = new List<string>();

            for (int i = 0; i < 100; i++)
            {
                validValues.Add((aDetails.StartingValue + aDetails.StepValue * i).ToString("##\\,##\\,##\\,##0"));
            }
            aDetails.ValidAuctionBidValues = validValues;
            return aDetails;
        }

        private double GetWhiteValue(IInputData inputData)
        {
            return inputData.PurchaseValue * inputData.WhiteBlackRatio / 100.0;
        }
    }
}
