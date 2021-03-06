﻿using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Social.Twitter.Models.Users;

namespace Skybrud.Social.Twitter.Models.Lists {

    /// <summary>
    /// Class representing a Twitter list.
    /// </summary>
    public class TwitterList : TwitterObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the list.
        /// </summary>
        public long Id { get; }

        /// <summary>
        /// Gets the slug of the list.
        /// </summary>
        public string Slug { get; }

        /// <summary>
        /// Gets the slug of the name.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// Gets the timestamp for when the list was created.
        /// </summary>
        public DateTime CreatedAt { get; }

        /// <summary>
        /// Gets the URI of the list.
        /// </summary>
        public string Uri { get; }

        /// <summary>
        /// Gets the amount of subscribers to the list.
        /// </summary>
        public int SubscriberCount { get; }

        /// <summary>
        /// Gets the amount of members of the list.
        /// </summary>
        public int MemberCount { get; }

        /// <summary>
        /// Gets the mode (visibility) of the list.
        /// </summary>
        public TwitterListMode Mode { get; }

        /// <summary>
        /// Gets the full name of the list.
        /// </summary>
        public string FullName { get; }

        /// <summary>
        /// Gets the description of the list.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Gets whether the list has a description.
        /// </summary>
        public bool HasDescription => !String.IsNullOrWhiteSpace(Description);

        /// <summary>
        /// Gets a referecne to the user owning the list.
        /// </summary>
        public TwitterUser User { get; }

        /// <summary>
        /// Gets whether the authenticated user is following the list.
        /// </summary>
        public bool IsFollowing { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of <see cref="TwitterList"/> parsed from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The <see cref="JObject"/> to be parsed.</param>
        protected TwitterList(JObject obj) : base(obj) {
            Id = obj.GetInt64("id");
            Slug = obj.GetString("slug");
            Name = obj.GetString("name");
            CreatedAt = obj.GetString("created_at", TwitterUtils.ParseDateTime);
            Uri = obj.GetString("uri");
            SubscriberCount = obj.GetInt32("subscriber_count");
            MemberCount = obj.GetInt32("member_count");
            Mode = obj.GetEnum<TwitterListMode>("mode");
            FullName = obj.GetString("full_name");
            Description = obj.GetString("description");
            User = obj.GetObject("user", TwitterUser.Parse);
            IsFollowing = obj.GetBoolean("following");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="TwitterList"/> from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="TwitterList"/>.</returns>
        public static TwitterList Parse(JObject obj) {
            return obj == null ? null : new TwitterList(obj);
        }

        #endregion

    }

}