namespace APBD_TASK2.Models;

public class Rental
{
    private static int _nextId = 1;

    public int Id { get; }
    public User User { get; }
    public Equipment Equipment { get; }
    public DateTime RentalDate { get; }
    public DateTime DueDate { get; }
    public DateTime? ReturnDate { get; private set; }
    public decimal Penalty { get; private set; }

    public bool IsReturned => ReturnDate.HasValue;
    public bool IsOverdue => !IsReturned && DateTime.Now > DueDate;

    public Rental(User user, Equipment equipment, int rentalDays)
    {
        Id = _nextId++;
        User = user;
        Equipment = equipment;
        RentalDate = DateTime.Now;
        DueDate = RentalDate.AddDays(rentalDays);
        ReturnDate = null;
        Penalty = 0;
    }

    public void CompleteReturn()
    {
        ReturnDate = DateTime.Now;

        if (ReturnDate > DueDate)
        {
            int daysLate = (int)(ReturnDate.Value - DueDate).TotalDays;
            Penalty = daysLate * 10m;
        }
    }
}