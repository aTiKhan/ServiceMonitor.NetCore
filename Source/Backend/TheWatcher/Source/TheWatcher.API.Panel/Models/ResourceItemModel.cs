﻿namespace TheWatcher.API.Panel.Models
{
    public record ResourceItemModel
    {
        public short? Id { get; set; }
        public string Name { get; set; }
        public short? ResourceCategoryId { get; set; }
        public string ResourceCategory { get; set; }
    }
}
