namespace VendingMachineSystem;

public class InventoryManager {
    private Dictionary<string, Rack> racks;

    public InventoryManager() {
        racks = new();
    }

    public Product GetProductInRack(string rackCode) {
        return racks.GetValueOrDefault(rackCode).Product;
    }

    public void DispenseProductFromRack(Rack rack) {
        rack.SetCount(rack.ProductCount - 1);
    }

    public void UpdateRack(Dictionary<string, Rack> racks) {
        this.racks = racks;
    }

    public Rack GetRack(string name) {
        return racks.GetValueOrDefault(name);
    }

    public override string ToString() {
        return "InventoryManager{" +
                "racks=" + racks +
                '}';
    }
}
