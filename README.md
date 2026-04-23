# CarpoolingApp

CarpoolingApp is a small ASP.NET Core MVC project that allows users to share trips and book seats.  
The idea is simple: drivers can post a trip, and passengers can look for a trip going in the same direction and reserve seats.  
The project is kept intentionally straightforward so it’s easy to understand and explain, while still covering the main concepts of MVC, EF Core, and Identity.

---

## What the application does

- Users can register and log in
- Drivers can create trips with a start point, destination, date, time, and available seats
- Anyone can browse and search for trips
- Logged‑in users can book seats on a trip
- The system automatically calculates how many seats are left
- (Optional) Admin users can view simple statistics

---

## Technologies used

- ASP.NET Core MVC  
- Entity Framework Core (Code‑First)  
- ASP.NET Identity  
- SQL Server  
- Razor Views  
- Bootstrap  
---

## Database

The project uses Entity Framework Core with a Code‑First approach.  
The main tables are:

- AspNetUsers (from Identity)
- Trips
- Bookings

Relationships:

- One driver can create many trips  
- One trip can have many bookings  
- One user can make many bookings  