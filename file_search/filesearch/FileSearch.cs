namespace FileSearchSystem;

// Main class responsible for performing file system searches
public class FileSearch {
    // Performs a recursive search through the file system starting from root
    // Returns a list of files that match the given criteria
    public List<File> Search(File root, FileSearchCriteria criteria) {
        // List to store matching files
        List<File> result = new();
        // Stack to handle recursive traversal without actual recursion
        Stack<File> recursionStack = new();
        // Start with the root directory
        recursionStack.Push(root);
        // Continue until we've processed all files
        while (recursionStack.Count > 0) {
            // Get the next file to process
            File next = recursionStack.Pop();
            // Check if the file matches our criteria
            if (criteria.IsMatch(next)) {
                result.Add(next);
            }
            // Add all directory entries to the stack for processing
            foreach (File entry in next.Entries) {
                recursionStack.Push(entry);
            }
        }
        return result;
    }
}
