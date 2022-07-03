﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lrr.Shared
{
    public class LrrState
    {
        public LrrState()
        {
            Calculator = new SimpleCalculator();
            Configuration = new SimpleConfiguration();
            InputData = new InputData();
            AuctionDetails = new AuctionDetails();
        }
        public ICalculator Calculator { get; set; }
        public IConfiguration Configuration { get; set; }
        public IInputData InputData { get; set; }

        public IAuctionDetails AuctionDetails { get; set; }

        public void CalculateValues()
        {
            AuctionDetails = Calculator.GetAuction(InputData);
        }
    }
}
