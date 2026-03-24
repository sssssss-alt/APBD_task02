namespace APBD_TASK2.Models;



public class Laptop : Equipment
{
    public override string Description { get; set; }
    public int RamGB { get; set; }

    public int ScreenSize { get; set; }

    public Laptop(string name, int ram, int screen)
            : base(name)
    {
        RamGB = ram;
        ScreenSize = screen;
    }


}
