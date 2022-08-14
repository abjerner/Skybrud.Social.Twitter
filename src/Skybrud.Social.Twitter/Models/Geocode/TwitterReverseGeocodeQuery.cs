using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Twitter.Models.Geocode {

    /// <summary>
    /// Class with information about a reverse geocode query as returned by the Twitter API.
    /// </summary>
    public class TwitterReverseGeocodeQuery : TwitterObject {

        #region Properties

        /// <summary>
        /// Gets the URL of the response.
        /// </summary>
        public string Url { get; }

        /// <summary>
        /// Gets the type of the response - probably always <c>reverse_geocode</c>.
        /// </summary>
        public string Type { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="json"/> object.
        /// </summary>
        /// <param name="json">The JSON object representing the query information.</param>
        protected TwitterReverseGeocodeQuery(JObject json) : base(json) {
            Url = json.GetString("url");
            Type = json.GetString("type");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="TwitterReverseGeocode"/>.
        /// </summary>
        /// <param name="json">The JSON object representing the query information.</param>
        /// <returns>An instance of <see cref="TwitterReverseGeocode"/>.</returns>
        public static TwitterReverseGeocodeQuery Parse(JObject json) {
            return new TwitterReverseGeocodeQuery(json);
        }

        #endregion

    }

}