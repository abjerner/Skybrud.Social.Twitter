using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Twitter.Models.Search {

    /// <summary>
    /// Class with meta data about a Twitter search.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.twitter.com/en/docs/twitter-api/v1/tweets/search/api-reference/get-search-tweets</cref>
    /// </see>
    public class TwitterSearchTweetsMetaData : TwitterObject {

        #region Properties

        /// <summary>
        /// Gets the time in qhich the search was completed.
        /// </summary>
        public float CompletedIn { get; }

        /// <summary>
        /// Gets the maximum ID.
        /// </summary>
        public long MaxId { get; }

        /// <summary>
        /// gets the query.
        /// </summary>
        public string Query { get; }

        /// <summary>
        /// Gets the count.
        /// </summary>
        public int Count { get; }

        /// <summary>
        /// Gets the since ID.
        /// </summary>
        public long SinceId { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of <see cref="TwitterSearchTweetsMetaData"/> parsed from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The <see cref="JObject"/> to be parsed.</param>
        protected TwitterSearchTweetsMetaData(JObject obj) : base(obj) {
            CompletedIn = obj.GetFloat("completed_in");
            MaxId = obj.GetInt64("max_id");
            Query = obj.GetString("query");
            Count = obj.GetInt32("count");
            SinceId = obj.GetInt64("since_id");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="TwitterSearchTweetsMetaData"/> from the specified <see cref="JObject"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="TwitterSearchTweetsMetaData"/>.</returns>
        public static TwitterSearchTweetsMetaData Parse(JObject obj) {
            return obj == null ? null : new TwitterSearchTweetsMetaData(obj);
        }

        #endregion

    }

}