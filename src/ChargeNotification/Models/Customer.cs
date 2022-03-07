using System.ComponentModel.DataAnnotations;

namespace ChargeNotification.Models;

public partial class Customer
{
    [Required]
    public int Id { get; set; }
    [Required]
    public string Name { get; set; } = null!;
}