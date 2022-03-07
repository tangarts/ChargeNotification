
namespace ChargeNotification.Models;
public class GameCharge
{
    public int Id { get; set; }
    public int CustomerId { get; set; }
    public string? Description { get; set; }
    public int TotalCost { get; set; }
    public DateOnly ChargeDate { get; set; }

    public int Total => this.ChargeableItem.Values.Sum();
    internal Dictionary<string, int> ChargeableItem = new();
}