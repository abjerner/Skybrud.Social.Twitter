using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;

namespace Skybrud.Social.Twitter.Options {

    /// <summary>
    /// Class with options for getting a list of friends.
    /// </summary>
    public class TwitterFriendsListOptions : IHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the ID of the user for whom to return results for.
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Gets or sets the screen name of the user for whom to return results for.
        /// </summary>
        public string ScreenName { get; set; }

        /// <summary>
        /// Causes the results to be broken into pages. If no cursor is provided, a value of <c>-1</c> will be
        /// assumed, which is the first "page".
        ///
        /// The response from the API will include a <c>previous_cursor</c> and <c>next_cursor</c> to allow
        /// paging back and forth.
        /// </summary>
        public long? Cursor { get; set; }

        /// <summary>
        /// The number of users to return per page, up to a maximum of 200. Defaults to 20.
        /// </summary>
        public int? Count { get; set; }

        /// <summary>
        /// When set to <c>true</c> statuses will not be included in the returned user objects.
        /// </summary>
        public bool? SkipStatus { get; set; }

        /// <summary>
        /// The user object entities node will be disincluded when set to <c>false</c>.
        /// </summary>
        public bool? IncludeUserEntities { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public TwitterFriendsListOptions() { }

        /// <summary>
        /// Intializes a new instance based on the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        public TwitterFriendsListOptions(long userId) : this() {
            UserId = userId;
        }

        /// <summary>
        /// Intializes a new instance based on the specified <paramref name="screenName"/>.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        public TwitterFriendsListOptions(string screenName) : this() {
            ScreenName = screenName;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public IHttpRequest GetRequest() {

            // Initialize the query string
            IHttpQueryString query = new HttpQueryString();
            if (UserId > 0) query.Set("user_id", UserId);
            if (!string.IsNullOrWhiteSpace(ScreenName)) query.Set("screen_name", ScreenName);
            if (Cursor != null) query.Set("cursor", Cursor.Value);
            if (Count != null) query.Set("count", Count.Value);
            if (SkipStatus != null) query.Set("skip_status", SkipStatus.Value ? "1" : "0");
            if (IncludeUserEntities != null) query.Set("include_user_entities", IncludeUserEntities.Value ? "1" : "0");

            // Initialize a new GET request
            return HttpRequest.Get("/1.1/friends/list.json", query);

        }

        #endregion

    }

}