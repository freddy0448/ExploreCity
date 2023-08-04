using SQLite;

namespace ExploreCity.Models
{
    public class PinModel
    {
        [PrimaryKey, AutoIncrement]
        public Location Coordinates { get; set; }
        public string Address { get; set; }
        public string LabelDescription { get; set; }
    }
}
