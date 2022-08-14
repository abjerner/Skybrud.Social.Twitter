using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.OAuth;
using Skybrud.Essentials.Http.OAuth.Models;

namespace Skybrud.Social.Twitter.OAuth {

    /// <summary>
    /// Class with information about an OAuth 1.0a access token.
    /// </summary>
    public class TwitterOAuthAccessToken : OAuthAccessToken {

        #region Properties

        /// <summary>
        /// Gets the ID of the authenticating user.
        /// </summary>
        public long UserId { get; }

        /// <summary>
        /// Gets the screen name of the authenticating user.
        /// </summary>
        public string ScreenName { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="client"/> and <paramref name="query"/>.
        /// </summary>
        /// <param name="client">The current OAuth client.</param>
        /// <param name="query">The query string representing the access token information.</param>
        protected TwitterOAuthAccessToken(OAuthClient client, IHttpQueryString query) : base(client, query) {
            UserId = long.Parse(query["user_id"]);
            ScreenName = query["screen_name"];
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses a query string received from the API.
        /// </summary>
        /// <param name="client">The parent OAuth client.</param>
        /// <param name="str">The query string.</param>
        public static new TwitterOAuthAccessToken Parse(OAuthClient client, string str) {

            // Convert the query string to an IHttpQueryString
            IHttpQueryString query = HttpQueryString.Parse(str);

            // Initialize a new instance
            return new TwitterOAuthAccessToken(client, query);

        }

        /// <summary>
        /// Parses a query string received from the API.
        /// </summary>
        /// <param name="client">The parent OAuth client.</param>
        /// <param name="query">The query string.</param>
        public static TwitterOAuthAccessToken Parse(OAuthClient client, IHttpQueryString query) {
            return query == null ? null : new TwitterOAuthAccessToken(client, query);
        }

        #endregion

    }

}