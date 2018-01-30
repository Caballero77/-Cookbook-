namespace Cookbook.DAL.Entities
{
    using Newtonsoft.Json;

    /// <summary>
    ///     The entity of media file.
    /// </summary>
    public class Media : BaseEntity
    {
        /// <summary>
        ///     Gets or sets the media type.
        /// </summary>
        public virtual MediaType MediaType { get; set; }

        /// <summary>
        ///     Gets or sets the media type id.
        /// </summary>
        public int MediaTypeId { get; set; }

        /// <summary>
        ///     Gets or sets the name.
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Gets or sets the recipe.
        /// </summary>
        [JsonIgnore]
        public virtual Recipe Recipe { get; set; }

        /// <summary>
        ///     Gets or sets the recipe id.
        /// </summary>
        public int RecipeId { get; set; }

        /// <summary>
        ///     Gets or sets the url.
        /// </summary>
        public string Url { get; set; }
    }
}