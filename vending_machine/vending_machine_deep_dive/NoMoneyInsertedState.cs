namespace VendingMachineSystem.DeepDive;

public class NoMoneyInsertedState : IVendingMachineState {
    public void InsertMoney(VendingMachine vm, double amount) {
        vm.AddBalance(amount);
        vm.SetState(new MoneyInsertedState());
    }

    public void SelectProductByCode(VendingMachine vm, string productCode){
        throw new InvalidStateException("Cannot select a product without inserting money.");
    }

    public void DispenseProduct(VendingMachine vm){
        throw new InvalidStateException("Cannot dispense product without inserting money.");
    }

    public string StateDescription => "No Money Inserted State - Please insert money to proceed";
}
