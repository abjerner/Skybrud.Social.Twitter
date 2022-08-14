using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Twitter.Models.Geocode {

    /// <summary>
    /// Class representing a reverse geocode result
    /// </summary>
    public class TwitterReverseGeocodeResult : TwitterObject {

        #region Properties

        /// <summary>
        /// Gets a list of the matched places.
        /// </summary>
        public IReadOnlyList<TwitterPlace> Places { get; }

        #endregion

        #region Constructors

        private TwitterReverseGeocodeResult(JObject json) : base(json) {
            Places = json.GetArray("places", TwitterPlace.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="json"/> object into an instance of <see cref="TwitterReverseGeocodeResult"/>.
        /// </summary>
        /// <param name="json">The JSON object to be parsed.</param>
        /// <returns>An instance of <see cref="TwitterReverseGeocodeResult"/>.</returns>
        public static TwitterReverseGeocodeResult Parse(JObject json) {
            return json == null ? null : new TwitterReverseGeocodeResult(json);
        }

        #endregion

    }

}