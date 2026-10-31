namespace VendingMachineSystem;

public class VendingMachine {
    private List<Transaction> transactionHistory;
    private InventoryManager inventoryManager;
    private PaymentProcessor paymentProcessor;

    private Transaction currentTransaction;

    public VendingMachine() {
        transactionHistory = new();
        currentTransaction = new Transaction();
        inventoryManager = new InventoryManager();
        paymentProcessor = new PaymentProcessor();
    }

    internal void SetRack(Dictionary<string, Rack> rack) {
        inventoryManager.UpdateRack(rack);
    }
    
    internal void InsertMoney(decimal amount) {
        paymentProcessor.AddBalance(amount);
    }

    internal void ChooseProduct(string rackId) {
        Product product = inventoryManager.GetProductInRack(rackId);
        currentTransaction.SetRack(inventoryManager.GetRack(rackId));
        currentTransaction.SetProduct(product);
    }

    internal Transaction ConfirmTransaction(){
        // Step 1: Validate the transaction before processing
        ValidateTransaction();

        // Step 2: Charge the customer for the product
        paymentProcessor.Charge(currentTransaction.Product.UnitPrice);

        // Step 3: Dispense the product from the rack
        inventoryManager.DispenseProductFromRack(currentTransaction.Rack);

        // Step 4: Return the change to the customer
        currentTransaction.SetTotalAmount(paymentProcessor.ReturnChange());

        // Step 5: Add the completed transaction to the history
        transactionHistory.Add(currentTransaction);
        Transaction completedTransaction = currentTransaction;
        
        // Reset the current transaction for the next purchase.
        currentTransaction = new Transaction(); 
        return completedTransaction;
    }

    private void ValidateTransaction(){
        if (currentTransaction.Product == null) {
            throw new InvalidTransactionException("Invalid product selection");
        } else if (currentTransaction.Rack.ProductCount == 0) {
            // Insufficient inventory for product.  
            throw new InvalidTransactionException("Insufficient inventory for product.");
        } else if (paymentProcessor.CurrentBalance < currentTransaction.Product.UnitPrice) {
            throw new InvalidTransactionException("Insufficient fund");
        }
    }


    public List<Transaction> TransactionHistory => new(transactionHistory);

    public void CancelTransaction() {
        paymentProcessor.ReturnChange();
        currentTransaction = new Transaction(); // Reset the current transaction for the next purchase.
    }

    public InventoryManager InventoryManager => inventoryManager;
}
