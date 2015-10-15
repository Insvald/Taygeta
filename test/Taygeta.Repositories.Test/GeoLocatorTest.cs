// The Taygeta Project
// (c) 2015 Ilya Rovensky

using Xunit;

namespace Taygeta.Repositories.Test
{    
    public class GeoLocatorTest
    {
        [Fact]
        public void CheckThatGetLocationByIpCorrectlyDeterminesLocations()
        {
            string county;
            string city;

            GeoLocator locator = new GeoLocator();
            
            Assert.True(locator.GetLocationByIp("5.22.129.156", out county, out city));
            Assert.Equal("Israel", county);
            Assert.Equal("Tel Aviv", city);

            Assert.True(locator.GetLocationByIp("221.0.0.1", out county, out city));
            Assert.Equal("China", county);
            Assert.Equal("Jinan", city);

            Assert.True(locator.GetLocationByIp("121.0.0.1", out county, out city));
            Assert.Equal("Australia", county);
            Assert.Equal("Townsville", city);

            Assert.True(locator.GetLocationByIp("21.0.0.1", out county, out city));
            Assert.Equal("United States", county);
            Assert.True(city.Contains("Columbus"));

            Assert.True(locator.GetLocationByIp("81.0.0.1", out county, out city));
            Assert.Equal("Spain", county);
            Assert.True(city.Contains("San Sebasti"));
        }
    }
}
