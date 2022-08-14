using System;
using Skybrud.Essentials.Http;
using Skybrud.Social.Twitter.OAuth;
using Skybrud.Social.Twitter.Options.Lists;

namespace Skybrud.Social.Twitter.Endpoints.Raw {

    /// <summary>
    /// Class representing the raw implementation of the <strong>Lists</strong> endpoint.
    /// </summary>
    public class TwitterListsRawEndpoint {

        #region Properties

        /// <summary>
        /// Gets a reference to the OAuth 1.0a client.
        /// </summary>
        public ITwitterOAuthClient Client { get; }

        #endregion

        #region Constructors

        internal TwitterListsRawEndpoint(ITwitterOAuthClient client) {
            Client = client;
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets information about the list with the specified <paramref name="listId"/>.
        /// </summary>
        /// <param name="listId">The ID of the list.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/accounts-and-users/create-manage-lists/api-reference/get-lists-show</cref>
        /// </see>
        public IHttpResponse GetList(long listId) {
            return GetList(new TwitterGetListOptions(listId));
        }

        /// <summary>
        /// Gets information about the list with the specified <paramref name="userId"/> and <paramref name="slug"/>.
        /// </summary>
        /// <param name="userId">The ID of the user owning the list.</param>
        /// <param name="slug">The slug of the list.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/accounts-and-users/create-manage-lists/api-reference/get-lists-show</cref>
        /// </see>
        public IHttpResponse GetList(long userId, string slug) {
            if (string.IsNullOrWhiteSpace(slug)) throw new ArgumentNullException(nameof(slug));
            return GetList(new TwitterGetListOptions(userId, slug));
        }

        /// <summary>
        /// Gets information about the list with the specified <paramref name="screenName"/> and <paramref name="slug"/>.
        /// </summary>
        /// <param name="screenName">The screen name of the user owning the list.</param>
        /// <param name="slug">The slug of the list.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://dev.twitter.com/rest/reference/get/lists/show</cref>
        /// </see>
        public IHttpResponse GetList(string screenName, string slug) {
            if (string.IsNullOrWhiteSpace(screenName)) throw new ArgumentNullException(nameof(screenName));
            if (string.IsNullOrWhiteSpace(slug)) throw new ArgumentNullException(nameof(slug));
            return GetList(new TwitterGetListOptions(screenName, slug));
        }

        /// <summary>
        /// Gets information about the list matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://dev.twitter.com/rest/reference/get/lists/show</cref>
        /// </see>
        public IHttpResponse GetList(TwitterGetListOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        /// <summary>
        /// Gets a collection of Twitter lists the authenticated user is subscribed to or owns.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/accounts-and-users/create-manage-lists/api-reference/get-lists-list</cref>
        /// </see>
        public IHttpResponse GetLists() {
            return GetLists(new TwitterGetListsOptions());
        }

        /// <summary>
        /// Gets a collection of Twitter lists the user with the specified <paramref name="userId"/> is subscribed to or owns.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/accounts-and-users/create-manage-lists/api-reference/get-lists-list</cref>
        /// </see>
        public IHttpResponse GetLists(long userId) {
            return GetLists(new TwitterGetListsOptions(userId));
        }

        /// <summary>
        /// Gets a collection of Twitter lists the user with the specified <paramref name="screenName"/> is subscribed to or owns.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/accounts-and-users/create-manage-lists/api-reference/get-lists-list</cref>
        /// </see>
        public IHttpResponse GetLists(string screenName) {
            if (string.IsNullOrWhiteSpace(screenName)) throw new ArgumentNullException(nameof(screenName));
            return GetLists(new TwitterGetListsOptions(screenName));
        }

        /// <summary>
        /// Gets a collection of Twitter lists the user matching the specified <paramref name="options"/> is subscribed to or owns.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/accounts-and-users/create-manage-lists/api-reference/get-lists-list</cref>
        /// </see>
        public IHttpResponse GetLists(TwitterGetListsOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        /// <summary>
        /// Gets the lists owned by the user with the specified <paramref name="userId"/>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/accounts-and-users/create-manage-lists/api-reference/get-lists-ownerships</cref>
        /// </see>
        public IHttpResponse GetOwnerships(long userId) {
            return GetOwnerships(new TwitterGetOwnershipsOptions(userId));
        }

        /// <summary>
        /// Gets the lists owned by the user with the specified <paramref name="screenName"/>.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/accounts-and-users/create-manage-lists/api-reference/get-lists-ownerships</cref>
        /// </see>
        public IHttpResponse GetOwnerships(string screenName) {
            if (string.IsNullOrWhiteSpace(screenName)) throw new ArgumentNullException(nameof(screenName));
            return GetOwnerships(new TwitterGetOwnershipsOptions(screenName));
        }

        /// <summary>
        /// Gets the lists owned by the user matching the specified <paramref name="options"/>.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/accounts-and-users/create-manage-lists/api-reference/get-lists-ownerships</cref>
        /// </see>
        public IHttpResponse GetOwnerships(TwitterGetOwnershipsOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        /// <summary>
        /// Gets the lists the authenticated user is a member of.
        /// </summary>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/accounts-and-users/create-manage-lists/api-reference/get-lists-memberships</cref>
        /// </see>
        public IHttpResponse GetMemberships() {
            return GetMemberships(new TwitterGetMembershipsOptions());
        }

        /// <summary>
        /// Gets the lists the user with the specified <paramref name="userId"/> is a member of.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/accounts-and-users/create-manage-lists/api-reference/get-lists-memberships</cref>
        /// </see>
        public IHttpResponse GetMemberships(long userId) {
            return GetMemberships(new TwitterGetMembershipsOptions(userId));
        }

        /// <summary>
        /// Gets the lists the user with the specified <paramref name="screenName"/> is a member of.
        /// </summary>
        /// <param name="screenName">The screen name of the user.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/accounts-and-users/create-manage-lists/api-reference/get-lists-memberships</cref>
        /// </see>
        public IHttpResponse GetMemberships(string screenName) {
            if (string.IsNullOrWhiteSpace(screenName)) throw new ArgumentNullException(nameof(screenName));
            return GetMemberships(new TwitterGetMembershipsOptions(screenName));
        }

        /// <summary>
        /// Gets the lists the user matching the specified <paramref name="options"/> is a member of.
        /// </summary>
        /// <param name="options">The options for the call to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/accounts-and-users/create-manage-lists/api-reference/get-lists-memberships</cref>
        /// </see>
        public IHttpResponse GetMemberships(TwitterGetMembershipsOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        /// <summary>
        /// Gets the members of the list with the specified <paramref name="listId"/>.
        /// </summary>
        /// <param name="listId">The ID of the list.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/accounts-and-users/create-manage-lists/api-reference/get-lists-members</cref>
        /// </see>
        public IHttpResponse GetMembers(long listId) {
            return GetMembers(new TwitterGetMembersOptions(listId));
        }

        /// <summary>
        /// Gets the members of the list matching the specified <paramref name="userId"/> and <paramref name="slug"/>.
        /// </summary>
        /// <param name="userId">The ID of the user.</param>
        /// <param name="slug">The slug of the list.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/accounts-and-users/create-manage-lists/api-reference/get-lists-members</cref>
        /// </see>
        public IHttpResponse GetMembers(long userId, string slug) {
            return GetMembers(new TwitterGetMembersOptions(userId, slug));
        }

        /// <summary>
        /// Gets the members of the list matching the specified <paramref name="screenName"/> and <paramref name="slug"/>.
        /// </summary>
        /// <param name="screenName">The screen name of the user owning the list.</param>
        /// <param name="slug">The slug of the list.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/accounts-and-users/create-manage-lists/api-reference/get-lists-members</cref>
        /// </see>
        public IHttpResponse GetMembers(string screenName, string slug) {
            if (string.IsNullOrWhiteSpace(screenName)) throw new ArgumentNullException(nameof(screenName));
            return GetMembers(new TwitterGetMembersOptions(screenName, slug));
        }

        /// <summary>
        /// Gets the members of the list matching the specified <paramref name="options"/>. Private list members will only be
        /// shown if the authenticated user owns the specified list.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/accounts-and-users/create-manage-lists/api-reference/get-lists-members</cref>
        /// </see>
        public IHttpResponse GetMembers(TwitterGetMembersOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        /// <summary>
        /// Creates a new list for the authenticated user. Note that you can create up to 1000 lists per account. The created list will be public.
        /// </summary>
        /// <param name="name">The name of the list.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/accounts-and-users/create-manage-lists/api-reference/post-lists-create</cref>
        /// </see>
        public IHttpResponse CreateList(string name) {
            if (string.IsNullOrWhiteSpace(name)) throw new ArgumentNullException(nameof(name));
            return CreateList(new TwitterCreateListOptions(name));
        }

        /// <summary>
        /// Creates a new list for the authenticated user. Note that you can create up to 1000 lists per account.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/accounts-and-users/create-manage-lists/api-reference/post-lists-create</cref>
        /// </see>
        public IHttpResponse CreateList(TwitterCreateListOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        /// <summary>
        /// Deletes the specified list. The authenticated user must own the list to be able to destroy it.
        /// </summary>
        /// <param name="listId"></param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/accounts-and-users/create-manage-lists/api-reference/post-lists-destroy</cref>
        /// </see>
        public IHttpResponse DeleteList(long listId) {
            return DeleteList(new TwitterDeleteListOptions(listId));
        }

        /// <summary>
        /// Deletes the specified list. The authenticated user must own the list to be able to destroy it.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/accounts-and-users/create-manage-lists/api-reference/post-lists-destroy</cref>
        /// </see>
        public IHttpResponse DeleteList(TwitterDeleteListOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        /// <summary>
        /// Adds a member to a list. The authenticated user must own the list to be able to add members to it. Note that lists cannot have more than 5,000 members.
        /// </summary>
        /// <param name="listId">The numeric ID of the list.</param>
        /// <param name="userId">The numeric ID of the user.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/accounts-and-users/create-manage-lists/api-reference/post-lists-members-create</cref>
        /// </see>
        public IHttpResponse AddMember(long listId, long userId) {
            return AddMember(new TwitterAddMemberOptions(listId, userId));
        }

        /// <summary>
        /// Adds a member to a list. The authenticated user must own the list to be able to add members to it. Note that lists cannot have more than 5,000 members.
        /// </summary>
        /// <param name="listId">The numeric ID of the list.</param>
        /// <param name="screenName">The screen name of the user.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/accounts-and-users/create-manage-lists/api-reference/post-lists-members-create</cref>
        /// </see>
        public IHttpResponse AddMember(long listId, string screenName) {
            if (string.IsNullOrWhiteSpace(screenName)) throw new ArgumentNullException(nameof(screenName));
            return AddMember(new TwitterAddMemberOptions(listId, screenName));
        }

        /// <summary>
        /// Adds a member to a list. The authenticated user must own the list to be able to add members to it. Note that lists cannot have more than 5,000 members.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/accounts-and-users/create-manage-lists/api-reference/post-lists-members-create</cref>
        /// </see>
        public IHttpResponse AddMember(TwitterAddMemberOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        /// <summary>
        /// Removes the specified member from the list. The authenticated user must be the list’s owner to remove members from the list.
        /// </summary>
        /// <param name="listId">The numeric ID of the list.</param>
        /// <param name="userId">The numeric ID of the user.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/accounts-and-users/create-manage-lists/api-reference/post-lists-members-destroy</cref>
        /// </see>
        public IHttpResponse RemoveMember(long listId, long userId) {
            return RemoveMember(new TwitterRemoveMemberOptions(listId, userId));
        }

        /// <summary>
        /// Removes the specified member from the list. The authenticated user must be the list’s owner to remove members from the list.
        /// </summary>
        /// <param name="listId">The numeric ID of the list.</param>
        /// <param name="screenName">The screen name of the user.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/accounts-and-users/create-manage-lists/api-reference/post-lists-members-destroy</cref>
        /// </see>
        public IHttpResponse RemoveMember(long listId, string screenName) {
            if (string.IsNullOrWhiteSpace(screenName)) throw new ArgumentNullException(nameof(screenName));
            return RemoveMember(new TwitterRemoveMemberOptions(listId, screenName));
        }

        /// <summary>
        /// Removes the specified member from the list. The authenticated user must be the list’s owner to remove members from the list.
        /// </summary>
        /// <param name="options">The options for the request to the API.</param>
        /// <returns>An instance of <see cref="IHttpResponse"/> representing the raw response.</returns>
        /// <see>
        ///     <cref>https://developer.twitter.com/en/docs/accounts-and-users/create-manage-lists/api-reference/post-lists-members-destroy</cref>
        /// </see>
        public IHttpResponse RemoveMember(TwitterRemoveMemberOptions options) {
            if (options == null) throw new ArgumentNullException(nameof(options));
            return Client.GetResponse(options);
        }

        #endregion

    }

}