namespace ChargeNotification.Models;

public class Notification
{
    public int CustomerNumber { get; set; }
    public string? CustomerName { get; set; }
    public List<GameCharge> Charges { get; set; } = new();
    public int TotalCost => this.Charges.Sum(ch => ch.TotalCost);
}