using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Twitter.Entities {

    /// <summary>
    /// Class representing a collection of URL entities of a Twitter user.
    /// </summary>
    public class TwitterUserUrlEntities : ITwitterEntities {

        #region Properties

        /// <summary>
        /// Gets an array of URLs specified in the URL field for a user. Twitter users can only
        /// specify a single URL in their profiles, but an array is still returned by the Twitter
        /// API.
        /// </summary>
        public TwitterUrlEntity[] Urls { get; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of <see cref="TwitterUserUrlEntities"/> parsed from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The <see cref="JObject"/> to be parsed.</param>
        protected TwitterUserUrlEntities(JObject obj) {
            Urls = obj.GetArray("urls", TwitterUrlEntity.Parse);
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets a collection of all entities in ascending order.
        /// </summary>
        public TwitterBaseEntity[] GetAll() {
            List<TwitterBaseEntity> temp = new List<TwitterBaseEntity>();
            temp.AddRange(Urls);
            return temp.OrderBy(x => x.StartIndex).ToArray();
        }

        /// <summary>
        /// Gets a collection of all entities in descending order.
        /// </summary>
        public TwitterBaseEntity[] GetAllReversed() {
            List<TwitterBaseEntity> temp = new List<TwitterBaseEntity>();
            temp.AddRange(Urls);
            return temp.OrderByDescending(x => x.StartIndex).ToArray();
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="TwitterUserUrlEntities"/> from the specified <see cref="JObject"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        public static TwitterUserUrlEntities Parse(JObject obj) {
            return obj == null ? null : new TwitterUserUrlEntities(obj);
        }

        #endregion

    }

}