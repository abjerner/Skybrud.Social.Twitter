using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json.Linq;
using Skybrud.Essentials.Json.Extensions;

namespace Skybrud.Social.Twitter.Entities {

    /// <summary>
    /// Class representing a collection of entities used in the description field of a Twitter user.
    /// </summary>
    public class TwitterUserDescriptionEntities : ITwitterEntities {

        #region Properties

        /// <summary>
        /// Gets an array of URLs specified in the description field for a user.
        /// </summary>
        public TwitterUrlEntity[] Urls { get; private set; }

        #endregion

        #region Constructors

        /// <summary>
        /// Initializes a new instance of <see cref="TwitterUserDescriptionEntities"/> parsed from the specified <paramref name="obj"/>.
        /// </summary>
        /// <param name="obj">The <see cref="JObject"/> to be parsed.</param>
        protected TwitterUserDescriptionEntities(JObject obj) {
            Urls = obj.GetArray("urls", TwitterUrlEntity.Parse);
        }

        #endregion

        #region Member methods

        /// <summary>
        /// Gets a collection of all entities in an ascending order.
        /// </summary>
        public TwitterBaseEntity[] GetAll() {
            List<TwitterBaseEntity> temp = new List<TwitterBaseEntity>();
            temp.AddRange(Urls);
            return temp.OrderBy(x => x.StartIndex).ToArray();
        }

        /// <summary>
        /// Gets a collection of all entities in an descending order.
        /// </summary>
        public TwitterBaseEntity[] GetAllReversed() {
            List<TwitterBaseEntity> temp = new List<TwitterBaseEntity>();
            temp.AddRange(Urls);
            return temp.OrderByDescending(x => x.StartIndex).ToArray();
        }

        #endregion

        #region Static methods

        /// <summary>
        /// Gets an instance of <see cref="TwitterUserDescriptionEntities"/> from the specified <see cref="JObject"/>.
        /// </summary>
        /// <param name="obj">The instance of <see cref="JObject"/> to parse.</param>
        public static TwitterUserDescriptionEntities Parse(JObject obj) {
            return obj == null ? null : new TwitterUserDescriptionEntities(obj);
        }

        #endregion

    }

}