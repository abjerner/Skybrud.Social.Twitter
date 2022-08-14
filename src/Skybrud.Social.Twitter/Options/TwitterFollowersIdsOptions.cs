using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;

#pragma warning disable CS1591

namespace Skybrud.Social.Twitter.Options {

    /// <summary>
    /// Class with options for getting a list of follower IDs.
    /// </summary>
    public class TwitterFollowersIdsOptions : IHttpRequestOptions {

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
        /// Causes the results to be broken into pages. If no cursor is
        /// provided, a value of <c>-1</c> will be assumed, which is the
        /// first "page".
        ///
        /// The response from the API will include a <c>previous_cursor</c>
        /// and <c>next_cursor</c> to allow paging back and forth.
        /// </summary>
        public long? Cursor { get; set; }

        /// <summary>
        /// The number of users to return per page, up to a maximum of 200. Defaults to 20.
        /// </summary>
        public int? Count { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public TwitterFollowersIdsOptions() { }

        /// <summary>
        /// Intializes a new instance based on the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        public TwitterFollowersIdsOptions(long userId) {
            UserId = userId;
        }

        /// <summary>
        /// Intializes a new instance based on the specified <paramref name="screenName"/>.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        public TwitterFollowersIdsOptions(string screenName) {
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

            // Initialize a new GET request
            return HttpRequest.Get("/1.1/followers/ids.json", query);

        }

        #endregion

    }

}