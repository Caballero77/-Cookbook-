namespace Cookbook.DAL.Entities
{
    using System.Collections.Generic;

    public class MediaType: BaseEntity
    {
        public string Name { get; set; }

        public virtual ICollection<Media> Medias { get; set; }
    }
}