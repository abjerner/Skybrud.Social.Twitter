using System;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

// ReSharper disable UseArrayEmptyMethod

namespace Skybrud.Social.Twitter.Models.Geocode {

    /// <summary>
    /// Class representing the coordinates of a point used in the Twitter API.
    /// </summary>
    public class TwitterCoordinates : TwitterObject {

#if NET46_OR_GREATER || NETSTANDARD1_3_OR_GREATER
        // TODO: Use this instead when available: https://github.com/skybrud/Skybrud.Essentials/issues/40
        private static readonly TwitterCoordinates[] _empty = Array.Empty<TwitterCoordinates>();
#else
        private static readonly TwitterCoordinates[] _empty = new TwitterCoordinates[0];
#endif

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
        /// Initializes a new instance of <see cref="TwitterCoordinates"/> parsed from the specified <paramref name="array"/>.
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
            return array == null ? null : new TwitterCoordinates(array);
        }

        /// <summary>
        /// Parses an instance of <see cref="JArray"/> with multiple points into an array of <see cref="TwitterCoordinates"/>.
        /// </summary>
        /// <param name="array">The instance of <see cref="JArray"/> to parse.</param>
        /// <returns>An array of <see cref="TwitterCoordinates"/>.</returns>
        public static IReadOnlyList<TwitterCoordinates> ParseMultiple(JArray array) {
            if (array == null) return _empty;
            TwitterCoordinates[] temp = new TwitterCoordinates[array.Count];
            for (int i = 0; i < array.Count; i++) {
                temp[i] = Parse(array.GetArray(i));
            }
            return temp;
        }

        #endregion

    }

}