using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Twitter.Models.Geocode {

    /// <summary>
    /// Class representing the coordinates of a point used in the Twitter API.
    /// </summary>
    public class TwitterCoordinates : TwitterObject {

        #region Properties

        /// <summary>
        /// Gets the latitude of the point.
        /// </summary>
        public double Latitude { get; }

        /// <summary>
        /// Gets the longitude of the point.
        /// </summary>
        public double Longitude { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of <see cref="TwitterCoordinates"/> parsed from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The <see cref="JObject"/> to be parsed.</param>
        protected TwitterCoordinates(JObject obj) : base(obj) {
            Latitude = obj.GetArray("coordinates").GetDouble(1);
            Longitude = obj.GetArray("coordinates").GetDouble(0);
        }

        /// <summary>
        /// Initializes a new instance of <see cref="TwitterCoordinates"/> parsed from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="array">The <see cref="JArray"/> to be parsed.</param>
        protected TwitterCoordinates(JArray array) : base(null) {
            Latitude = array.GetDouble(1);
            Longitude = array.GetDouble(0);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="TwitterCoordinates"/> from the specified <see cref="JObject"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="TwitterCoordinates"/>.</returns>
        public static TwitterCoordinates Parse(JObject obj) {
            return obj == null ? null : new TwitterCoordinates(obj);
        }

        /// <summary>
        /// Gets an instance of <see cref="TwitterCoordinates"/> from the specified <see cref="JArray"/>.
        /// </summary>
        /// <param name="array">The instance of <see cref="JArray"/> to parse.</param>
        /// <returns>An instance of <see cref="TwitterCoordinates"/>.</returns>
        public static TwitterCoordinates Parse(JArray array) {
            if (array == null) return null;
            return new TwitterCoordinates(array);
        }

        /// <summary>
        /// Parses an instance of <see cref="JArray"/> with multiple points into an array of <see cref="TwitterCoordinates"/>.
        /// </summary>
        /// <param name="array">The instance of <see cref="JArray"/> to parse.</param>
        /// <returns>An array of <see cref="TwitterCoordinates"/>.</returns>
        public static TwitterCoordinates[] ParseMultiple(JArray array) {
            if (array == null) return new TwitterCoordinates[0];
            TwitterCoordinates[] temp = new TwitterCoordinates[array.Count];
            for (int i = 0; i < array.Count; i++) {
                temp[i] = Parse(array.GetArray(i));
            }
            return temp;
        }

        #endregion

    }

}