using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.OAuth;
using Skybrud.Essentials.Http.OAuth.Models;

namespace Skybrud.Social.Twitter.OAuth {

    /// <summary>
    /// Class with information about a Twitter request token.
    /// </summary>
    public class TwitterOAuthRequestToken : OAuthRequestToken {

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="client"/> and <paramref name="query."/>
        /// </summary>
        /// <param name="client">The current OAuth client.</param>
        /// <param name="query">The query string representing the request token information.</param>
        protected TwitterOAuthRequestToken(OAuthClient client, IHttpQueryString query) : base(client, query) { }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses a query string received from the API.
        /// </summary>
        /// <param name="client">The parent OAuth client.</param>
        /// <param name="str">The query string.</param>
        public static new OAuthRequestToken Parse(OAuthClient client, string str) {

            // Convert the query string to a NameValueCollection
            IHttpQueryString query = HttpQueryString.Parse(str);

            // Initialize a new instance
            return new TwitterOAuthRequestToken(client, query);

        }

        /// <summary>
        /// Parses a query string received from the API.
        /// </summary>
        /// <param name="client">The parent OAuth client.</param>
        /// <param name="query">The query string.</param>
        public static OAuthRequestToken Parse(OAuthClient client, IHttpQueryString query) {
            return query == null ? null : new TwitterOAuthRequestToken(client, query);
        }

        #endregion

    }

}