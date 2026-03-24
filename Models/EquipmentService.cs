using APBD_TASK2.Database;
using APBD_TASK2.Enum;

namespace APBD_TASK2.Models;

public class EquipmentService
{
    private readonly Singleton _db = Singleton.Instance;

    public void AddEquipment(Equipment equipment)
    {
        _db.Equipments.Add(equipment);
    }

    public List<Equipment> GetAllEquipments()
    {
        return _db.Equipments.ToList();
    }

    public List<Equipment> GetAvailableEquipments()
    {
        return _db.Equipments.Where(e => e.Status == EquipmentStatus.Available).ToList();
    }

    public void MarkUnavailable(int equipmentId)
    {
        var equipment = _db.Equipments.FirstOrDefault(e => e.Id == equipmentId);

        if (equipment == null) throw new Exception("Equipment not found.");
        if (equipment.Status == EquipmentStatus.Rented) throw new Exception("Equipment is currently rented.");

        equipment.Status = EquipmentStatus.Unavailable;
    }
}