namespace GroceryStore.DeepDive;

// Composite criteria that combines multiple discount criteria
public class CompositeCriteria : IDiscountCriteria {
    // List of criteria to be combined
    private readonly List<IDiscountCriteria> criteriaList;

    // Creates a new composite criteria with the given list of criteria
    public CompositeCriteria(List<IDiscountCriteria> criteriaList) {
        this.criteriaList = new(criteriaList);
    }

    // Checks if the item satisfies all the criteria in the list
    public bool IsApplicable(Item item) {
        return criteriaList.All(criteria => criteria.IsApplicable(item));
    }

    // Adds a new criteria to the composite
    public void AddCriteria(IDiscountCriteria criteria) {
        criteriaList.Add(criteria);
    }

    // Removes a criteria from the composite
    public void RemoveCriteria(IDiscountCriteria criteria) {
        criteriaList.Remove(criteria);
    }
}
