using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Twitter.OAuth;
using Skybrud.Social.Twitter.Options.Search;

namespace Skybrud.Social.Twitter.Endpoints.Raw {

    /// <summary>
    /// Class representing the raw implementation of the <strong>Search</strong> endpoint.
    /// </summary>
    public class TwitterSearchRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the OAuth 1.0a client.
        /// </summary>
        public TwitterOAuthClient Client { get; }

        #endregion

        #region Constructors

        internal TwitterSearchRawEndpoint(TwitterOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets tweets matching the specified <paramref name="query"/>.
        /// </summary>
        /// <param name="query">The search query.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/search/api-reference/get-search-tweets</cref>
        /// </see>
        public IHttpResponse SearchTweets(string query) {
            if (string.IsNullOrWhiteSpace(query)) throw new ArgumentNullException(nameof(query));
            return SearchTweets(query, 0);
        }

        /// <summary>
        /// Gets tweets matching the specified <paramref name="query"/>.
        /// </summary>
        /// <param name="query">The search query.</param>
        /// <param name="count">The maximum amount of tweets to return (default: 15, max: 100).</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/search/api-reference/get-search-tweets</cref>
        /// </see>
        public IHttpResponse SearchTweets(string query, int count) {
            if (string.IsNullOrWhiteSpace(query)) throw new ArgumentNullException(nameof(query));
            return SearchTweets(new TwitterSearchTweetOptions(query, count));
        }

        /// <summary>
        /// Gets tweets matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The search options.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/tweets/search/api-reference/get-search-tweets</cref>
        /// </see>
        public IHttpResponse SearchTweets(TwitterSearchTweetOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        #endregion

    }

}