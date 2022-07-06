namespace Lrr.Models
{
    using System.ComponentModel.DataAnnotations;
    using Lrr.Shared;

    public class SimpleConfigurationModel
    {
        
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
    }
}
