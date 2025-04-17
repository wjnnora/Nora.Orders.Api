namespace Nora.Orders.Domain.ValueObjects;

public sealed class Customer
{
    public int Id { get; set; }    
    public string Name { get; set; }

    private Customer() { }

    public Customer(int id, string name)
    {
        Id = id;
        Name = name;
    }
}