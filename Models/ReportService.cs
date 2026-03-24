using APBD_TASK2.Database;
using APBD_TASK2.Enum;

namespace APBD_TASK2.Models;

public class ReportService
{
    private readonly Singleton _db = Singleton.Instance;

    public void GenerateReport()
    {
        Console.WriteLine("===== REPORT =====");
        Console.WriteLine($"Equipment: {_db.Equipments.Count} total, {_db.Equipments.Count(e => e.Status == EquipmentStatus.Available)} available");
        Console.WriteLine($"Users: {_db.Users.Count} total");
        Console.WriteLine($"Rentals: {_db.Rentals.Count} total, {_db.Rentals.Count(r => !r.IsReturned)} active, {_db.Rentals.Count(r => r.IsOverdue)} overdue");
        Console.WriteLine($"Penalties collected: {_db.Rentals.Sum(r => r.Penalty)} PLN");
        Console.WriteLine("==================");
    }
}