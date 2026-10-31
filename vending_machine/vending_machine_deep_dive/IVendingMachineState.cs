namespace VendingMachineSystem.DeepDive;

public interface IVendingMachineState {
    void InsertMoney(VendingMachine vm, double amount);
    void SelectProductByCode(VendingMachine vm, string productCode);
    void DispenseProduct(VendingMachine vm);
    string StateDescription { get; }
}
