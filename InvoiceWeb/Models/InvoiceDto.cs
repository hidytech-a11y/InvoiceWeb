using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace InvoiceWeb.Models
{
    public class InvoiceDto
    {
        [Required]
        public string Number { get; set; } = "";
        [Required]
        public string Status { get; set; } = ""; // e.g., "Paid", "Unpaid", "Overdue"

        public DateTime? IssueDate { get; set; }
        public DateTime? DueDate { get; set; }


        //Services Details
        [Required]
        public string Service { get; set; } = "";
        [Required, Display(Name = "Unit Price")]
        public decimal UnitPrice { get; set; }
        [Required]
        public int Quantity { get; set; }


        // Client Information
        [Required, Display(Name ="Client Name")]
        public string ClientName { get; set; } = "";
        [Required, EmailAddress]
        public string Email { get; set; } = "";
        [Required, Phone]
        public string Phone { get; set; } = "";
        public string? Address { get; set; }



    }
}
