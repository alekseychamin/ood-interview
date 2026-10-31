namespace VendingMachineSystem.DeepDive;

public class DispenseState : IVendingMachineState {
    public void InsertMoney(VendingMachine vm, double amount) {
        vm.PaymentProcessor.ProcessPayment((decimal)amount);
    }

    public void SelectProductByCode(VendingMachine vm, string productCode) {
        throw new InvalidStateException("Cannot select another product while dispensing.");
    }

    public void DispenseProduct(VendingMachine vm) {
        try {
            // Step 1: Validate the transaction
            if (vm.SelectedProduct == null) {
                throw new InvalidStateException("Invalid product selection");
            }

            // Step 2: Charge the customer
            double productPrice = vm.GetProductPrice(vm.SelectedProduct);
            if (vm.PaymentProcessor.CurrentBalance < (decimal)productPrice) {
                throw new InvalidStateException("Insufficient funds");
            }
            vm.PaymentProcessor.Charge((decimal)productPrice);

            // Step 3: Dispense the product
            vm.InventoryManager.DispenseProductFromRack(vm.SelectedProduct);

            // Step 4: Return to initial state
            vm.SetState(new NoMoneyInsertedState());
        } catch (Exception e) {
            throw new InvalidStateException("Error during transaction: " + e.Message);
        }
    }

    public string StateDescription => "Dispense State";
}
