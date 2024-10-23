using System;
using System.Collections.Generic;

namespace _02._Articles
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int numberOfArticles = int.Parse(Console.ReadLine());

            List<Article> articles = new List<Article>();

            for (int i = 0; i < numberOfArticles; i++)
            {
                string[] info = Console.ReadLine().Split(", ");
                Article article = new Article(
                    info[0], info[1], info[2]);
                articles.Add(article);
            }
            string command = Console.ReadLine();

            foreach (Article article in articles)
            {
                article.ToString(article.Title, article.Content, article.Author);
            }
        }

        class Article
        {
            public Article(string title, string content, string author)
            {
                this.Title = title;
                this.Content = content;
                this.Author = author;
            }
            public string Title { get; set; }

            public string Content { get; set; }

            public string Author { get; set; }


            public void ToString(string title, string content, string author)
            {
                Console.WriteLine($"{title} - {content}: {author}");
            }
        }
    }
}