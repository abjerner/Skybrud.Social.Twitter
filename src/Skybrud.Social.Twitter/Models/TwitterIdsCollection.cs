using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Twitter.Models {

    /// <summary>
    /// Class representing a list of IDs.
    /// </summary>
    public class TwitterIdsCollection : TwitterObject {

        #region Properties

        /// <summary>
        /// Gets the array with the IDs returned in the response.
        /// </summary>
        public long[] Ids { get; }

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
        /// Initializes a new instance of <see cref="TwitterIdsCollection"/> parsed from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The <see cref="JObject"/> to be parsed.</param>
        protected TwitterIdsCollection(JObject obj) : base(obj) {
            Ids = obj.GetInt64Array("ids");
            NextCursor = obj.GetInt64("next_cursor");
            PreviousCursor = obj.GetInt64("previous_cursor");
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="TwitterIdsCollection"/> from the specified <see cref="JObject"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        /// <returns>An instance of <see cref="TwitterIdsCollection"/>.</returns>
        public static TwitterIdsCollection Parse(JObject obj) {
            return obj == null ? null : new TwitterIdsCollection(obj);
        }

        #endregion

    }

}