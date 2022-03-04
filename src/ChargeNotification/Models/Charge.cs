namespace ChargeNotification.Models;

public class Charge
{
    public string? Game { get; set; }

    internal Dictionary<string, int> ChargeableItem = new();
    public DateTime Date { get; set; }
    public int Total => this.ChargeableItem.Values.Sum();
}