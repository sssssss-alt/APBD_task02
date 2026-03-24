

using APBD_TASK2.Database;
using APBD_TASK2.Enum;
using APBD_TASK2.Models;

var db = Singleton.Instance;

var equipmentService = new EquipmentService();
var userService = new UserService();
var rentalService = new RentalService();
var reportService = new ReportService();

equipmentService.AddEquipment(new Laptop("Dell XPS 15", 2, 13));
equipmentService.AddEquipment(new Camera("Sony15K", 2000, 100));
equipmentService.AddEquipment(new Projector("Sonylul", 120, true));


userService.AddUser(new User("Orest", "Tryndyak", UserType.Student));
userService.AddUser(new User("Dima", "Syrotkin", UserType.Teacher));

rentalService.Rent(1, 1, 7);
//invalid operation(that equipment aalready rented):
try
{
    rentalService.Rent(2, 1, 7);
}
catch (Exception e)
{
    Console.WriteLine($"Error: {e.Message}");
}

rentalService.ReturnEquipment(1);

Console.WriteLine();
reportService.GenerateReport();