namespace APBD_TASK2.Models;

public class Projector : Equipment
{
    public override string Description { get; set; }
    public int Brightness { get; set; }
    public bool Has4KSupport { get; set; }

    public Projector(string name, int lumens, bool has4KSupport)
        : base(name)
    {
        Brightness = lumens;
        Has4KSupport = has4KSupport;
    }
}