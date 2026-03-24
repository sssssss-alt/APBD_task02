How to run
1. Clone the repository
2. Open in JetBrains Rider or Visual Studio
3. Run the project

You can:
- Add equipment (Laptop, Camera, Projector)
- Add users (Student, Teacher)
- Rent equipment to a user
- Return equipment
- Mark equipment as unavailable
- View active rentals for a user
- View overdue rentals
- Generate a summary report

Design decisions
Single responsibility: Each class has one clear job. RentalService handles rentals and returns, EquipmentService handles equipment management, ReportService only generates reports.
Cohesion: Rental-related logic stays in one place.
Coupling: All services access data through the Singleton instance and do not depend on each other.
Inheritance: Equipment is an abstract base class with Laptop, Camera and Projector as subclasses. All three share common properties.
