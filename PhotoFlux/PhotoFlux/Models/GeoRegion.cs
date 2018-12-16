using PhotoFlux.Domain;


namespace PhotoFlux.Models
{

    public class GeoRegion : IGeoRegion
    {

        public decimal Latitude { get; }
        public decimal Longitude { get; }
        public double RadiusInKm { get; }


        public GeoRegion(decimal? latitude, decimal? longitude, double? radiusInKm)
        {
            this.Latitude = latitude ?? 0.0m;
            this.Longitude = longitude ?? 0.0m;
            this.RadiusInKm = radiusInKm ?? 0.0d;
        }


        public bool IsValid()
        {
            return Latitude >= -90m && Latitude <= 90m
                && Longitude >= -180m && Longitude <= 180m
                && RadiusInKm >= 0
                && (!(Latitude == 0.0m && Longitude == 0.0m && RadiusInKm == 0.0d));
        }
    }
}
