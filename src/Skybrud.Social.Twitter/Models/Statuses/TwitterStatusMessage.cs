using System;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;
using Skybrud.Essentials.Time;
using Skybrud.Social.Twitter.Models.Entities;
using Skybrud.Social.Twitter.Models.Geocode;
using Skybrud.Social.Twitter.Models.Users;

namespace Skybrud.Social.Twitter.Models.Statuses {

    /// <summary>
    /// Class representing a status message (tweet) as received from the Twitter API.
    /// </summary>
    /// <see>
    ///     <cref>https://developer.twitter.com/en/docs/tweets/data-dictionary/overview/tweet-object</cref>
    /// </see>
    public class TwitterStatusMessage : TwitterObject {

        #region Properties

        /// <summary>
        /// Gets the ID of the tweet.
        /// </summary>
        public long Id { get; }

        /// <summary>
        /// Gets the string representation of the unique identifier for this tweet.
        /// </summary>
        public string IdStr { get; }

        /// <summary>
        /// Gets the date and time for when the tweet was created.
        /// </summary>
        public DateTime CreatedAt { get; }

        /// <summary>
        /// Gets the text or message of the tweet.
        /// </summary>
        public string Text { get; }

        /// <summary>
        /// Gets whether the <see cref="Text"/> property has a value.
        /// </summary>
        public bool HasText => !String.IsNullOrWhiteSpace(Text);

        /// <summary>
        /// Gets the full text or message of the tweet.
        /// </summary>
        public string FullText { get; }

        /// <summary>
        /// Gets whether the <see cref="FullText"/> property has a value.
        /// </summary>
        public bool HasFullText => !String.IsNullOrWhiteSpace(FullText);

        /// <summary>
        /// Gets the source/client used for making the tweet.
        /// </summary>
        public string Source { get; }

        /// <summary>
        /// Indicates whether the value of <see cref="Text"/> was truncated, for example, as a result of a retweet
        /// exceeding the original tweet text length limit of 140 characters.
        /// 
        /// Truncated text will end in ellipsis, like this <c>...</c>. Since Twitter now rejects long tweets vs
        /// truncating them, the large majority of Tweets will have this set to <c>false</c>.
        /// </summary>
        public bool IsTruncated { get; }










        public TwitterReplyTo InReplyTo { get; }










        /// <summary>
        /// Information about the user who made the tweet. May be <c>null</c>.
        /// </summary>
        public TwitterUser User { get; }

        /// <summary>
        /// Gets whether the <see cref="User"/> property has a value.
        /// </summary>
        public bool HasUser => User != null;
        
        /// <summary>
        /// Gets the geographic location of the tweet as reported by the user or client application.
        /// </summary>
        public TwitterCoordinates Coordinates { get; }

        /// <summary>
        /// Gets whether a geograpic location was reported for the tweet.
        /// </summary>
        public bool HasCoordinates => Coordinates != null;

        /// <summary>
        /// Gets a reference to the Twitter place the tweet is associated with (but not necessarily originating from).
        /// Use the <see cref="HasPlace"/> property to check whether the tweet is associated with a place.
        /// </summary>
        public TwitterPlace Place { get; }

        /// <summary>
        /// Gets whether the tweet is associated with a place.
        /// </summary>
        public bool HasPlace => Place != null;

        /// <summary>
        /// Gets the ID of the quoted tweet (if a quote).
        /// </summary>
        public long QuotedStatusId { get; }
        
        /// <summary>
        /// Gets the ID of the quoted tweet (if a quote).
        /// </summary>
        public string QuotedStatusIdStr { get; }

        /// <summary>
        /// Gets whether the tweet is a quoted tweet.
        /// </summary>
        public bool IsQuoteStatus { get; }

        /// <summary>
        /// If this tweet is quoting another tweet, this property will contain an instance of
        /// <see cref="TwitterStatusMessage"/> representing the original tweet.
        /// </summary>
        public TwitterStatusMessage QuotedStatus { get; }

        /// <summary>
        /// If this tweet is a retweet of another tweet, this property will contain an instance of
        /// <see cref="TwitterStatusMessage"/> representing the original tweet.
        /// </summary>
        public TwitterStatusMessage RetweetedStatus { get; }

        /// <summary>
        /// Indicates approximately how many times this tweet has been quoted by Twitter users.
        /// </summary>
        public int QuoteCount { get; }

        /// <summary>
        /// Gets the number of times this tweet has been replied to.
        /// </summary>
        public int ReplyCount { get; }

        /// <summary>
        /// Gets the number of times this tweet has been retweeted.
        /// </summary>
        public int RetweetCount { get; }

        /// <summary>
        /// Indicates approximately how many times this tweet has been liked by Twitter users.
        /// </summary>
        public int FavoriteCount { get; }

        /// <summary>
        /// Gets a reference to entities which have been parsed out of the text of the tweet.
        /// </summary>
        public TwitterStatusMessageEntities Entities { get; }

        /// <summary>
        /// Gets a reference to extended entities mentioned in the status message.
        /// </summary>
        public TwitterExtendedEntities ExtendedEntities { get; }

        /// <summary>
        /// Gets whether the status message has any extended entities.
        /// </summary>
        public bool HasExtendedEntities => ExtendedEntities != null;

        /// <summary>
        /// Gets whether the authenticated user has favorited the tweet.
        /// </summary>
        public bool HasFavorited { get; }
        
        /// <summary>
        /// Gets whether the authenticated user has retweeted the tweet.
        /// </summary>
        public bool HasRetweeted { get; }

        /// <summary>
        /// Gets whether links within the tweet text may contain sensitive content.
        /// </summary>
        public bool IsPossiblyOffensive { get; }

        // TODO: Add support for the "filter_level" property

        /// <summary>
        /// Gets the <a href="https://tools.ietf.org/html/bcp47">BCP 47</a> language identifier corresponding to the
        /// machine-detected language of the tweet text, or <c>und</c> if no language could be detected.
        /// </summary>
        public string Language { get; }

        // TODO: Add support for the "matching_rules" property

        /// <summary>
        /// Gets the date of the object that represents how the object can be sorted in a timeline.
        /// </summary>
        public EssentialsDateTime SortDate => CreatedAt;

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance based on the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> representing the status message.</param>
        protected TwitterStatusMessage(JObject obj) : base(obj) {

            // Parse basic properties
            Id = obj.GetInt64("id");
            IdStr = obj.GetString("id_str");
            Text = obj.GetString("text");
            FullText = obj.GetString("full_text");
            Source = obj.GetString("source");
            IsTruncated = obj.GetBoolean("truncated");

            // Twitter has some strange date formats
            CreatedAt = obj.GetString("created_at", TwitterUtils.ParseDateTimeUtc);

            // Parse the reply information
            if (obj.HasValue("in_reply_to_status_id")) {
                InReplyTo = new TwitterReplyTo {
                    StatusId = obj.GetInt64("in_reply_to_status_id"),
                    StatusIdStr = obj.GetString("in_reply_to_status_id_str"),
                    UserId = obj.GetInt64("in_reply_to_user_id"),
                    UserIdStr = obj.GetString("in_reply_to_user_id_str"),
                    ScreenName = obj.GetString("in_reply_to_screen_name")
                };
            }

            User = obj.GetObject("user", TwitterUser.Parse);
            
            // For some weird reason Twitter flips the coordinates by writing longitude before latitude
            // See: https://dev.twitter.com/docs/platform-objects/tweets#obj-coordinates)
            Coordinates = obj.GetObject("coordinates", TwitterCoordinates.Parse);

            Place = obj.GetObject("place", TwitterPlace.Parse);

            // Parse quote information
            QuotedStatusId = obj.GetInt64("quoted_status_id");
            QuotedStatusIdStr = obj.GetString("quoted_status_id_str");
            IsQuoteStatus = obj.GetBoolean("is_quote_status");


            QuotedStatus = obj.GetObject("quoted_status", Parse);
            RetweetedStatus = obj.GetObject("retweeted_status", Parse);

            QuoteCount = obj.GetInt32("quote_count");
            ReplyCount = obj.GetInt32("reply_count");
            RetweetCount = obj.GetInt32("retweet_count");
            FavoriteCount = obj.GetInt32("favorite_count");
            
            // Parse the entities (if any)
            Entities = obj.GetObject("entities", TwitterStatusMessageEntities.Parse);
            ExtendedEntities = obj.GetObject("extended_entities", TwitterExtendedEntities.Parse);

            // Related to the authenticating user
            HasFavorited = obj.GetBoolean("favorited");
            HasRetweeted = obj.GetBoolean("retweeted");

            // Misc
            IsPossiblyOffensive = obj.GetBoolean("possibly_sensitive");
            // TODO: Add support for the "filter_level" property
            Language = obj.GetString("lang");
            // TODO: Add support for the "matching_rules" property

        }

        #endregion

        #region Static methods

        /// <summary>
        /// Parses the specified <paramref name="obj"/> into an instance of <see cref="TwitterStatusMessage"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to be parsed.</param>
        /// <returns>An instance of <see cref="TwitterStatusMessage"/>.</returns>
        public static TwitterStatusMessage Parse(JObject obj) {
            return obj == null ? null : new TwitterStatusMessage(obj);
        }

        #endregion

    }

}