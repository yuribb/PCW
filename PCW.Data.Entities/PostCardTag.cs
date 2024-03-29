﻿namespace PCW.Data.Entities
{
    public class PostCardTag
    {
        public long Id { get; set; }
        public long PostCardId { get; set; }
        public long TagId { get; set; }

        public virtual Tag Tag { get; set; } = default!;
        public virtual PostCard PostCard { get; set; } = default!;
    }
}
