using System;
using Skybrud.Essentials.Http.Collections;
using Skybrud.Essentials.Http.Options;

namespace Skybrud.Social.Twitter.Options.Lists {

    /// <summary>
    /// Class with Options for a request to the Twitter API for getting the members of a given list.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.twitter.com/en/docs/accounts-and-users/create-manage-lists/api-reference/get-lists-members</cref>
    /// </see>
    public class TwitterGetMembersOptions : IHttpGetOptions {

        #region Properties

        /// <summary>
        /// Gets or sets the ID of the list.
        /// </summary>
        public long Id { get; set; }

        /// <summary>
        /// Gets or sets the slug of the list.
        /// </summary>
        public string Slug { get; set; }

        /// <summary>
        /// Gets or sets the ID of the owning user.
        /// </summary>
        public long UserId { get; set; }

        /// <summary>
        /// Gets or sets the screen name of the owning user.
        /// </summary>
        public string ScreenName { get; set; }

        /// <summary>
        /// Gets or sets the maximum amount of members to be returned.
        /// </summary>
        public int Count { get; set; }

        /// <summary>
        /// Gets or sets the cursor for the page to be returned.
        /// </summary>
        public long Cursor { get; set; }

        /// <summary>
        /// The <c>entities</c> node will be disincluded when set to <c>false</c>.
        /// </summary>
        public bool IncludeEntities { get; set; }

        /// <summary>
        /// When set to <c>true</c> statuses will not be included in the returned user objects.
        /// </summary>
        public bool SkipStatus { get; set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance with default options.
        /// </summary>
        public TwitterGetMembersOptions() { }

        /// <summary>
        /// Intializes a new instance based on the specified <paramref name="listId"/>.
        /// </summary>
        /// <param name="listId">The ID of the list.</param>
        public TwitterGetMembersOptions(long listId) : this() {
            Id = listId;
        }

        /// <summary>
        /// Intializes a new instance based on the specified <paramref name="userId"/> and <paramref name="slug"/>.
        /// </summary>
        /// <param name="userId">The screen name of the user owning the list.</param>
        /// <param name="slug">The slug of the list.</param>
        public TwitterGetMembersOptions(long userId, string slug) : this() {
            UserId = userId;
            Slug = slug;
        }

        /// <summary>
        /// Intializes a new instance based on the specified <paramref name="screenName"/> and <paramref name="slug"/>.
        /// </summary>
        /// <param name="screenName">The screen name of the user owning the list.</param>
        /// <param name="slug">The slug of the list.</param>
        public TwitterGetMembersOptions(string screenName, string slug) : this() {
            ScreenName = screenName;
            Slug = slug;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets an instance of <see cref="IHttpQueryString"/> representing the GET parameters.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpQueryString"/>.</returns>
        public IHttpQueryString GetQueryString() {
            IHttpQueryString qs = new HttpQueryString();
            if (Id > 0) qs.Set("list_id", UserId);
            if (!String.IsNullOrWhiteSpace(Slug)) qs.Set("slug", Slug);
            if (UserId > 0) qs.Set("owner_id", UserId);
            if (!String.IsNullOrWhiteSpace(ScreenName)) qs.Set("owner_screen_name", ScreenName);
            if (Count > 0) qs.Set("count", Count);
            if (Cursor > 0) qs.Set("cursor", Cursor);
            if (!IncludeEntities) qs.Set("include_entities", "0");
            if (SkipStatus) qs.Set("skip_status", "1");
            return qs;
        }

        #endregion

    }

}