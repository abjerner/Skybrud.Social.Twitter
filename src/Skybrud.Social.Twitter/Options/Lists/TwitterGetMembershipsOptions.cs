using System;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;

namespace Skybrud.Social.Twitter.Options.Lists {

    /// <summary>
    /// Class with options for a request to the Twitter API for getting the lists a given user is the member of.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.twitter.com/en/docs/accounts-and-users/create-manage-lists/api-reference/get-lists-memberships</cref>
    /// </see>
    public class TwitterGetMembershipsOptions : IHttpGetOptions {

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
        /// Gets or sets the maximum amount of lists to be returned.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets the cursor for the page to be returned.
        /// </summary>
        public long Cursor { get; set; }

        /// <summary>
        /// When set to <c>true</c>, will return just lists the authenticating user owns, and the user
        /// represented by <see cref="UserId"/> or <see cref="ScreenName"/> is a member of.
        /// </summary>
        public bool FilterToOwnedLists { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public TwitterGetMembershipsOptions() { }

        /// <summary>
        /// Intializes a new instance based on the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        public TwitterGetMembershipsOptions(long userId) {
            UserId = userId;
        }

        /// <summary>
        /// Intializes a new instance based on the specified <paramref name="screenName"/>.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        public TwitterGetMembershipsOptions(string screenName) {
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
            if (Count > 0) qs.Set("count", Count);
            if (Cursor > 0) qs.Set("cursor", Cursor);
            if (FilterToOwnedLists) qs.Set("filter_to_owned_lists", "1");
            return qs;
        }

        #endregion

    }

}