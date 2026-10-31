namespace MovieTicket.DeepDive;

public class SeatLockManager {
    private readonly Dictionary<string, SeatLock> lockedSeats = new();
    private readonly TimeSpan lockDuration;
    // C# replacement for Java's synchronized methods
    private readonly object syncRoot = new();
    
    public SeatLockManager(TimeSpan lockDuration) {
        this.lockDuration = lockDuration;
    }
    
    public bool LockSeat(Screening screening, Seat seat, string userId) {
        lock (syncRoot) {
        string lockKey = GenerateLockKey(screening, seat);
        
        // Clean up lock if expired (on-demand cleanup when another process attempts to lock)
        CleanupLockIfExpired(lockKey);
        // Check if a seat is already locked
        if (IsLocked(screening, seat)) {
            return false;
        }
        
        // Create a new lock with expiration time
        SeatLock seatLock = new SeatLock(userId, DateTime.Now + lockDuration);
        lockedSeats[lockKey] = seatLock;
        return true;
        }
    }
    
    public bool IsLocked(Screening screening, Seat seat) {
        lock (syncRoot) {
        string lockKey = GenerateLockKey(screening, seat);
        
        // Clean up lock if expired (on-demand cleanup)
        CleanupLockIfExpired(lockKey);
        
        // If we reach here, either no lock exists or it's valid
        return lockedSeats.ContainsKey(lockKey);
        }
    }
    
    private void CleanupLockIfExpired(string lockKey) {
        SeatLock seatLock = lockedSeats.GetValueOrDefault(lockKey);
        if (seatLock != null && seatLock.IsExpired) {
            lockedSeats.Remove(lockKey);
        }
    }
    
    private string GenerateLockKey(Screening screening, Seat seat) {
        return screening.Id + "-" + seat.SeatNumber;
    }
    
    // SeatLock inner class
    private class SeatLock {
        private readonly string userId;
        private readonly DateTime expirationTime;
        
        public SeatLock(string userId, DateTime expirationTime) {
            this.userId = userId;
            this.expirationTime = expirationTime;
        }
        
        public bool IsExpired => DateTime.Now > expirationTime;
        
        public string UserId => userId;
    }
}
