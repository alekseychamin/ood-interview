# Unix File Search Project

This project implements a flexible file search system similar to Unix's find command, allowing users to search for files based on various criteria such as name, owner, size, and directory status.

## Project Structure

```
filesearch/
├── FileSearch.cs           # Main search implementation
├── FileSearchCriteria.cs   # Search criteria definition
├── FileSearchTest.cs       # Unit tests
├── clause/                   # Search predicates
│   ├── AndPredicate.cs
│   ├── OrPredicate.cs
│   └── SimplePredicate.cs
├── operator/                 # Comparison operators
└── filesystem/              # File system related classes
```

## Prerequisites


- .NET SDK 10.0 (C# 14)
- xUnit (restored automatically by `dotnet restore`)

## Running the Tests

```bash
# From repository root
dotnet test file_search/FileSearch.csproj
```

## Usage Example

The file search system supports various search criteria that can be combined using AND/OR predicates. Here's an example of how to use it:

```csharp
// Create a file hierarchy
File root = new File(true, 0, "adam", "root");
File a = new File(false, 2000, "adam", "a");
root.AddEntry(a);

// Create search criteria
FileSearchCriteria criteria = new FileSearchCriteria(
    new SimplePredicate<bool>(
        FileAttribute.IsDirectory,
        new EqualsOperator<bool>(),
        false
    )
);

// Perform the search
FileSearch fileSearch = new FileSearch();
List<File> results = fileSearch.Search(root, criteria);
```

## Search Criteria

The system supports the following search criteria:
- File name matching (exact match or regex)
- File owner
- File size
- Directory status
- Combinations of criteria using AND/OR operators

## Contributing

Feel free to submit issues and enhancement requests!

## License

This project is open source and available under the MIT License.
