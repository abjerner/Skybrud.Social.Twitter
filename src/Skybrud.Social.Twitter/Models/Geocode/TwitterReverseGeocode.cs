using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Twitter.Models.Geocode {

    /// <summary>
    /// Class representing the result of a reverse geocode request.
    /// </summary>
    public class TwitterReverseGeocode : TwitterObject {

        #region Properties

        /// <summary>
        /// Gets information about the query.
        /// </summary>
        public TwitterReverseGeocodeQuery Query { get; }

        /// <summary>
        /// Gets a reference to the result of the reverse geocode search.
        /// </summary>
        public TwitterReverseGeocodeResult Result { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of <see cref="TwitterReverseGeocode"/> parsed from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The <see cref="JObject"/> to be parsed.</param>
        protected TwitterReverseGeocode(JObject obj) : base(obj) {
            Query = obj.GetObject("query", TwitterReverseGeocodeQuery.Parse);
            Result = obj.GetObject("result", TwitterReverseGeocodeResult.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="TwitterReverseGeocode"/> from the specified <see cref="JObject"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="TwitterReverseGeocode"/>.</returns>
        public static TwitterReverseGeocode Parse(JObject obj) {
            return obj == null ? null : new TwitterReverseGeocode(obj);
        }

        #endregion

    }

}