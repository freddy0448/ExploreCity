using SQLite;

namespace ExploreCity.Models
{
    public class PinModel
    {
        public string Address { get; set; }
        public string LabelDescription { get; set; }
        public double Latitude { get; set; }
        [PrimaryKey]
        public double Longitude { get; set; }
        public string PlaceDescription { get; set; }
        public string ImageFullPath { get; set; }

        [Ignore]
        public Location Coordinates { get; set; }
        public PinModel()
        {
            Coordinates = new Location()
            {
                Latitude = Latitude,
                Longitude = Longitude,
            };
        }
    }
}
