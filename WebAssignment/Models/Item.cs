using System.ComponentModel.DataAnnotations;

namespace WebAssignment.Models
{
    public class Item
    {
        [Key]
        public int ItemId { get; set; }

        [Required(ErrorMessage = "Please enter a product name.")]
        public string? ProductName { get; set; }

        [Required(ErrorMessage = "Please enter a product description.")]
        public string? ProductDescription { get; set; }

        [Range(0.01, double.MaxValue, ErrorMessage = "Please enter a minimum bid amount greater than zero.")]
        public decimal MinimumBidAmount { get; set; }

        [Required(ErrorMessage = "Please enter an auction start date.")]
        [Display(Name = "Auction Start Date")]
        public DateTime AuctionStartDate { get; set; }

        [Required(ErrorMessage = "Please enter an auction end date.")]
        [Display(Name = "Auction End Date")]
        public DateTime AuctionEndDate { get; set; }

        [Required(ErrorMessage = "Please select an asset condition.")]
        public string? ItemCondition { get; set; }

        [Required(ErrorMessage = "Please select a category.")]
        public string? Category { get; set; }

        [Required(ErrorMessage = "Please upload an image.")]
        [Url(ErrorMessage = "Please enter a valid URL.")]
        public string? ImageUrl { get; set; }
    }
}
