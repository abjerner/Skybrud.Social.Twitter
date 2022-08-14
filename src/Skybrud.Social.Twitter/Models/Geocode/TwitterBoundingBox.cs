using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Twitter.Models.Geocode {

    /// <summary>
    /// Class representing a bounding box as returned by the Twitter API.
    /// </summary>
    public class TwitterBoundingBox : TwitterObject {

        #region Properties

        /// <summary>
        /// The type of the bounding box.
        /// </summary>
        public string Type { get; }

        /// <summary>
        /// The set of coordinates describing the bounding box.
        /// </summary>
        public IReadOnlyList<IReadOnlyList<TwitterCoordinates>> Coordinates { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of <see cref="TwitterBoundingBox"/> parsed from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The <see cref="JObject"/> to be parsed.</param>
        protected TwitterBoundingBox(JObject obj) : base(obj) {
            Type = obj.GetString("type");
            Coordinates = ParseCoordinates(obj.GetArray("coordinates"));
        }

        #endregion

        #region Static methods

        private static IReadOnlyList<IReadOnlyList<TwitterCoordinates>> ParseCoordinates(JArray array) {

            IReadOnlyList<TwitterCoordinates>[] temp = new IReadOnlyList<TwitterCoordinates>[array.Count];

            for (int i = 0; i < array.Count; i++) {
                temp[i] = TwitterCoordinates.ParseMultiple(array.GetArray(i));
            }

            return temp;

        }

        /// <summary>
        /// Gets an instance of <see cref="TwitterBoundingBox"/> from the specified <see cref="JObject"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="TwitterBoundingBox"/>.</returns>
        public static TwitterBoundingBox Parse(JObject obj) {
            return obj == null ? null : new TwitterBoundingBox(obj);
        }

        #endregion

    }

}