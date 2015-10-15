// The Taygeta Project
// (c) 2015 Ilya Rovensky

namespace Taygeta.Repositories
{
    /// <summary>
    /// Class for locating IP addresses
    /// </summary>
    public interface IGeoLocator
    {
        /// <summary>
        /// Gets location of an IP address from ip-api.com free geolocation service
        /// </summary>
        /// <param name="ipAddress">the client's IP address</param>
        /// <param name="country">a located country</param>
        /// <param name="city">a located city, if any</param>
        /// <returns>true, if the search successful, false otherwise</returns>
        bool GetLocationByIp(string ipAddress, out string country, out string city);
    }
}
