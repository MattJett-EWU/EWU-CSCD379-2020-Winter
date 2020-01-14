using System;

namespace SecretSanta.Business
{
    public class BlogPost
    {
        private string _Content = "invalid";

        public string Title { get; }

        public string Content
        {
            get => _content;
            set => _content = value ?? throw new ArgumentNullException(nameof(value));
        }

        public DateTime Now { get; set; }
        public string Author { get; set; }


        public BlogPost(string title, string content, DateTime now, string author)
        {
            Title = title ?? throw new ArgumentNullException(nameof(title));
            Content = content ?? throw new ArgumentNullException(nameof(content));
            Now = now;
            Author = author;
        }        
    }
}