namespace VendingMachineSystem.DeepDive;

public class MoneyInsertedState : IVendingMachineState {
    public void InsertMoney(VendingMachine vm, double amount) {
        vm.PaymentProcessor.ProcessPayment((decimal)amount);
    }

    public void SelectProductByCode(VendingMachine vm, string productCode) {
        try {
            vm.InventoryManager.GetProductInRack(productCode);
            vm.SetSelectedProduct(productCode);
            vm.SetState(new DispenseState());
        } catch (Exception e) {
            throw new InvalidStateException("Invalid product selection: " + e.Message);
        }
    }

    public void DispenseProduct(VendingMachine vm) {
        throw new InvalidStateException("Please select a product first.");
    }

    public string StateDescription => "Money Inserted State";
}
