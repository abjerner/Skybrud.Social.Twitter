using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.OAuth;
using Skybrud.Essentials.Http.OAuth.Responses;
using Skybrud.Essentials.Http.OAuth.Models;
using Skybrud.Social.Twitter.Endpoints.Raw;
using Skybrud.Social.Twitter.Responses;

namespace Skybrud.Social.Twitter.OAuth {

    /// <summary>
    /// Class for handling the communication with the Twitter API. The class has methods for handling OAuth logins
    /// using a three-legged approach as well as logic for calling the methods decribed in the Twitter API (not all
    /// has been implemented yet).
    /// </summary>
    public class TwitterOAuthClient : OAuthClient {

        #region Private fields

        private TwitterAccountRawEndpoint _account;
        private TwitterFavoritesRawEndpoint _favorites;
        private TwitterFollowersRawEndpoint _followers;
        private TwitterFriendsRawEndpoint _friends;
        private TwitterGeocodeRawEndpoint _geo;
        private TwitterListsRawEndpoint _lists;
        private TwitterSearchRawEndpoint _search;
        private TwitterStatusesRawEndpoint _statuses;
        private TwitterUsersRawEndpoint _users;

        #endregion

        #region Properties

        /// <summary>
        /// Gets a reference to the account endpoint.
        /// </summary>
        public TwitterAccountRawEndpoint Account => _account ?? (_account = new TwitterAccountRawEndpoint(this));

        /// <summary>
        /// Gets a reference to the favorites endpoint.
        /// </summary>
        public TwitterFavoritesRawEndpoint Favotires => _favorites ?? (_favorites = new TwitterFavoritesRawEndpoint(this));

        /// <summary>
        /// Gets a reference to the followers endpoint.
        /// </summary>
        public TwitterFollowersRawEndpoint Followers => _followers ?? (_followers = new TwitterFollowersRawEndpoint(this));

        /// <summary>
        /// Gets a reference to the friends endpoint.
        /// </summary>
        public TwitterFriendsRawEndpoint Friends => _friends ?? (_friends = new TwitterFriendsRawEndpoint(this));

        /// <summary>
        /// Gets a reference to the geo endpoint.
        /// </summary>
        public TwitterGeocodeRawEndpoint Geocode => _geo ?? (_geo = new TwitterGeocodeRawEndpoint(this));

        /// <summary>
        /// Gets a reference to the lists endpoint.
        /// </summary>
        public TwitterListsRawEndpoint Lists => _lists ?? (_lists = new TwitterListsRawEndpoint(this));

        /// <summary>
        /// Gets a reference to the statuses endpoint.
        /// </summary>
        public TwitterSearchRawEndpoint Search => _search ?? (_search = new TwitterSearchRawEndpoint(this));

        /// <summary>
        /// Gets a reference to the statuses endpoint.
        /// </summary>
        public TwitterStatusesRawEndpoint Statuses => _statuses ?? (_statuses = new TwitterStatusesRawEndpoint(this));

        /// <summary>
        /// Gets a reference to the users endpoint.
        /// </summary>
        public TwitterUsersRawEndpoint Users => _users ?? (_users = new TwitterUsersRawEndpoint(this));

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of the <code>TwitterOAuthClient</code> class.
        /// </summary>
        public TwitterOAuthClient() : this(null, null, null, null, null) { }

        /// <summary>
        /// Initializes a new instance of the <code>TwitterOAuthClient</code> class.
        /// </summary>
        /// <param name="consumerKey">The comsumer key of your application.</param>
        /// <param name="consumerSecret">The consumer secret of your application.</param>
        public TwitterOAuthClient(string consumerKey, string consumerSecret) : this(consumerKey, consumerSecret, null, null, null) { }

        /// <summary>
        /// Initializes a new instance of the <code>TwitterOAuthClient</code> class.
        /// </summary>
        /// <param name="consumerKey">The comsumer key of your application.</param>
        /// <param name="consumerSecret">The consumer secret of your application.</param>
        /// <param name="token">The access token of the user.</param>
        /// <param name="tokenSecret">The access token secret of the user.</param>
        public TwitterOAuthClient(string consumerKey, string consumerSecret, string token, string tokenSecret) : this(consumerKey, consumerSecret, token, tokenSecret, null) { }

        /// <summary>
        /// Initializes a new instance of the <code>TwitterOAuthClient</code> class.
        /// </summary>
        /// <param name="consumerKey">The comsumer key of your application.</param>
        /// <param name="consumerSecret">The consumer secret of your application.</param>
        /// <param name="token">The access token of the user.</param>
        /// <param name="tokenSecret">The access token secret of the user.</param>
        /// <param name="callback">The callback URI used for authentication.</param>
        public TwitterOAuthClient(string consumerKey, string consumerSecret, string token, string tokenSecret, string callback) {

            // Common properties
            ConsumerKey = consumerKey;
            ConsumerSecret = consumerSecret;
            Token = token;
            TokenSecret = tokenSecret;
            Callback = callback;

            // Specific to Twitter
            RequestTokenUrl = "https://api.twitter.com/oauth/request_token";
            AuthorizeUrl = "https://api.twitter.com/oauth/authorize";
            AccessTokenUrl = "https://api.twitter.com/oauth/access_token";

        }

        #endregion

        /// <summary>
        /// Gets a new request token from the Twitter API. After acquiring a request token, the user should be
        /// redirected to the Twitter authentication page for approving your application. If successful, the user will
        /// be redirected back to the specified callback URL where you then can exchange the request token for an
        /// access token.
        /// </summary>
        /// <returns>An instance of <see cref="OAuthRequestTokenResponse"/> representing the response.</returns>
        public override OAuthRequestTokenResponse GetRequestToken() {

            // Make the call to the API/provider
            IHttpResponse response = GetRequestTokenResponse();

            // Validate the response
            TwitterResponse.ValidateResponse(response);

            // Parse the response body
            OAuthRequestToken body = TwitterOAuthRequestToken.Parse(this, response.Body);

            // Parse the response
            return OAuthRequestTokenResponse.ParseResponse(response, body);

        }

        /// <summary>
        /// Following the 3-legged authorization, you can exchange a request token for an access token
        /// using this method. This is the third and final step of the authorization process.
        /// </summary>
        /// <param name="verifier">The verification key received after the user has accepted the app.</param>
        /// <returns>An instance of <see cref="OAuthAccessTokenResponse"/> representing the response.</returns>
        public override OAuthAccessTokenResponse GetAccessToken(string verifier) {

            // Make the call to the API/provider
            IHttpResponse response = GetAccessTokenResponse(verifier);

            // Validate the response
            TwitterResponse.ValidateResponse(response);

            // Parse the response body
            OAuthAccessToken body = TwitterOAuthAccessToken.Parse(this, response.Body);

            // Parse the response
            return OAuthAccessTokenResponse.ParseResponse(response, body);

        }

        /// <inheritdoc />
        protected override void PrepareHttpRequest(IHttpRequest request) {

            // Make sure to call the base method to handle all the OAuth stuff
            base.PrepareHttpRequest(request);

            // Prepend the scheme and host name if not already present
            if (request.Url.StartsWith("/")) request.Url = $"https://api.twitter.com{request.Url}";

        }

    }

}