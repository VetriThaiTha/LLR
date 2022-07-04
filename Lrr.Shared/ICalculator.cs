using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lrr.Shared
{
    public interface ICalculator
    {
        public void UpdateAuctionDetails(IInputData inputData, IAuctionDetails auctionDetails);
        public IGiveUpPaymentSchedule GetGiveUpPaymentSchedule(IInputData inputData);
        public IMatchPaymentSchedule GetMatchPaymentSchedule(IInputData inputData);
    }
}
