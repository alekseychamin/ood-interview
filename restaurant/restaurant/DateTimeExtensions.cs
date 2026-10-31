namespace RestaurantSystem;

// Replacement for Java's LocalDateTime.truncatedTo(ChronoUnit.HOURS)
public static class DateTimeExtensions {
    public static DateTime TruncatedToHours(this DateTime time) {
        return new DateTime(time.Year, time.Month, time.Day, time.Hour, 0, 0, time.Kind);
    }
}
