

using APBD_TASK2.Database;
using APBD_TASK2.Models;

var db = Singleton.Instance;

var Laptop = new Laptop("Dell XPS 15", 2, 13);
db.Equipment.Add(Laptop);