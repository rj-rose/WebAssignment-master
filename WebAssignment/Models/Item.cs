using System.ComponentModel.DataAnnotations;

namespace WebAssignment.Models
{
    public class Item
    {
        public int ItemId { get; set; }

        [Required(ErrorMessage = "Please enter a product name.")]
        public string? ItemName { get; set; }

        [Required(ErrorMessage = "Please enter a product description.")]
        public string? ItemDescription { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a minimum bid amount greater than zero.")]
        public decimal MinBid { get; set; }

        [Required(ErrorMessage = "Please enter an auction start date.")]
        [Display(Name = "Auction Start Date")]
        public DateTime AuctionStart { get; set; }

        [Required(ErrorMessage = "Please enter an auction end date.")]
        [Display(Name = "Auction End Date")]
        public DateTime AuctionEnd { get; set; }

        [Required(ErrorMessage = "Please select an asset condition.")]
        public string? ItemCondition { get; set; }

        [Required(ErrorMessage = "Please select a category.")]
        public string? Category { get; set; }

        [Required(ErrorMessage = "Please upload an image.")]
        [Url(ErrorMessage = "Please enter a valid URL.")]
        public string? ImageUrl { get; set; }
    }
}
