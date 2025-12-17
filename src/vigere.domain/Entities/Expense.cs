namespace vigere.domain.Entities;

public class Expense
{
    public long Id { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public decimal Amount { get; set; }
    public DateOnly Date { get; set; }
    public DateTime ControlDate { get; set; }
}
