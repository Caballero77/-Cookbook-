namespace Cookbook.BLL.DataTransferObjects
{
    using System;

    public class RecipeShortInfoDTO
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Description { get; set; }

        public DateTime CreationDate { get; set; }

        public string ImageUrl { get; set; }

        public bool IsHistoryItem { get; set; }
    }
}