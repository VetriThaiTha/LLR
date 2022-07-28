using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lrr.Shared
{
    public class SimpleCalculatorWithStep : SimpleCalculator, ICalculator
    {
        private SimpleConfigurationWithStep _configurationWithStep;


        public SimpleCalculatorWithStep()
            : base()
        {
            _configurationWithStep = new SimpleConfigurationWithStep();
            base.configuration = _configurationWithStep;
        }

        public override void UpdateAuctionDetails(IInputData inputData, IAuctionDetails auctionDetails)
        {

            var stepValue = GetStepValue(inputData, _configurationWithStep);
            var startingValue = GetStartingValue(inputData, configuration);
            auctionDetails.EndDate = inputData.RegistrationDate.AddMonths(configuration.AuctionDuration);
            auctionDetails.StepValue = stepValue;
            auctionDetails.StartingValue = startingValue;
            auctionDetails.WhiteValue = GetWhiteValue(inputData);
            auctionDetails.BlackValue = (inputData.PurchaseValue - GetWhiteValue(inputData));

            if (inputData.HighestBidIndex >= 0)
            {
                inputData.HighestBid = startingValue + (inputData.HighestBidIndex * stepValue);
            }
            else
            {
                inputData.HighestBid = 0;
            }


            var validValues = new Dictionary<int, string>();


            for (int i = 0; i <= 100; i++)
            {
                int val = startingValue + (i * stepValue);
                validValues.Add(i, "₹ " + FormattingHelper.CommaSeperated(val));
            }
            auctionDetails.ValidAuctionBidValues = validValues;


        }

        private static int GetStepValue(IInputData inputData, ISimpleConfigurationWithStep configuration)
        {
            return (int)Math.Ceiling(GetWhiteValue(inputData) * configuration.StepValueMultiple);
        }


    }
}
