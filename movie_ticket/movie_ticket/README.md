# Movie Ticket Booking System

This is a C#-based movie ticket booking system that allows users to manage cinemas, movies, screenings, and ticket bookings.

## Project Structure
```
movie_ticket/
├── MovieBookingSystem.cs
├── MovieBookingSystemTest.cs
├── location/
├── rate/
├── showing/
└── ticket/
```

## Running the Tests

```bash
# From repository root
dotnet test movie_ticket/MovieTicket.csproj
```

### What the Tests Cover

The test suite (`MovieBookingSystemTest.cs`) verifies the core functionality of the booking system:
- Creating a cinema with rooms and seating layouts
- Adding movies and screenings
- Managing seat availability
- Booking tickets
- Verifying ticket prices

### Test Output

A successful test run will show output similar to:
```
Test run finished after XX ms
[         4 containers found      ]
[         0 containers skipped    ]
[         4 containers started    ]
[         0 containers aborted    ]
[         4 containers successful ]
[         0 containers failed     ]
[         1 tests found           ]
[         0 tests skipped         ]
[         1 tests started         ]
[         0 tests aborted         ]
[         1 tests successful      ]
[         0 tests failed          ]
```
