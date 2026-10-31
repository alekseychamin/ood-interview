namespace Atm;

public class CryptographicException : Exception {
    public CryptographicException(string message, Exception cause) : base(message, cause) {
    }
}
