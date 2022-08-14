using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Twitter.Models.Statuses;

namespace Skybrud.Social.Twitter.Models.Search {

    /// <summary>
    /// Class representing the result of a tweet search.
    /// </summary>
    public class TwitterSearchTweetsResult : TwitterObject {

        #region Properties

        /// <summary>
        /// Gets a list of the status messages returned by the search.
        /// </summary>
        public IReadOnlyList<TwitterStatusMessage> Statuses { get; }

        /// <summary>
        /// Gets a reference to some meta data about the search.
        /// </summary>
        public TwitterSearchTweetsMetaData MetaData { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of <see cref="TwitterSearchTweetsResult"/> parsed from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The <see cref="JObject"/> to be parsed.</param>
        protected TwitterSearchTweetsResult(JObject obj) : base(obj) {
            Statuses = obj.GetArray("statuses", TwitterStatusMessage.Parse);
            MetaData = obj.GetObject("search_metadata", TwitterSearchTweetsMetaData.Parse);
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="TwitterSearchTweetsResult"/> from the specified <see cref="JObject"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="TwitterSearchTweetsResult"/>.</returns>
        public static TwitterSearchTweetsResult Parse(JObject obj) {
            return obj == null ? null : new TwitterSearchTweetsResult(obj);
        }

        #endregion

    }

}