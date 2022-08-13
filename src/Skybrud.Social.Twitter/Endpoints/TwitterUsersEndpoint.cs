using Skybrud.Social.Twitter.Endpoints.Raw;
using Skybrud.Social.Twitter.Options.Users;
using Skybrud.Social.Twitter.Responses;
using Skybrud.Social.Twitter.Responses.Users;

namespace Skybrud.Social.Twitter.Endpoints {

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
        /// <returns>An instance of <see cref="TwitterGetUserResponse"/> representing the response.</returns>
        public TwitterGetUserResponse GetUser(long userId) {
            return TwitterGetUserResponse.ParseResponse(Raw.GetUser(userId, false));
        }

        /// <summary>
        /// Gets information about the user with the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="includeEntities">Whether entities should be included in the API response.</param>
        /// <returns>An instance of <see cref="TwitterGetUserResponse"/> representing the response.</returns>
        public TwitterGetUserResponse GetUser(long userId, bool includeEntities) {
            return TwitterGetUserResponse.ParseResponse(Raw.GetUser(userId, includeEntities));
        }

        /// <summary>
        /// Gets information about the user with the specified <paramref name="screenName"/>.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        /// <returns>An instance of <see cref="TwitterGetUserResponse"/> representing the response.</returns>
        public TwitterGetUserResponse GetUser(string screenName) {
            return TwitterGetUserResponse.ParseResponse(Raw.GetUser(screenName, false));
        }

        /// <summary>
        /// Gets information about the user with the specified <paramref name="screenName"/>.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        /// <param name="includeEntities">Whether entities should be included in the API response.</param>
        /// <returns>An instance of <see cref="TwitterGetUserResponse"/> representing the response.</returns>
        public TwitterGetUserResponse GetUser(string screenName, bool includeEntities) {
            return TwitterGetUserResponse.ParseResponse(Raw.GetUser(screenName, includeEntities));
        }

        /// <summary>
        /// Gets information about the user matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="TwitterGetUserResponse"/> representing the response.</returns>
        public TwitterGetUserResponse GetUser(TwitterGetUserOptions options) {
            return TwitterGetUserResponse.ParseResponse(Raw.GetUser(options));
        }

        /// <summary>
        /// Provides a simple, relevance-based search interface to public user
        /// accounts on Twitter. Try querying by topical interest, full name,
        /// company name, location, or other criteria. Exact match searches are
        /// not supported.
        /// </summary>
        /// <param name="query">The search query to run against people search.</param>
        /// <returns>An instance of <see cref="TwitterSearchUsersResponse"/> representing the response.</returns>
        public TwitterSearchUsersResponse Search(string query) {
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
        /// <returns>An instance of <see cref="TwitterSearchUsersResponse"/> representing the response.</returns>
        public TwitterSearchUsersResponse Search(TwitterSearchUsersOptions options) {
            return TwitterSearchUsersResponse.ParseResponse(Raw.Search(options));
        }

        #endregion

    }

}