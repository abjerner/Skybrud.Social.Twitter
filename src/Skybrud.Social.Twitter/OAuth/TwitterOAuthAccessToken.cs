using System;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.OAuth;
using Skybrud.Essentials.Http.OAuth.Models;

namespace Skybrud.Social.Twitter.OAuth {

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

        protected TwitterOAuthAccessToken(OAuthClient client, IHttpQueryString query) : base(client, query) {
            UserId = Int64.Parse(query["user_id"]);
            ScreenName = query["screen_name"];
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses a query string received from the API.
        /// </summary>
        /// <param name="client">The parent OAuth client.</param>
        /// <param name="str">The query string.</param>
        public new static TwitterOAuthAccessToken Parse(OAuthClient client, string str) {

            // Convert the query string to an IHttpQueryString
            IHttpQueryString query = HttpQueryString.ParseQueryString(str);

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