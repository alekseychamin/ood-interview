namespace VendingMachineSystem;

public class Rack {
    private readonly string rackCode;
    private readonly Product product;
    private int count;

    public Rack(string rackCode,
                Product product,
                int count) {
        this.rackCode = rackCode;
        this.product = product;
        this.count = count;
    }


    // Getter and setters
    public string RackCode => rackCode;

    public Product Product => product;

    public int ProductCount => count;

    public void SetCount(int count) {
        this.count = count;
    }
}
