

using APBD_TASK2.Database;
using APBD_TASK2.Models;

var db = Singleton.Instance;

var Laptop = new Laptop("Dell XPS 15", 2, 13);
var Camera = new Camera("Sony15K", 2000, 100);
var Projector = new Projector("Sonylul", 120, true);
//db.Equipment.Add(Laptop);