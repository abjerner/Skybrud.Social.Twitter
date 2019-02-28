using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;
using Skybrud.Essentials.Strings.Extensions;
using Skybrud.Social.Twitter.Models.Geocode;

namespace Skybrud.Social.Twitter.Options.Geocode {
    
    /// <summary>
    /// Class with options for performing a reverse geocode lookup for places in the Twitter API.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.twitter.com/en/docs/geo/places-near-location/api-reference/get-geo-reverse_geocode</cref>
    /// </see>
    public class TwitterReverseGeocodeOptions : IHttpGetOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the latitude to search around. The valid ranges for latitude are <c>-90.0</c> to <c>+90.0</c>
        /// (North is positive) inclusive.
        /// </summary>
        public double Latitude { get; set; }

        /// <summary>
        /// Gets or sets the longitude to search around. The valid ranges for longitude are <c>-180.0</c> to
        /// <c>+180.0</c> (East is positive) inclusive.
        /// </summary>
        public double Longitude { get; set; }

        /// <summary>
        /// A hint on the "region" in which to search. If a number, then this is a radius in meters, but it can also
        /// take a string that is suffixed with ft to specify feet. If this is not passed in, then it is assumed to be
        /// <c>0m</c>. If coming from a device, in practice, this value is whatever accuracy the device has
        /// measuring its location (whether it be coming from a GPS, WiFi triangulation, etc.).
        /// </summary>
        public string Accurary { get; set; }

        /// <summary>
        /// This is the minimal granularity of place types to return and must be one of:
        /// <see cref="TwitterGranularity.Poi"/>, <see cref="TwitterGranularity.Neighborhood"/>,
        /// <see cref="TwitterGranularity.City"/>, <see cref="TwitterGranularity.Admin"/> or
        /// <see cref="TwitterGranularity.Country"/>. If no granularity is provided for the request,
        /// <see cref="TwitterGranularity.Neighborhood"/> is assumed.
        /// 
        /// Setting this to <see cref="TwitterGranularity.City"/>, for example, will find places which have a type of
        /// <see cref="TwitterGranularity.City"/>, <see cref="TwitterGranularity.Admin"/> or
        /// <see cref="TwitterGranularity.Country"/>.
        /// </summary>
        public TwitterGranularity Granularity { get; set; }

        /// <summary>
        /// A hint as to the number of results to return. This does not guarantee that the number of results returned
        /// will equal max_results, but instead informs how many "nearby" results to return. Ideally, only pass in the
        /// number of places you intend to display to the user here.
        /// </summary>
        public int MaxResults { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public TwitterReverseGeocodeOptions() {
            Granularity = TwitterGranularity.Neighborhood;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="latitude"/> and <paramref name="longitude"/>.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        public TwitterReverseGeocodeOptions(double latitude, double longitude) {
            Latitude = latitude;
            Longitude = longitude;
            Granularity = TwitterGranularity.Neighborhood;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="latitude"/>, <paramref name="longitude"/> and
        /// <paramref name="accurary"/>.
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="accurary">The accuracy.</param>
        public TwitterReverseGeocodeOptions(double latitude, double longitude, string accurary) {
            Latitude = latitude;
            Longitude = longitude;
            Accurary = accurary;
            Granularity = TwitterGranularity.Neighborhood;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="latitude"/>,
        /// <paramref name="longitude"/>, <paramref name="accurary"/>, <paramref name="granularity"/> and
        /// <paramref name="maxResults"/>
        /// </summary>
        /// <param name="latitude">The latitude.</param>
        /// <param name="longitude">The longitude.</param>
        /// <param name="accurary">The accuracy.</param>
        /// <param name="granularity">The granularity.</param>
        /// <param name="maxResults">The maximum amout of places to be returned.</param>
        public TwitterReverseGeocodeOptions(double latitude, double longitude, string accurary, TwitterGranularity granularity, int maxResults) {
            Latitude = latitude;
            Longitude = longitude;
            Accurary = accurary;
            Granularity = granularity;
            MaxResults = maxResults;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Sets the accuracy to the specified <paramref name="meters"/>.
        /// </summary>
        /// <param name="meters">The accuracy in meters.</param>
        /// <returns>The original <see cref="TwitterReverseGeocodeOptions"/>.</returns>
        public TwitterReverseGeocodeOptions SetAccuraryInMeters(int meters) {
            Accurary = meters + "m";
            return this;
        }

        /// <summary>
        /// Sets the accuracy to the specified <paramref name="feet"/>.
        /// </summary>
        /// <param name="feet">The accuracy in feet.</param>
        /// <returns>The original <see cref="TwitterReverseGeocodeOptions"/>.</returns>
        public TwitterReverseGeocodeOptions SetAccuraryInFeet(int feet) {
            Accurary = feet + "ft";
            return this;
        }

        /// <summary>
        /// Gets an instance of <see cref="IHttpQueryString"/> representing the GET parameters.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpQueryString"/>.</returns>
        public IHttpQueryString GetQueryString() {

            // Initialize the query string
            IHttpQueryString query = new HttpQueryString();

            // Set required parameters
            query.Set("lat", Latitude);
            query.Set("long", Longitude);

            // Set optional parameters
            if (Accurary != null && Accurary != "0m") query.Set("accuracy", Accurary);
            if (Granularity != default(TwitterGranularity)) query.Set("granularity", Granularity.ToLower());
            if (MaxResults > 0) query.Set("max_results", MaxResults);

            return query;

        }

        #endregion
    
    }

}