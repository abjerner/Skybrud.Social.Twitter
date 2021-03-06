using Skybrud.Social.Twitter.Endpoints.Raw;
using Skybrud.Social.Twitter.Options;
using Skybrud.Social.Twitter.Options.Search;
using Skybrud.Social.Twitter.Responses;
using Skybrud.Social.Twitter.Responses.Search;

namespace Skybrud.Social.Twitter.Endpoints {

    /// <summary>
    /// Class representing the implementation of the <strong>Lists</strong> endpoint.
    /// </summary>
    public class TwitterSearchEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Twitter service.
        /// </summary>
        public TwitterService Service { get; }

        /// <summary>
        /// Gets a reference to the raw endpoint.
        /// </summary>
        public TwitterSearchRawEndpoint Raw => Service.Client.Search;

        #endregion

        #region Constructors

        internal TwitterSearchEndpoint(TwitterService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets tweets matching the specified <paramref name="query"/>.
        /// </summary>
        /// <param name="query">The search query.</param>
        /// <returns>An instance of <see cref="TwitterSearchTweetsResponse"/> representing the response.</returns>
        public TwitterSearchTweetsResponse SearchTweets(string query) {
            return TwitterSearchTweetsResponse.ParseResponse(Raw.SearchTweets(query)); 
        }

        /// <summary>
        /// Gets tweets matching the specified <paramref name="query"/>.
        /// </summary>
        /// <param name="query">The search query.</param>
        /// <param name="count">The maximum amount of tweets to return (default: 15, max: 100).</param>
        /// <returns>An instance of <see cref="TwitterSearchTweetsResponse"/> representing the response.</returns>
        public TwitterSearchTweetsResponse SearchTweets(string query, int count) {
            return TwitterSearchTweetsResponse.ParseResponse(Raw.SearchTweets(query, count)); 
        }

        /// <summary>
        /// Gets tweets matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The search options.</param>
        /// <returns>An instance of <see cref="TwitterSearchTweetsResponse"/> representing the response.</returns>
        public TwitterSearchTweetsResponse SearchTweets(TwitterSearchTweetOptions options) {
            return TwitterSearchTweetsResponse.ParseResponse(Raw.SearchTweets(options)); 
        }

        #endregion

    }

}