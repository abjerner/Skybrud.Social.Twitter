using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;

namespace Skybrud.Social.Twitter.Options.Users {

    /// <summary>
    /// Class with options for getting information about a Twitter user.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.twitter.com/en/docs/accounts-and-users/follow-search-get-users/api-reference/get-users-show</cref>
    /// </see>
    public class TwitterGetUserOptions : IHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the ID of the user.
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Gets or sets the screen name of the user.
        /// </summary>
        public string ScreenName { get; set; }

        /// <summary>
        /// Gets or sets whether entities should be included in the API response.
        /// </summary>
        public bool IncludeEntities { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public TwitterGetUserOptions() { }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        public TwitterGetUserOptions(long userId) {
            UserId = userId;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="includeEntities">Whether entities should be included in the API response.</param>
        public TwitterGetUserOptions(long userId, bool includeEntities) {
            UserId = userId;
            IncludeEntities = includeEntities;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="screenName"/>.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        public TwitterGetUserOptions(string screenName) {
            ScreenName = screenName;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="screenName"/>.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        /// <param name="includeEntities">Whether entities should be included in the API response.</param>
        public TwitterGetUserOptions(string screenName, bool includeEntities) {
            ScreenName = screenName;
            IncludeEntities = includeEntities;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public IHttpRequest GetRequest() {

            // Must have either a user ID or a screen name
            if (UserId == 0 && string.IsNullOrWhiteSpace(ScreenName)) throw new PropertyNotSetException(nameof(UserId));

            // Initialize the query string
            IHttpQueryString query = new HttpQueryString();
            if (UserId != 0) query.Add("user_id", UserId);
            if (!string.IsNullOrWhiteSpace(ScreenName)) query.Add("screen_name", ScreenName);
            if (IncludeEntities) query.Add("include_entities", "true");

            // Initialize a new GET request
            return HttpRequest.Get("/1.1/users/show.json", query);

        }

        #endregion

    }

}