using System;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;

namespace Skybrud.Social.Twitter.Options {

    /// <summary>
    /// Class with options for getting a list of follower IDs.
    /// </summary>
    public class TwitterFollowersIdsOptions : IHttpGetOptions {

        #region Constants

        public const int DefaultCursor = -1;
        public const int DefaultCount = 5000;
        public const bool DefaultSkipStatus = false;
        public const bool DefaultIncludeUserEntities = true;

        #endregion

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
        public long Cursor { get; set; }

        /// <summary>
        /// The number of users to return per page, up to a maximum of 200.
        /// Defaults to 20.
        /// </summary>
        public int Count { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public TwitterFollowersIdsOptions() {
            Cursor = DefaultCursor;
            Count = DefaultCount;
        }

        /// <summary>
        /// Intializes a new instance based on the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        public TwitterFollowersIdsOptions(long userId) : this() {
            UserId = userId;
        }

        /// <summary>
        /// Intializes a new instance based on the specified <paramref name="screenName"/>.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        public TwitterFollowersIdsOptions(string screenName) : this() {
            ScreenName = screenName;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets an instance of <see cref="IHttpQueryString"/> representing the GET parameters.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpQueryString"/>.</returns>
        public IHttpQueryString GetQueryString() {
            IHttpQueryString qs = new HttpQueryString();
            if (UserId > 0) qs.Set("user_id", UserId);
            if (!String.IsNullOrWhiteSpace(ScreenName)) qs.Set("screen_name", ScreenName);
            if (Cursor != DefaultCursor) qs.Set("cursor", Cursor);
            if (Count != DefaultCount) qs.Set("count", Count);
            return qs;
        }

        #endregion

    }

}