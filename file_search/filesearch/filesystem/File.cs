namespace FileSearchSystem;

// Represents a file or directory in the file system
// Contains basic file attributes and supports hierarchical structure
public class File {
    private readonly bool isDirectory;
    private readonly int size;
    private readonly string owner;
    private readonly string filename;
    // Set of directory entries (files and subdirectories)
    private readonly HashSet<File> entries = new();

    // Creates a new file with the specified attributes
    public File(bool isDirectory, int size, string owner, string filename) {
        this.isDirectory = isDirectory;
        this.size = size;
        this.owner = owner;
        this.filename = filename;
    }

    // Extracts the value of a specified file attribute
    public object Extract(FileAttribute attributeName) {
        return attributeName switch {
            FileAttribute.Size => size,
            FileAttribute.Owner => owner,
            FileAttribute.IsDirectory => isDirectory,
            FileAttribute.Filename => filename,
            _ => throw new ArgumentException("invalid filter criteria type"),
        };
    }

    // Adds a file or directory entry to this directory
    public void AddEntry(File entry) {
        entries.Add(entry);
    }

    public HashSet<File> Entries => new(entries);

    public string Filename => filename;

    // getter methods omitted for brevity
}
