namespace Atm;

// Main ATM machine class that manages the state and hardware components of the ATM
public class ATMMachine {
    private ATMState state;

    private readonly ICardProcessor cardProcessor;
    private readonly IDepositBox depositBox;
    private readonly ICashDispenser cashDispenser;
    private readonly IKeypad keypad;
    private readonly IDisplay display;

    private readonly Bank bank;

    // Initializes ATM with all required hardware components and bank interface
    public ATMMachine(Bank bank, ICardProcessor cardProcessor, IDepositBox depositBox,
                      ICashDispenser cashDispenser, IKeypad keypad, IDisplay display) {
        this.bank = bank;
        this.cardProcessor = cardProcessor;
        this.depositBox = depositBox;
        this.cashDispenser = cashDispenser;
        this.keypad = keypad;
        this.display = display;
        this.state = new IdleState();
    }

    // Forwards card insertion to current state for processing
    public void InsertCard(string cardNumber) {
        state.ProcessCardInsertion(this, cardNumber);
    }

    // Forwards card ejection to current state for processing
    public void EjectCard() {
        state.ProcessCardEjection(this);
    }

    // Forwards PIN entry to current state for validation
    public void EnterPin(string pin) {
        state.ProcessPinEntry(this, pin);
    }

    // Forwards withdrawal request to current state for processing
    public void WithdrawRequest() {
        state.ProcessWithdrawalRequest(this);
    }

    // Forwards deposit request to current state for processing
    public void DepositRequest() {
        state.ProcessDepositRequest(this);
    }

    // Forwards amount entry to current state for processing
    public void EnterAmount(decimal amount) {
        state.ProcessAmountEntry(this, amount);
    }

    // Forwards deposit collection to current state for processing
    public void CollectDeposit(decimal amount) {
        state.ProcessDepositCollection(this, amount);
    }

    // Returns the display component for showing messages
    public IDisplay Display => display;

    // Returns the cash dispenser component for handling withdrawals
    public ICashDispenser CashDispenser => cashDispenser;

    // Returns the bank interface for account operations
    public IBank BankInterface => bank;

    // Returns the card processor component for handling card operations
    public ICardProcessor CardProcessor => cardProcessor;

    // Returns the keypad component for user input
    public IKeypad Keypad => keypad;

    // Updates the current state of the ATM
    public void TransitionToState(ATMState nextState) {
        this.state = nextState;
    }

    // Returns the current state of the ATM
    public ATMState CurrentState => state;

    // Returns the deposit box component for handling deposits
    public IDepositBox DepositBox => depositBox;
}
