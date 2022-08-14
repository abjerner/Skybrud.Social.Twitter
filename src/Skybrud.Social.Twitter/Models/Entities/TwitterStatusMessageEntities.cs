using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Twitter.Models.Entities {

    /// <summary>
    /// Class representing the entities of a Twitter status message.
    /// </summary>
    public class TwitterStatusMessageEntities : TwitterObject, ITwitterEntities {

        #region Properties

        /// <summary>
        /// Gets an array of all <see cref="TwitterHashTagEntity"/> in the status message.
        /// </summary>
        public IReadOnlyList<TwitterHashTagEntity> HashTags { get; }

        /// <summary>
        /// Gets an array of all <see cref="TwitterUrlEntity"/> in the status message.
        /// </summary>
        public IReadOnlyList<TwitterUrlEntity> Urls { get; }

        /// <summary>
        /// Gets an array of all <see cref="TwitterMentionEntity"/> in the status message.
        /// </summary>
        public IReadOnlyList<TwitterMentionEntity> Mentions { get; }

        /// <summary>
        /// Gets an array of all <see cref="TwitterMediaEntity"/> in the status message.
        /// </summary>
        public IReadOnlyList<TwitterMediaEntity> Media { get; }

        // Add support for the "symbols" property

        // Add support for the "polls" property

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of <see cref="TwitterStatusMessageEntities"/> parsed from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The <see cref="JObject"/> to be parsed.</param>
        protected TwitterStatusMessageEntities(JObject obj) : base(obj) {
            HashTags = obj.GetArrayItems("hashtags", TwitterHashTagEntity.Parse);
            Urls = obj.GetArrayItems("urls", TwitterUrlEntity.Parse);
            Mentions = obj.GetArrayItems("user_mentions", TwitterMentionEntity.Parse);
            Media = obj.GetArrayItems("media", TwitterMediaEntity.Parse);
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets a collection of all entities in an ascending order.
        /// </summary>
        public IReadOnlyList<TwitterBaseEntity> GetAll() {
            List<TwitterBaseEntity> temp = new();
            temp.AddRange(HashTags);
            temp.AddRange(Urls);
            temp.AddRange(Mentions);
            temp.AddRange(Media);
            return temp.OrderBy(x => x.StartIndex).ToArray();
        }

        /// <summary>
        /// Gets a collection of all entities in an descending order.
        /// </summary>
        public IReadOnlyList<TwitterBaseEntity> GetAllReversed() {
            List<TwitterBaseEntity> temp = new();
            temp.AddRange(HashTags);
            temp.AddRange(Urls);
            temp.AddRange(Mentions);
            temp.AddRange(Media);
            return temp.OrderByDescending(x => x.StartIndex).ToArray();
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="TwitterStatusMessageEntities"/> from the specified <see cref="JObject"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="TwitterStatusMessageEntities"/>.</returns>
        public static TwitterStatusMessageEntities Parse(JObject obj) {
            return obj == null ? null : new TwitterStatusMessageEntities(obj);
        }

        #endregion

    }

}