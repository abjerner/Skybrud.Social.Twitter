using System;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Social.Twitter.OAuth;
using Skybrud.Social.Twitter.Options.Users;

namespace Skybrud.Social.Twitter.Endpoints.Raw {

    /// <summary>
    /// Class representing the raw implementation of the <strong>Users</strong> endpoint.
    /// </summary>
    public class TwitterUsersRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the OAuth 1.0a client.
        /// </summary>
        public TwitterOAuthClient Client { get; }

        #endregion

        #region Constructors

        internal TwitterUsersRawEndpoint(TwitterOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        #region GetUser(...)

        /// <summary>
        /// Gets information about the user with the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/accounts-and-users/follow-search-get-users/api-reference/get-users-show</cref>
        /// </see>
        public IHttpResponse GetUser(long userId) {
            return GetUser(new TwitterGetUserOptions(userId));
        }

        /// <summary>
        /// Gets information about the user with the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="includeEntities">Whether entities should be included in the API response.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/accounts-and-users/follow-search-get-users/api-reference/get-users-show</cref>
        /// </see>
        public IHttpResponse GetUser(long userId, bool includeEntities) {
            return GetUser(new TwitterGetUserOptions(userId, includeEntities));
        }

        /// <summary>
        /// Gets information about the user with the specified <paramref name="screenName"/>.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="screenName"/> is not specified.</exception>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/accounts-and-users/follow-search-get-users/api-reference/get-users-show</cref>
        /// </see>
        public IHttpResponse GetUser(string screenName) {
            if (String.IsNullOrWhiteSpace(screenName)) throw new ArgumentNullException(nameof(screenName));
            return GetUser(new TwitterGetUserOptions(screenName));
        }

        /// <summary>
        /// Gets information about the user with the specified <paramref name="screenName"/>.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        /// <param name="includeEntities">Whether entities should be included in the API response.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="screenName"/> is not specified.</exception>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/accounts-and-users/follow-search-get-users/api-reference/get-users-show</cref>
        /// </see>
        public IHttpResponse GetUser(string screenName, bool includeEntities) {
            if (String.IsNullOrWhiteSpace(screenName)) throw new ArgumentNullException(nameof(screenName));
            return GetUser(new TwitterGetUserOptions(screenName, includeEntities));
        }

        /// <summary>
        /// Gets information about the user matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <exception cref="ArgumentNullException">If <paramref name="options"/> is <c>null</c>.</exception>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/accounts-and-users/follow-search-get-users/api-reference/get-users-show</cref>
        /// </see>
        public IHttpResponse GetUser(TwitterGetUserOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.DoHttpGetRequest("https://api.twitter.com/1.1/users/show.json", options);
        }

        #endregion

        #region Search(...)

        /// <summary>
        /// Provides a simple, relevance-based search interface to public user accounts on Twitter. Try querying by
        /// topical interest, full name, company name, location, or other criteria. Exact match searches are not
        /// supported.
        /// 
        /// Only the first 1,000 matching results are available.
        /// </summary>
        /// <param name="query">The search query to run against people search.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/accounts-and-users/follow-search-get-users/api-reference/get-users-search</cref>
        /// </see>
        public IHttpResponse Search(string query) {
            return Search(new TwitterSearchUsersOptions {
                Query = query
            });
        }

        /// <summary>
        /// Provides a simple, relevance-based search interface to public user accounts on Twitter. Try querying by
        /// topical interest, full name, company name, location, or other criteria. Exact match searches are not
        /// supported.
        /// 
        /// Only the first 1,000 matching results are available.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/accounts-and-users/follow-search-get-users/api-reference/get-users-search</cref>
        /// </see>
        public IHttpResponse Search(TwitterSearchUsersOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            if (!String.IsNullOrWhiteSpace(options.Query)) throw new PropertyNotSetException(nameof(options.Query));
            return Client.DoHttpGetRequest("https://api.twitter.com/1.1/users/search.json", options);
        }

        #endregion

        #endregion

    }

}