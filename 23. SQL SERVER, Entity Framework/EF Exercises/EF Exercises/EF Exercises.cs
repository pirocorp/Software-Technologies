namespace EF_Exercises
{
    using System;
    using System.Linq;

    class EfExercises
    {
        static void Main(string[] args)
        {
            //Test Connection to DB
            //ListAllUsers();

            //CRUD Operation

            //Query Data
            //MakingQuery();

            //Create New Data
            //CreateNewPost();

            //Cascading Insert
            //CascadingInsert();

            //Update Existing Data
            //RandomPassword();

            //Delete Existing Data
            //DeletePost();

            //Native SQL
            //ExtractingPostsBetweenDatesWithNativeSql();


        }

        private static void ExtractingPostsBetweenDatesWithNativeSql()
        {
            var db = new BlogDbContext();

            var startDate = new DateTime(2016, 05, 19);
            var endDate = new DateTime(2016, 06, 14);

            var posts = db.Database.SqlQuery<PostData>(
                @"SELECT ID, Title, Date FROM Posts
                    WHERE CONVERT(date, Date)
                    BETWEEN {0} AND {1}
                    ORDER BY Date",
                startDate, endDate);

            foreach (var p in posts)
            {
                Console.WriteLine($"#{p.ID}: {p.Title} ({p.Date})");
            }
        }

        private static void DeletePost()
        {
            var db = new BlogDbContext();

            var lastPost = db.Posts
                .OrderByDescending(p => p.Id)
                .First();

            db.Comments.RemoveRange(lastPost.Comments);
            lastPost.Tags.Clear();
            db.Posts.Remove(lastPost);
            db.SaveChanges();

            Console.WriteLine($"Deleted post #{lastPost.Id}");
        }

        private static void RandomPassword()
        {
            var db = new BlogDbContext();

            var user = db.Users
                .Where(u => u.UserName == "guest")
                .First();

            user.PasswordHash = Guid.NewGuid().ToByteArray();

            db.SaveChanges();

            Console.WriteLine("User #{0} ({1}) has a new random password.", user.Id, user.UserName);
        }

        private static void CascadingInsert()
        {
            var db = new BlogDbContext();

            var post = new Posts()
            {
                Title = "New Post Title",
                Date = DateTime.Now,
                Body = "This post have comments and tags",
                Users = db.Users.First(),
                Comments = new Comments[]
                {
                    new Comments() {Text = "Comment 1", AuthorName = "Test Author", Date = DateTime.Now},
                    new Comments()
                    {
                        Text = "Comment 2",
                        Date = DateTime.Now,
                        Users = db.Users.First()
                    }
                },
                Tags = db.Tags.Take(3).ToList()
            };

            db.Posts.Add(post);
            db.SaveChanges();
        }

        private static void CreateNewPost()
        {
            var db = new BlogDbContext();

            var post = new Posts()
            {
                Title = "New Title",
                Body = "New Post Body",
                Date = DateTime.Now
            };

            db.Posts.Add(post);
            db.SaveChanges();

            Console.WriteLine("Post #{0} created.", post.Id);
        }

        private static void MakingQuery()
        {
            var db = new BlogDbContext();

            // Use LINQ to query the Posts enities -> creates SQL Query
            var posts = db.Posts.Select(p => new
            {
                p.Id,
                p.Title,
                Comments = p.Comments.Count(),
                Tags = p.Tags.Count()
            });

            //Print query created above
            Console.WriteLine("SQL query:\n{0}\n", posts);

            foreach (var p in posts)
            {
                Console.WriteLine($"{p.Id} {p.Title} ({p.Comments} comments, {p.Tags} tags)");
            }
        }

        private static void ListAllUsers()
        {
            var db = new BlogDbContext();
            foreach (var user in db.Users)
                Console.WriteLine(user.UserName);
        }
    }

    class PostData
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
    }
}
