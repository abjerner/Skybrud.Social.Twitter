using Skybrud.Social.Twitter.Endpoints.Raw;
using Skybrud.Social.Twitter.Options.Users;
using Skybrud.Social.Twitter.Responses.Users;

namespace Skybrud.Social.Twitter.Endpoints {

    /// <summary>
    /// Class representing the implementation of the <strong>Users</strong> endpoint.
    /// </summary>
    public class TwitterUsersEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the Twitter service.
        /// </summary>
        public TwitterHttpService Service { get; }

        /// <summary>
        /// Gets a reference to the raw users endpoint.
        /// </summary>
        public TwitterUsersRawEndpoint Raw => Service.Client.Users;

        #endregion

        #region Constructors

        internal TwitterUsersEndpoint(TwitterHttpService service) {
            Service = service;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets information about the user with the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>An instance of <see cref="TwitterUserResponse"/> representing the response.</returns>
        public TwitterUserResponse GetUser(long userId) {
            return new TwitterUserResponse(Raw.GetUser(userId, false));
        }

        /// <summary>
        /// Gets information about the user with the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="includeEntities">Whether entities should be included in the API response.</param>
        /// <returns>An instance of <see cref="TwitterUserResponse"/> representing the response.</returns>
        public TwitterUserResponse GetUser(long userId, bool includeEntities) {
            return new TwitterUserResponse(Raw.GetUser(userId, includeEntities));
        }

        /// <summary>
        /// Gets information about the user with the specified <paramref name="screenName"/>.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        /// <returns>An instance of <see cref="TwitterUserResponse"/> representing the response.</returns>
        public TwitterUserResponse GetUser(string screenName) {
            return new TwitterUserResponse(Raw.GetUser(screenName, false));
        }

        /// <summary>
        /// Gets information about the user with the specified <paramref name="screenName"/>.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        /// <param name="includeEntities">Whether entities should be included in the API response.</param>
        /// <returns>An instance of <see cref="TwitterUserResponse"/> representing the response.</returns>
        public TwitterUserResponse GetUser(string screenName, bool includeEntities) {
            return new TwitterUserResponse(Raw.GetUser(screenName, includeEntities));
        }

        /// <summary>
        /// Gets information about the user matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="TwitterUserResponse"/> representing the response.</returns>
        public TwitterUserResponse GetUser(TwitterGetUserOptions options) {
            return new TwitterUserResponse(Raw.GetUser(options));
        }

        /// <summary>
        /// Provides a simple, relevance-based search interface to public user
        /// accounts on Twitter. Try querying by topical interest, full name,
        /// company name, location, or other criteria. Exact match searches are
        /// not supported.
        /// </summary>
        /// <param name="query">The search query to run against people search.</param>
        /// <returns>An instance of <see cref="TwitterUserListResponse"/> representing the response.</returns>
        public TwitterUserListResponse Search(string query) {
            return Search(new TwitterSearchUsersOptions {
                Query = query
            });
        }

        /// <summary>
        /// Provides a simple, relevance-based search interface to public user
        /// accounts on Twitter. Try querying by topical interest, full name,
        /// company name, location, or other criteria. Exact match searches are
        /// not supported.
        /// </summary>
        /// <param name="options">The search options.</param>
        /// <returns>An instance of <see cref="TwitterUserListResponse"/> representing the response.</returns>
        public TwitterUserListResponse Search(TwitterSearchUsersOptions options) {
            return new TwitterUserListResponse(Raw.Search(options));
        }

        #endregion

    }

}