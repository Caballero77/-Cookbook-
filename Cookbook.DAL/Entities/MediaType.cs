namespace Cookbook.DAL.Entities
{
    using System.Collections.Generic;

    using Newtonsoft.Json;

    /// <summary>
    ///     The entity of media type.
    /// </summary>
    public class MediaType : BaseEntity
    {
        /// <summary>
        ///     Gets or sets the medias.
        /// </summary>
        [JsonIgnore]
        public virtual ICollection<Media> Medias { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        public string Name { get; set; }
    }
}