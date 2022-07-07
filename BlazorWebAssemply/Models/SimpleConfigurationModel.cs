namespace Lrr.Models
{
    using System.ComponentModel.DataAnnotations;
    using Lrr.Shared;

    public class SimpleConfigurationModel
    {

        private Dictionary<string, string> _errorMesages = new();
        public bool hasErrorMesages { get { return _errorMesages.Count() > 0; } }
        
        [Required] public double StampChargePercentage { get; set; }
        [Required] public double RegistrationChargePercentage { get; set; }
        [Required] public int AuctionDuration { get; set; }
        [Required] public double StartingValueMultiple { get; set; }
        [Required] public double StepValueMultiple { get; set; }

        [Required] public double GiveUpProvBuyerIncentiveRatio { get; set; }
        [Required] public double GiveUpSellerIncentiveRatio { get; set; }
        [Required] public double Brokerage { get; set; }

        [Required] public double MatchSellerIncentiveRatio { get; set; }
        [Required] public double MatchBidderIncentiveRatio { get; set; }

        public string GetErrorMessage(string property)
        {
            return _errorMesages.TryGetValue(property, out var errorMesages) ?errorMesages:String.Empty;
        }

        public void Validate()
        {
            _errorMesages.Clear();

            if (StampChargePercentage < 0.0)
                _errorMesages.Add("StampChargePercentage", "Stamp charge multiple cannot be less than 0");
            if (StampChargePercentage > 1.0)
                _errorMesages.Add("StampChargePercentage", "Stamp charge multiple cannot be greater than 1.0");

            if (RegistrationChargePercentage < 0.0)
                _errorMesages.Add("RegistrationChargePercentage", "Registration fee multiple cannot be less than 0");
            if (RegistrationChargePercentage > 1.0)
                _errorMesages.Add("RegistrationChargePercentage", "Registration fee multiple cannot be greater than 1.0");

            if (AuctionDuration <= 0)
                _errorMesages.Add("AuctionDuration", "Auction duration cannot be less than equal to 0");
            if (AuctionDuration > 12)
                _errorMesages.Add("AuctionDuration", "Auction duration cannot be greater than 12");

            if (StartingValueMultiple < 1.0)
                _errorMesages.Add("StartingValueMultiple", "Auction starting value multiple cannot be less than 1.0");
            if (StartingValueMultiple > 10.0)
                _errorMesages.Add("StartingValueMultiple", "Auction starting value multiple cannot be greater than 10.0");

            if (StepValueMultiple < 0.01)
                _errorMesages.Add("StepValueMultiple", "Auction step value multiple cannot be less than 0.01");
            if (StepValueMultiple >= 1.0)
                _errorMesages.Add("StepValueMultiple", "Auction step value multiple cannot be greater than equal to 1.0");

            if (GiveUpSellerIncentiveRatio < 0.0)
                _errorMesages.Add("GiveUpSellerIncentiveRatio", "Seller's incentive multiple cannot be less than 1.0");
            if (GiveUpSellerIncentiveRatio >= 1.0)
                _errorMesages.Add("GiveUpSellerIncentiveRatio", "Seller's incentive multiple cannot be greater than equal to 1.0");

            if (GiveUpProvBuyerIncentiveRatio < 0.0)
                _errorMesages.Add("GiveUpProvBuyerIncentiveRatio", "Provisional buyer's incentive multiple cannot be less than 1.0");
            if (GiveUpProvBuyerIncentiveRatio >= 1.0)
                _errorMesages.Add("GiveUpProvBuyerIncentiveRatio", "Provisional buyer's incentive multiple cannot be greater than equal to 1.0");

            if (MatchBidderIncentiveRatio < 0.0)
                _errorMesages.Add("MatchBidderIncentiveRatio", "Bidder's incentive multiple cannot be less than 1.0");
            if (MatchBidderIncentiveRatio >= 1.0)
                _errorMesages.Add("MatchBidderIncentiveRatio", "Bidder 's incentive multiple cannot be greater than equal to 1.0");

            if (MatchSellerIncentiveRatio < 0.0)
                _errorMesages.Add("MatchSellerIncentiveRatio", "Seller's incentive multiple cannot be less than 1.0");
            if (MatchSellerIncentiveRatio >= 1.0)
                _errorMesages.Add("MatchSellerIncentiveRatio", "Seller's incentive multiple cannot be greater than equal to 1.0");

            if (Brokerage < 0.0)
                _errorMesages.Add("Brokerage", "Brokerage multiple cannot be less than 1.0");
            if (Brokerage >= 1.0)
                _errorMesages.Add("Brokerage", "Brokerage multiple cannot be greater than equal to 1.0");
        }
    }
}
