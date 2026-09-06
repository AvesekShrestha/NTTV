namespace NTTV.Domain.Customer.ValueObjects;

public sealed class Location
{
  public float Latitude { get; private set; }
  public float Longitude { get; private set; }


  private Location(float latitude, float longitude)
  {
    Latitude = latitude;
    Longitude = longitude;
  }

  public static Location Create(float latitude, float longitude)
  {
    return new Location(latitude, longitude);
  }
}
