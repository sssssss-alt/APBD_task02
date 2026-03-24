namespace APBD_TASK2.Models;
using APBD_TASK2.Enum;

public abstract class Equipment
{
    private static int _nextId = 1;
    
    public int Id { get; }
    
    public string Name { get; set; }
    
    public abstract string Description { get; set; }

    public EquipmentStatus Status { get; set; } = EquipmentStatus.Available;
    
    public DateTime AddedDate { get; set; }

    public Equipment(string name, string description = "")
    {
        Id = _nextId++;
        Name = name;
        Description = description;
        Status = EquipmentStatus.Available;
        AddedDate = DateTime.Now;
    }
}