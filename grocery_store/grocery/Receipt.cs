namespace GroceryStore;

public class Receipt {
    private readonly string receiptId;
    private readonly Order order;
    private readonly DateTime issueDate;

    public Receipt(Order order) {
        this.receiptId = order.OrderId;
        this.order = order;
        this.issueDate = DateTime.Now;
    }

    public string PrintReceipt() {
        StringBuilder receipt = new StringBuilder("grocery.Receipt ID: " + receiptId + "\n");
        receipt.Append("Date: ").Append(issueDate).Append("\n");
        receipt.Append("Items:\n");

        foreach (OrderItem item in order.Items) {
            receipt.Append("- ").Append(item.Item.Name)
                    .Append(" x ").Append(item.Quantity)
                    .Append(" @ ").Append(item.Item.Price);
                    if (order.AppliedDiscounts.GetValueOrDefault(item) == null) {
                        receipt.Append(" = ")
                                .Append(item.CalculatePrice()).Append("\n");
                    } else {
                        receipt.Append(" (")
                                .Append(order.AppliedDiscounts.GetValueOrDefault(item).Name)
                                .Append(")");
                        receipt.Append(" = ")
                                .Append(item.CalculatePriceWithDiscount(order.AppliedDiscounts.GetValueOrDefault(item)))
                                .Append("\n");
                    }

        }

        receipt.Append("Subtotal: ").Append(order.CalculateSubtotal()).Append("\n");
        receipt.Append("Total: ").Append(order.CalculateTotal()).Append("\n");

        return receipt.ToString();
    }
}
