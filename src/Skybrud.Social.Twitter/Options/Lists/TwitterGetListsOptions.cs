using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;

namespace Skybrud.Social.Twitter.Options.Lists {

    /// <summary>
    /// Options for a request to the Twitter API for getting a list of Twitter lists.
    /// </summary>
    public class TwitterGetListsOptions : IHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the ID of the owning user.
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Gets or sets the screen name of the owning user.
        /// </summary>
        public string ScreenName { get; set; }

        /// <summary>
        /// Gets or sets whether the list of lists should be returned in reverse order.
        /// </summary>
        public bool Reverse { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public TwitterGetListsOptions() { }

        /// <summary>
        /// Intializes a new instance based on the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        public TwitterGetListsOptions(long userId) : this() {
            UserId = userId;
        }

        /// <summary>
        /// Intializes a new instance based on the specified <paramref name="screenName"/>.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        public TwitterGetListsOptions(string screenName) : this() {
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
            if (Reverse) query.Set("reverse", "1");

            // Initialize a new GET request
            return HttpRequest.Get("/1.1/lists/list.json", query);

        }

        #endregion

    }

}