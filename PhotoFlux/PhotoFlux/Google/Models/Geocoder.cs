using System.Collections.Generic;


namespace PhotoFlux.Google.Models
{

    public class Geocoder
    {
        public List<GoogleGeocoderResult> Results { get; set; }
    }


    public class GoogleGeocoderResult
    {
        public GoogleGeometry Geometry { get; set; }
    }


    public class GoogleGeometry
    {
        public GoogleLocation Location { get; set; }
    }


    public class GoogleLocation
    {
        public decimal Lat { get; set; }
        public decimal Lng { get; set; }
    }

}
