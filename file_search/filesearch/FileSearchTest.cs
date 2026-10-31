namespace FileSearchSystem;

// xUnit test ported from JUnit 5

public class FileSearchTest {
        [Fact]
    public void TestFileSearch() {
                Console.WriteLine("\n=== Testing File Search System ===");
                
                Console.WriteLine("\n--- Creating File System Structure ---");
                File root = new File(true, 0, "adam", "root");
                File a = new File(false, 2000, "adam", "a");
                File b = new File(false, 3000, "george", "b");
                Console.WriteLine("✓ Created root directory: 'root' (owner: adam, size: 0)");
                Console.WriteLine("✓ Created file 'a': (owner: adam, size: 2000, isDirectory: false)");
                Console.WriteLine("✓ Created file 'b': (owner: george, size: 3000, isDirectory: false)");

                root.AddEntry(a);
                root.AddEntry(b);
                Console.WriteLine("✓ Added files 'a' and 'b' to root directory");

                Console.WriteLine("\n--- Building Search Criteria ---");
                Console.WriteLine("✓ Creating AND predicate with two conditions:");
                Console.WriteLine("  1. File must NOT be a directory (isDirectory = false)");
                Console.WriteLine("  2. Owner name must match regex pattern 'ge.*' (starts with 'ge')");
                
                FileSearchCriteria criteria = new FileSearchCriteria(
                                new AndPredicate(
                                                [
                                                                new SimplePredicate<bool>(
                                                                                FileAttribute.IsDirectory,
                                                                                new EqualsOperator<bool>(),
                                                                                false),
                                                                new SimplePredicate<string>(
                                                                                FileAttribute.Owner,
                                                                                new RegexMatchOperator(),
                                                                                "ge.*")]));
                Console.WriteLine("✓ Search criteria created successfully");

                Console.WriteLine("\n--- Executing File Search ---");
                FileSearch fileSearch = new FileSearch();
                List<File> result = fileSearch.Search(root, criteria);
                Console.WriteLine("✓ Search completed");
                Console.WriteLine("✓ Found " + result.Count + " file(s) matching criteria");

                Console.WriteLine("\n--- Analyzing Results ---");
                Console.WriteLine("✓ Expected: Only file 'b' should match because:");
                Console.WriteLine("  - File 'a': owner='adam' (doesn't match 'ge.*')");
                Console.WriteLine("  - File 'b': owner='george' (matches 'ge.*') and is not a directory");
                
                Assert.Single(result);
                Assert.Equal("b", result[0].Filename);
                Console.WriteLine("✓ Result verified: Found 1 file");
                Console.WriteLine("✓ File name verified: 'b'");
                Console.WriteLine("=== File Search Test Completed Successfully ===\n");
        }
}
