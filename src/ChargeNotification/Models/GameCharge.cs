public class GameCharge
{
    public int Id { get; set; }
    public int CustomerId { get; set; }

    internal Dictionary<string, int> ChargeableItem = new();

    public string? Description { get; set; }
    public int TotalCost { get; set; }
    public int Total => this.ChargeableItem.Values.Sum();

    public DateTime ChargeDate { get; set; }
}