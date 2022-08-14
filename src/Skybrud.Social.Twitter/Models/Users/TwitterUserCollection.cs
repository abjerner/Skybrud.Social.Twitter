using System.Collections.Generic;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Twitter.Models.Users {

    /// <summary>
    /// Class representing a collection of Twitter users.
    /// </summary>
    public class TwitterUserCollection : TwitterObject {

        #region Properties

        /// <summary>
        /// Gets the array with the users returned in the response.
        /// </summary>
        public IReadOnlyList<TwitterUser> Users { get; }

        /// <summary>
        /// Gets the cursor pointing to the next page in the result set.
        /// </summary>
        public long NextCursor { get; }

        /// <summary>
        /// Gets the cursor pointing to the previous page in the result set.
        /// </summary>
        public long PreviousCursor { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of <see cref="TwitterUserCollection"/> parsed from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The <see cref="JObject"/> to be parsed.</param>
        private TwitterUserCollection(JObject obj) : base(obj) {
            Users = obj.GetArray("users", TwitterUser.Parse);
            NextCursor = obj.GetInt64("next_cursor");
            PreviousCursor = obj.GetInt64("previous_cursor");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="TwitterUserCollection"/> from the specified <see cref="JObject"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="TwitterUserCollection"/>.</returns>
        public static TwitterUserCollection Parse(JObject obj) {
            return obj == null ? null : new TwitterUserCollection(obj);
        }

        #endregion

    }

}