namespace EF_Exercises
{
    using System;
    using System.Linq;
    using System.Collections.Generic;

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

            //List All Rows From Posts
            //ListAllPosts();

            //ListAllUsers
            //AllUsers();

            //List Title and Body from Posts
            //TitleAndBody();

            //Order users by user and fullname
            //ListOrderedUsers();

            //Order by two columns
            //ListOrderedUsersByTwoColumns();

            //Select Authors and Order them by posts count
            //SelectUsersCreatedPosts();

            //Join Authors with Titles
            JoinAuthorsWithTitles();
        }

        private static void JoinAuthorsWithTitles()
        {
            var db = new BlogDbContext();


        }

        private static void SelectUsersCreatedPosts()
        {
            var db = new BlogDbContext();

            var usersQuery = db.Users
                .Where(u => u.Posts.Count > 0)
                .Select(u => new
                {
                    UserName = u.UserName,
                    FullName = u.FullName,
                    PostsCount = u.Posts.Count,
                })
                .OrderByDescending(u => u.PostsCount);

            Console.WriteLine(usersQuery);
            Console.WriteLine();

            var users = usersQuery.ToList();

            foreach (var user in users)
            {
                Console.WriteLine($"Username: {user.UserName}");
                Console.WriteLine($"Full Name: {user.FullName}");
                Console.WriteLine($"Posts Count: {user.PostsCount}");
                Console.WriteLine();
            }
        }

        private static void ListOrderedUsersByTwoColumns()
        {
            var db = new BlogDbContext();

            var userQuery = db.Users
                .Select(u => new
                {
                    Username = u.UserName,
                    FullName = u.FullName,
                })
                .OrderByDescending(u => u.Username)
                .ThenByDescending(u => u.FullName);

            Console.WriteLine(userQuery);
            Console.WriteLine();

            var users = userQuery.ToList();

            foreach (var user in users)
            {
                Console.WriteLine($"Username: {user.Username}");
                Console.WriteLine($"Full Name: {user.FullName}");
                Console.WriteLine();
            }
        }

        private static void ListOrderedUsers()
        {
            var db = new BlogDbContext();

            var usersQuery = db.Users
                .Select(u => new
                {
                    Username = u.UserName,
                    FullName = u.FullName
                })
                .OrderBy(u => u.Username);

            Console.WriteLine(usersQuery);
            Console.WriteLine();

            var users = usersQuery.ToList();

            foreach (var user in users)
            {
                Console.WriteLine($"Username: {user.Username}");
                Console.WriteLine($"Full Name: {user.FullName}");
                Console.WriteLine();
            }
        }

        private static void TitleAndBody()
        {
            var db = new BlogDbContext();

            var postsQuery = db.Posts
                .Select(p => new
                    {
                        Title = p.Title,
                        Body = p.Body
                    });

            var posts = postsQuery.ToList();

            Console.WriteLine(postsQuery);
            Console.WriteLine();

            foreach (var p in posts)
            {
                Console.WriteLine($"Title: {p.Title}");
                Console.WriteLine($"Body: {p.Body}");
                Console.WriteLine();
            }
        }

        private static void AllUsers()
        {
            var db = new BlogDbContext();

            var users = db.Users.ToList();

            foreach (var user in users)
            {
                Console.WriteLine($"ID: {user.Id}");
                Console.WriteLine($"Name: {user.FullName}");
                Console.WriteLine($"Comments Count: {user.Comments.Count}");
                Console.WriteLine($"Posts Count: {user.Posts.Count}");
                Console.WriteLine();
            }
        }

        private static void ListAllPosts()
        {
            var db = new BlogDbContext();

            var posts = db.Posts.ToList();

            foreach (var p in posts)
            {
                Console.WriteLine($"Title: {p.Title.Trim()}");
                Console.WriteLine($"Author Id: {p.AuthorId}");
                Console.WriteLine($"Comments Count: {p.Comments.Count}");
                Console.WriteLine($"Tags Count: {p.Tags.Count}");
                Console.WriteLine();
            }
        }

        private static void ExtractingPostsBetweenDatesWithNativeSql()
        {
            var db = new BlogDbContext();

            var startDate = new DateTime(2016, 05, 19);
            var endDate = new DateTime(2016, 06, 14);

            var posts = db.Database.SqlQuery<PostData>(
                @"SELECT ID, Title, Date FROM Post
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

            var post = new Post()
            {
                Title = "New Post Title",
                Date = DateTime.Now,
                Body = "This post have comments and tags",
                User = db.Users.First(),
                Comments = new Comments[]
                {
                    new Comments() {Text = "Comment 1", AuthorName = "Test Author", Date = DateTime.Now},
                    new Comments()
                    {
                        Text = "Comment 2",
                        Date = DateTime.Now,
                        User = db.Users.First()
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

            var post = new Post()
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

            // Use LINQ to query the Post enities -> creates SQL Query
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
