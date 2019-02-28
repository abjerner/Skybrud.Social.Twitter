using System;
using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;

namespace Skybrud.Social.Twitter.Options.Lists {

    /// <summary>
    /// Options for a request to the Twitter API for removing a member from a list.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.twitter.com/en/docs/accounts-and-users/create-manage-lists/api-reference/post-lists-members-destroy</cref>
    /// </see>
    public class TwitterRemoveMemberOptions : IHttpPostOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the numerical ID of the list.
        /// </summary>
        public long ListId { get; set; }

        // TODO: Add support for the "slug" property

        /// <summary>
        /// Gets or sets the numerical ID of the user to be removed.
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Gets or sets the screen name of the user to be removed.
        /// </summary>
        public string ScreenName { get; set; }

        // TODO: Add support for the "owner_screen_name" property

        // TODO: Add support for the "owner_id" property

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public TwitterRemoveMemberOptions() { }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="listId"/> and <paramref name="userId"/>.
        /// </summary>
        /// <param name="listId">The numeric ID of the list.</param>
        /// <param name="userId">The numeric ID of the user.</param>
        public TwitterRemoveMemberOptions(long listId, long userId) {
            ListId = listId;
            UserId = userId;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="listId"/> and <paramref name="screenName"/>.
        /// </summary>
        /// <param name="listId">The numeric ID of the list.</param>
        /// <param name="screenName">The screen name of the user.</param>
        public TwitterRemoveMemberOptions(long listId, string screenName) {
            ListId = listId;
            ScreenName = screenName;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets an instance of <see cref="IHttpQueryString"/> representing the GET parameters.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpQueryString"/>.</returns>
        public IHttpQueryString GetQueryString() {
            return new HttpQueryString();
        }

        /// <summary>
        /// Gets an instance of <see cref="IHttpPostData"/> representing the POST parameters.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpPostData"/>.</returns>
        public IHttpPostData GetPostData() {

            if (ListId == 0) throw new PropertyNotSetException(nameof(ListId));
            if (UserId == 0 && String.IsNullOrWhiteSpace(ScreenName)) throw new PropertyNotSetException(nameof(UserId));

            IHttpPostData data = new HttpPostData {{"list_id", ListId}};

            if (UserId > 0) data.Add("user_id", UserId);
            if (!String.IsNullOrWhiteSpace(ScreenName)) data.Add("screen_name", ScreenName);

            return data;

        }

        #endregion

    }

}