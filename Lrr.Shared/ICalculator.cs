using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lrr.Shared
{
    public interface ICalculator
    {
        public IAuctionDetails GetAuction(IInputData inputData);
    }
}
