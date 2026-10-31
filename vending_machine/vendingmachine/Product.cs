namespace VendingMachineSystem;

public class Product {
    private readonly string productCode;
    private readonly string description;
    private readonly decimal unitPrice;

    public Product(string productCode, string description, decimal unitPrice) {
        this.productCode = productCode;
        this.description = description;
        this.unitPrice = unitPrice;
    }


    // Getter and setters
    public string ProductCode => productCode;

    public string Description => description;

    public decimal UnitPrice => unitPrice;
}
