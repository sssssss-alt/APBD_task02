using APBD_TASK2.Database;
using APBD_TASK2.Enum;

namespace APBD_TASK2.Models;

public class RentalService
{
    private readonly Singleton _db = Singleton.Instance;

    public void Rent(int userId, int equipmentId, int rentalDays)
    {
        var user = _db.Users.FirstOrDefault(u => u.Id == userId);
        var equipment = _db.Equipments.FirstOrDefault(e => e.Id == equipmentId);

        if (user == null) throw new Exception("User not found.");
        if (equipment == null) throw new Exception("Equipment not found.");
        if (equipment.Status != EquipmentStatus.Available)
            throw new Exception("Equipment is not available.");

        var activeRentals = _db.Rentals.Count(r => r.User.Id == userId && !r.IsReturned);
        if (activeRentals >= user.MaxActiveRentals)
            throw new Exception($"User has reached the maximum of {user.MaxActiveRentals} active rentals.");

        equipment.Status = EquipmentStatus.Rented;
        _db.Rentals.Add(new Rental(user, equipment, rentalDays));
    }

    public void ReturnEquipment(int rentalId)
    {
        var rental = _db.Rentals.FirstOrDefault(r => r.Id == rentalId);

        if (rental == null) throw new Exception("Rental not found.");
        if (rental.IsReturned) throw new Exception("Equipment already returned.");

        rental.CompleteReturn();
        rental.Equipment.Status = EquipmentStatus.Available;

        if (rental.Penalty > 0)
            Console.WriteLine($"Late return. Penalty: {rental.Penalty} PLN");
    }

    public List<Rental> GetActiveRentalsForUser(int userId)
    {
        return _db.Rentals.Where(r => r.User.Id == userId && !r.IsReturned).ToList();
    }

    public List<Rental> GetOverdueRentals()
    {
        return _db.Rentals.Where(r => r.IsOverdue).ToList();
    }
}