using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Twitter.Models.Media {

    /// <summary>
    /// Class representing a collection of different sizes of a given media.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.twitter.com/en/docs/tweets/data-dictionary/overview/entities-object#media-size</cref>
    /// </see>
    public class TwitterMediaSizes : TwitterObject, IEnumerable<TwitterMediaSize> {

        private readonly TwitterMediaSize[] _all;

        #region Properties

        /// <summary>
        /// Gets a reference to the <c>small</c> media format.
        /// </summary>
        public TwitterMediaSize Small { get; }

        /// <summary>
        /// Gets a reference to the <c>thumb</c> media format.
        /// </summary>
        public TwitterMediaSize Thumb { get; }

        /// <summary>
        /// Gets a reference to the <c>medium</c> media format.
        /// </summary>
        public TwitterMediaSize Medium { get; }

        /// <summary>
        /// Gets a reference to the <c>large</c> media format.
        /// </summary>
        public TwitterMediaSize Large { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of <see cref="TwitterMediaSizes"/> parsed from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The <see cref="JObject"/> to be parsed.</param>
        protected TwitterMediaSizes(JObject obj) : base(obj) {
            Small = obj.GetObject("small", TwitterMediaSize.Parse);
            Thumb = obj.GetObject("thumb", TwitterMediaSize.Parse);
            Medium = obj.GetObject("medium", TwitterMediaSize.Parse);
            Large = obj.GetObject("large", TwitterMediaSize.Parse);
            _all = new[] {Small, Thumb, Medium, Large};
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets an instance of <see cref="IEnumerator{TwitterMediaFormat}"/> for iterating through the sizez of the media.
        /// </summary>
        /// <returns></returns>
        public IEnumerator<TwitterMediaSize> GetEnumerator() {
            return ((IEnumerable<TwitterMediaSize>) _all).GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator() {
            return GetEnumerator();
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="TwitterMediaSizes"/> from the specified <see cref="JObject"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="TwitterMediaSizes"/>.</returns>
        public static TwitterMediaSizes Parse(JObject obj) {
            return obj == null ? null : new TwitterMediaSizes(obj);
        }

        #endregion

    }

}