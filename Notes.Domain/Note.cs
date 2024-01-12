﻿namespace Notes.Domain
{
    public class Note
    {
        public Guid UserId { get; set; }
        public Guid Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Detail { get; set; } = string.Empty;
        public DateTime CreationDate { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
