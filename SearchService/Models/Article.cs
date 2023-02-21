﻿namespace SearchService.Models
{
    public class Article
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Author { get; set; }
        public string AuthorLink { get; set; }
        public DateTime PublishDate { get; set; }
    }
}
