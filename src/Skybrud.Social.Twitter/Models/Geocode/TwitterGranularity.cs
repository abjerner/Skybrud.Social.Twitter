namespace Skybrud.Social.Twitter.Models.Geocode {

    /// <summary>
    /// Enum class representing the minimum granularity of location based searches.
    /// </summary>
    public enum TwitterGranularity {

        /// <summary>
        /// Indiciates that the granularity should be for the neighborhood.
        /// </summary>
        Neighborhood,

        /// <summary>
        /// <em>Not documented by Twitter.</em>
        /// </summary>
        Poi,

        /// <summary>
        /// Indiciates that the granularity should be for the city.
        /// </summary>
        City,

        /// <summary>
        /// Indiciates that the granularity should be for the admin.
        /// </summary>
        Admin,

        /// <summary>
        /// Indiciates that the granularity should be for the country.
        /// </summary>
        Country

    }

}