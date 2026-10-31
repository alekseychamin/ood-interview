namespace VendingMachineSystem;

public class Transaction {
    private Rack rack;
    private Product product;
    private decimal totalAmount = 0m;

    // Getters and setters
    public void SetProduct(Product product) {
        this.product = product;
    }
    public Product Product => product;

    public void SetRack(Rack rack) {
        this.rack = rack;
    }
    public Rack Rack => rack;

    public void SetTotalAmount(decimal totalAmount) {
        this.totalAmount = totalAmount;
    }

    public decimal TotalAmount => totalAmount;

    public override string ToString() {
        return "Transaction{" +
                "totalAmount=" + totalAmount +
                ", rack=" + rack +
                ", product=" + product +
                ", totalAmount=" + TotalAmount +
                '}';
    }
}
