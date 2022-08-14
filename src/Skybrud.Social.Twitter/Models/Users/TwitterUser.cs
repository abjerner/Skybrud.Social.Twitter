using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;
using Skybrud.Social.Twitter.Models.Entities;
using Skybrud.Social.Twitter.Models.Statuses;

namespace Skybrud.Social.Twitter.Models.Users {

    /// <summary>
    /// Class representing a Twitter user as returned by the Twitter API.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.twitter.com/en/docs/tweets/data-dictionary/overview/user-object</cref>
    /// </see>
    public class TwitterUser : TwitterObject {

        #region Properties

        /// <summary>
        /// Gets the integer representation of the unique identifier for this user. This number is greater than 53
        /// bits and some programming languages may have difficulty/silent defects in interpreting it. Using a signed
        /// 64 bit integer for storing this identifier is safe. Use <see cref="IdStr"/> for fetching the identifier to
        /// stay on the safe side.
        /// </summary>
        public long Id { get; }

        /// <summary>
        /// Gets the string representation of the unique identifier for this Tweet. Implementations should use this
        /// rather than the large integer in id.
        /// </summary>
        /// <see>
        ///     <cref>http://groups.google.com/group/twitter-development-talk/browse_thread/thread/6a16efa375532182/</cref>
        /// </see>
        public string IdStr { get; }

        /// <summary>
        /// Gets the screen name, handle, or alias that this user identifies themselves with. Screen names are unique
        /// but subject to change. Use <see cref="IdStr"/> as a user identifier whenever possible. Typically a maximum
        /// of 15 characters long, but some historical accounts may exist with longer names.
        /// </summary>
        public string ScreenName { get; }

        /// <summary>
        /// Gets the name of the user, as they've defined it. Not necessarily a person's name. Typically capped at 20
        /// characters, but subject to change.
        /// </summary>
        public string Name { get; }

        /// <summary>
        /// <em>Nullable</em>. Gets the user-defined location for this account's profile. Not necessarily a location
        /// nor parseable. This field will occasionally be fuzzily interpreted by the Search service.
        /// </summary>
        public string Location { get; }

        /// <summary>
        /// Gets whether the <see cref="Location"/> property has a value.
        /// </summary>
        public bool HasLocation => !string.IsNullOrWhiteSpace(Location);

        /// <summary>
        /// <em>Nullable</em>. Gets the URL provided by the user in association with their profile.
        /// </summary>
        public string Url { get; }

        /// <summary>
        /// Gets whether the <see cref="Url"/> property has a value.
        /// </summary>
        public bool HasUrl => !string.IsNullOrWhiteSpace(Url);

        /// <summary>
        /// Entities which have been parsed out of the url or description fields defined by the user.
        /// </summary>
        public TwitterUserEntities Entities { get; }

        /// <summary>
        /// <em>Nullable</em>. Gets the user-defined UTF-8 string describing their account.
        /// </summary>
        public string Description { get; }

        /// <summary>
        /// Gets whether the <see cref="Description"/> property has a value.
        /// </summary>
        public bool HasDescription => !string.IsNullOrWhiteSpace(Description);

        // TODO: Add support for the "derived" property

        /// <summary>
        /// When true, indicates that this user has chosen to protect their Tweets.
        /// See <a href="https://help.twitter.com/en/safety-and-security/public-and-protected-tweets">About public and protected Tweets</a>.
        /// </summary>
        public bool IsProtected { get; }

        /// <summary>
        /// Gets whether the user has a verified account.
        /// See <a href="https://help.twitter.com/en/managing-your-account/about-twitter-verified-accounts">About verified accounts</a>
        /// </summary>
        public bool IsVerified { get; }

        /// <summary>
        /// Gets the number of followers this account currently has. Under certain conditions of duress, this field
        /// will temporarily indicate <c>0</c>.
        /// </summary>
        public int FollowersCount { get; }

        /// <summary>
        /// Gets the number of users this account is following (AKA their "followings"). Under certain
        /// conditions of duress, this field will temporarily indicate <c>0</c>.
        /// </summary>
        public int FriendsCount { get; }

        /// <summary>
        /// Gets the number of public lists that this user is a member of.
        /// </summary>
        public int ListedCount { get; }

        /// <summary>
        /// Gets the number of tweets this user has favorited in the account's lifetime. British spelling used in the
        /// field name for historical reasons.
        /// </summary>
        public int FavouritesCount { get; }

        /// <summary>
        /// Alias of <see cref="FavouritesCount"/>.
        /// </summary>
        public int FavoritesCount => FavouritesCount;

        /// <summary>
        /// Gets the number of tweets (including retweets) issued by the user.
        /// </summary>
        public int StatusesCount { get; }

        /// <summary>
        /// Gets the UTC datetime that the user account was created on Twitter.
        /// </summary>
        public EssentialsTime CreatedAt { get; }

        /// <summary>
        /// Gets the offset from GMT/UTC in seconds.
        /// </summary>
        public int UtcOffset { get; }

        /// <summary>
        /// <em>Nullable</em>. A string describing the time zone this user declares themselves within.
        /// </summary>
        public string TimeZone { get; }

        /// <summary>
        /// Gets whether the user has enabled the possibility of geotagging their tweets. This field must be
        /// <c>true</c> for the current user to attach geographic data when using POST statuses/update.
        /// </summary>
        public bool IsGeoEnabled { get; }

        /// <summary>
        /// The <strong>BCP 47</strong> code for the user's self-declared user interface language. May or may not have
        /// anything to do with the content of their tweets.
        /// </summary>
        /// <see>
        ///     <cref>http://tools.ietf.org/html/bcp47</cref>
        /// </see>
        public string Language { get; }

        /// <summary>
        /// <em>Nullable</em>. If possible, the user's most recent tweet or retweet. In some circumstances,
        /// this data cannot be provided and this field will be omitted, null, or empty. Perspectival
        /// attributes within tweets embedded within users cannot always be relied upon.
        /// </summary>
        public TwitterStatusMessage Status { get; }

        /// <summary>
        /// Indicates that the user has an account with "contributor mode" enabled, allowing for
        /// Tweets issued by the user to be co-authored by another account. Rarely <c>true</c>.
        /// </summary>
        public bool ContributorsEnabled { get; }

        /// <summary>
        /// When <c>true</c>, indicates that the user is a participant in Twitter's translator community.
        /// </summary>
        public bool IsTranslator { get; }

        /// <summary>
        /// <em>Perspectival</em>. When <c>true</c>, indicates that the authenticating user has issued a
        /// follow request to this protected user account.
        /// </summary>
        public bool IsFollowRequestSent { get; }

        /// <summary>
        /// Gets the hexadecimal color chosen by the user for their background.
        /// </summary>
        public string ProfileBackgroundColor { get; }

        /// <summary>
        /// Gets a HTTP-based URL pointing to the background image the user has uploaded for their profile.
        /// </summary>
        public string ProfileBackgroundImageUrl { get; }

        /// <summary>
        /// Gets a HTTPS-based URL pointing to the background image the user has uploaded for their profile.
        /// </summary>
        public string ProfileBackgroundImageUrlHttps { get; }

        /// <summary>
        /// When <c>true</c>, indicates that the user's <see cref="ProfileBackgroundImageUrl"/> should be tiled when
        /// displayed.
        /// </summary>
        public bool ProfileBackgroundTile { get; }

        /// <summary>
        /// Gets the HTTPS-based URL pointing to the standard web representation of the user's uploaded profile banner.
        /// By adding a final path element of the URL, it is possible to obtain different image sizes optimized for
        /// specific displays. For size variants, please see
        /// <a href="https://developer.twitter.com/en/docs/accounts-and-users/user-profile-images-and-banners">User Profile Images and Banners</a>.
        /// </summary>
        public string ProfileBannerUrl { get; }

        /// <summary>
        /// Gets a HTTP-based URL pointing to the user's avatar image. See
        /// <a href="https://developer.twitter.com/en/docs/accounts-and-users/user-profile-images-and-banners">User Profile Images and Banners</a>.
        /// </summary>
        public string ProfileImageUrl { get; }

        /// <summary>
        /// Gets a HTTPS-based URL pointing to the user's avatar image.
        /// </summary>
        public string ProfileImageUrlHttps { get; }

        /// <summary>
        /// Gets the hexadecimal color the user has chosen to display links with in their Twitter UI.
        /// </summary>
        public string ProfileLinkColor { get; }

        /// <summary>
        /// Gets the hexadecimal color the user has chosen to display sidebar borders with in their Twitter UI.
        /// </summary>
        public string ProfileSidebarBorderColor { get; }

        /// <summary>
        /// Gets the hexadecimal color the user has chosen to display sidebar backgrounds with in their Twitter UI.
        /// </summary>
        public string ProfileSidebarFillColor { get;}

        /// <summary>
        /// Gets the hexadecimal color the user has chosen to display text with in their Twitter UI.
        /// </summary>
        public string ProfileTextColor { get; }

        /// <summary>
        /// Gets whether the user wants their uploaded background image to be used.
        /// </summary>
        public bool ProfileUseBackgroundImage { get; }


        /// <summary>
        /// When <c>true</c>, indicates that the user has not altered the theme or background of their user profile.
        /// </summary>
        public bool HasDefaultProfile { get; }


        /// <summary>
        /// When <c>true</c>, indicates that the user has not uploaded their own avatar and a default egg avatar is
        /// used instead.
        /// </summary>
        public bool HasDefaultProfileImage { get; }

        // TODO: Add support for the "withheld_in_countries" property

        // TODO: Add support for the "withheld_scope" property

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of <see cref="TwitterUser"/> parsed from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The <see cref="JObject"/> to be parsed.</param>
        protected TwitterUser(JObject obj) : base(obj) {
            Id = obj.GetInt64("id");
            IdStr = obj.GetString("id_str");
            Name = obj.GetString("name");
            ScreenName = obj.GetString("screen_name");
            Location = obj.GetString("location");
            Url = obj.GetString("url");
            Entities = obj.GetObject("entities", TwitterUserEntities.Parse);
            Description = obj.GetString("description");
            // TODO: Add support for the "derived" property
            IsProtected = obj.GetBoolean("protected");
            IsVerified = obj.GetBoolean("verified");
            FollowersCount = obj.GetInt32("followers_count");
            FriendsCount = obj.GetInt32("friends_count");
            ListedCount = obj.GetInt32("listed_count");
            FavouritesCount = obj.GetInt32("favourites_count");
            StatusesCount = obj.GetInt32("statuses_count");
            CreatedAt = obj.GetString("created_at", TwitterUtils.ParseDateTime);
            UtcOffset = obj.GetInt32("utc_offset");
            TimeZone = obj.GetString("time_zone");
            IsGeoEnabled = obj.GetBoolean("geo_enabled");
            Language = obj.GetString("lang");
            Status = obj.GetObject("status", TwitterStatusMessage.Parse);
            ContributorsEnabled = obj.GetBoolean("contributors_enabled");
            IsTranslator = obj.GetBoolean("is_translator");
            IsFollowRequestSent = obj.GetBoolean("follow_request_sent");
            ProfileBackgroundColor = obj.GetString("profile_background_color");
            ProfileBackgroundImageUrl = obj.GetString("profile_background_image_url");
            ProfileBackgroundImageUrlHttps = obj.GetString("profile_background_image_url_https");
            ProfileBackgroundTile = obj.GetBoolean("profile_background_tile");
            ProfileBannerUrl = obj.GetString("profile_banner_url");
            ProfileImageUrl = obj.GetString("profile_image_url");
            ProfileImageUrlHttps = obj.GetString("profile_image_url_https");
            ProfileLinkColor = obj.GetString("profile_link_color");
            ProfileSidebarBorderColor = obj.GetString("profile_sidebar_border_color");
            ProfileSidebarFillColor = obj.GetString("profile_sidebar_fill_color");
            ProfileTextColor = obj.GetString("profile_text_color");
            ProfileUseBackgroundImage = obj.GetBoolean("profile_use_background_image");
            HasDefaultProfile = obj.GetBoolean("default_profile");
            HasDefaultProfileImage = obj.GetBoolean("default_profile_image");
            // TODO: Add support for the "withheld_in_countries" property
            // TODO: Add support for the "withheld_scope" property
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="TwitterUser"/> from the specified <see cref="JObject"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="TwitterUser"/>.</returns>
        public static TwitterUser Parse(JObject obj) {
            return obj == null ? null : new TwitterUser(obj);
        }

        #endregion

    }

}