namespace APBD_TASK2.Models;

public class Camera : Equipment
{
    public override string Description { get; set; }
    public int Resolution { get; set; }
    public int Brightness { get; set; }

    public Camera(string name, int resolution, int brightness)
        : base(name)
    {
        Resolution = resolution;
        Brightness = brightness;
    }
}