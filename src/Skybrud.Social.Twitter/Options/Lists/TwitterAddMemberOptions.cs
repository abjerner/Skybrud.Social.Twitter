using Skybrud.Essentials.Common;
using Skybrud.Essentials.Http;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;

namespace Skybrud.Social.Twitter.Options.Lists {

    /// <summary>
    /// Class with options for a request to the Twitter API for adding a member to a list.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.twitter.com/en/docs/accounts-and-users/create-manage-lists/api-reference/post-lists-members-create</cref>
    /// </see>
    public class TwitterAddMemberOptions : IHttpRequestOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the numerical ID of the list.
        /// </summary>
        public long ListId { get; set; }

        // TODO: Add support for the "slug" property

        /// <summary>
        /// Gets or sets the numerical ID of the user.
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Gets or sets the screen name of the user.
        /// </summary>
        public string ScreenName { get; set; }

        // TODO: Add support for the "owner_screen_name" property

        // TODO: Add support for the "owner_id" property

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public TwitterAddMemberOptions() { }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="listId"/> and <paramref name="userId"/>.
        /// </summary>
        /// <param name="listId">The numeric ID of the list.</param>
        /// <param name="userId">The numeric ID of the user.</param>
        public TwitterAddMemberOptions(long listId, long userId) {
            ListId = listId;
            UserId = userId;
        }

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="listId"/> and <paramref name="screenName"/>.
        /// </summary>
        /// <param name="listId">The numeric ID of the list.</param>
        /// <param name="screenName">The screen name of the user.</param>
        public TwitterAddMemberOptions(long listId, string screenName) {
            ListId = listId;
            ScreenName = screenName;
        }

        #endregion

        #region Member methods

        /// <inheritdoc />
        public IHttpRequest GetRequest() {

            // Validate required properties
            if (ListId == 0) throw new PropertyNotSetException(nameof(ListId));
            if (UserId == 0 && string.IsNullOrWhiteSpace(ScreenName)) throw new PropertyNotSetException(nameof(UserId));

            // Initialize the POST body
            IHttpPostData body = new HttpPostData { { "list_id", ListId } };
            if (UserId > 0) body.Add("user_id", UserId);
            if (!string.IsNullOrWhiteSpace(ScreenName)) body.Add("screen_name", ScreenName);

            // Initialize a new GET request
            return HttpRequest.Post("/1.1/lists/members/create.json", null, body);

        }

        #endregion

    }

}