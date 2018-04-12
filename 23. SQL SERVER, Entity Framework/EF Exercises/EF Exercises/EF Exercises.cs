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
            //JoinAuthorsWithTitles();

            //Select Author from specific post
            //SelectAuthor();

            //Order Posts Authors
            //OrderAuthors();

            //Create a new Post
            //CreatePost();

            //Edit user details
            //EditUser();

            //Delete comment from post
            //DeleteComment();

            //Delete Post
            //PostDelete();

            //Extract posts without specified tag
            //PostsWithoutTag();

            //Change text of all comments which has tag security to the fullname of the author
            //ChangeComments();

            //Print all comments by given user
            //PrintAllUserComments();

            //Presenting the Database
            //PresentDatabase();

        }

        private static void PresentDatabase()
        {
            var db = new BlogDbContext();

            var users = db.Users
                .OrderBy(u => u.Id)
                .ToArray();

            for (var i = 0; i < users.Length; i++)
            {
                var currentUser = users[i];

                Console.WriteLine();
                Console.WriteLine($"{currentUser.Id}. {currentUser.UserName}");
                Console.WriteLine($"Posts:");
                Console.WriteLine();

                var userPosts = currentUser.Posts
                    .OrderBy(p => p.Date)
                    .ThenBy(p => p.Id)
                    .ToArray();

                for (var j = 0; j < userPosts.Length; j++)
                {
                    var currentPost = userPosts[j];

                    var titleLenght = Math.Min(30, currentPost.Title.Length - 1);
                    var contentLenght = Math.Min(30, currentPost.Body.Length - 1);

                    Console.WriteLine($"####{currentPost.Id}. {currentPost.Title.Substring(0, titleLenght).Trim()} ...");
                    Console.WriteLine($"####Date:{currentPost.Date}");
                    Console.WriteLine($"####Tags: {String.Join(", ", currentPost.Tags.Select(t => t.Name).ToList()).Trim()}");
                    Console.WriteLine($"####Content: {currentPost.Body.Substring(0, contentLenght).Trim()} ...");
                    Console.WriteLine($"####Comments: ");
                    Console.WriteLine();

                    var postComments = currentPost.Comments
                        .OrderBy(c => c.Date)
                        .ThenBy(c => c.AuthorName)
                        .ToArray();

                    for (var k = 0; k < postComments.Length; k++)
                    {
                        var currentComment = postComments[k];
                        var currentAuthor = string.Empty;

                        if (currentComment.AuthorName == null)
                        {
                            currentAuthor = db.Users.Find(currentComment.AuthorId).FullName;
                        }
                        else
                        {
                            currentAuthor = currentComment.AuthorName;
                        }

                        var comentLenght = Math.Min(30, currentComment.Text.Length - 1);

                        Console.WriteLine($"#### ####Author: {currentAuthor}");
                        Console.WriteLine($"#### ####Comment: {currentComment.Text.Substring(0, comentLenght).Trim()} ...");
                        Console.WriteLine();
                    }
                }
            }
        }

        private static void PrintAllUserComments()
        {
            var username = Console.ReadLine();

            var db = new BlogDbContext();

            var user = db.Users.Where(u => u.UserName == username).FirstOrDefault();

            if (user == null)
            {
                Console.WriteLine("None");
            }

            var comments = db.Comments
                .Where(c => c.AuthorId == user.Id)
                .Select(c => c.Text)
                .ToList();

            Console.WriteLine(String.Join(Environment.NewLine, comments));

        }

        private static void ChangeComments()
        {
            var db = new BlogDbContext();

            var tagSecurity = db.Tags.SingleOrDefault(t => t.Name == "security");

            var commentsIds = db.Comments
                .ToList()
                .Where(c => c.Post.Tags.Contains(tagSecurity))
                .Select(c => c.Id)
                .ToList();

            for (var i = 0; i < commentsIds.Count; i++)
            {
                var currentComment = db.Comments.Find(commentsIds[i]);

                if (currentComment == null)
                {
                    continue;
                }

                var oldComment = currentComment;

                if (currentComment.AuthorName != null)
                {
                    currentComment.Text = currentComment.AuthorName;
                }
                else
                {
                    currentComment.Text = db.Users.Find(currentComment.AuthorId).FullName;
                }

                db.SaveChanges();
                Console.WriteLine($"Comment: {oldComment.Text} has changed to {currentComment.Text}");
            }

        }

        private static void PostsWithoutTag()
        {
            var db = new BlogDbContext();

            var tagIt = db.Tags.SingleOrDefault(t => t.Name == "it");

            if (tagIt == null)
            {
                Console.WriteLine("Tag Not Found!");
                return;
            }

            var posts = db.Posts.ToList().Where(p => !p.Tags.Contains(tagIt));

            foreach (var post in posts)
            {
                Console.WriteLine($"{post.Id}.{post.Body.Trim()}");
                Console.WriteLine();
            }
        }

        private static void PostDelete()
        {
            var db = new BlogDbContext();

            var postInfoQuery = db.Posts
                .Select(p => new PostInfo
                {
                    ID = p.Id,
                    PostComments = p.Comments,
                    PostTags = p.Tags
                })
                .Where(p => p.ID == 35);

            var postInfo = postInfoQuery.SingleOrDefault();

            var post = db.Posts.Where(p => p.Id == 35).SingleOrDefault();

            if (postInfo == null || post == null)
            {
                Console.WriteLine($"Post Not Found!");
                return;
            }

            Console.WriteLine(postInfoQuery);
            Console.WriteLine();
            PrintPostInfo(postInfo);

            db.Comments.RemoveRange(post.Comments);
            post.Tags.Clear();
            db.Posts.Remove(post);
            db.SaveChanges();

            Console.WriteLine($"Post #{post.Id} deleted successfully");
        }

        private static void PrintPostInfo(PostInfo postInfo)
        {
            Console.WriteLine($"Post ID: {postInfo.ID}");
            Console.WriteLine($"{String.Join("; ", postInfo.PostComments.Select(p => p.Text))}");
            Console.WriteLine($"{String.Join("; ", postInfo.PostTags.Select(t => t.Name))}");
        }

        private static void DeleteComment()
        {
            var db = new BlogDbContext();

            var commentInfo = db.Comments.SingleOrDefault(c => c.Id == 1);

            if (commentInfo == null)
            {
                Console.WriteLine($"Comment not found!");
                return;
            }

            db.Comments.Remove(commentInfo);
            db.SaveChanges();

            Console.WriteLine($"Comment #{commentInfo.Id} deleted!");
        }

        private static void EditUser()
        {
            var db = new BlogDbContext();

            var userInfo = db.Users.SingleOrDefault(user => user.UserName == "GBotev");

            if (userInfo == null)
            {
                Console.WriteLine("User Not Found!");
                return;
            }

            var oldName = userInfo.FullName;

            userInfo.FullName = "Georgi Botev";

            db.SaveChanges();

            Console.WriteLine($"User {oldName} has been renamed to {userInfo.FullName}");
        }

        private static void CreatePost()
        {
            var db = new BlogDbContext();

            var post = new Post()
            {
                AuthorId = 2,
                Title = "Random Title",
                Body = "Random Content",
                Date = DateTime.Now,
            };

            db.Posts.Add(post);
            db.SaveChanges();

            Console.WriteLine($"Post #{post.Id} created!");
        }

        private static void OrderAuthors()
        {
            var db = new BlogDbContext();

            var authorsQuery = db.Users
                .Where(u => u.Posts.Count > 0)
                .Select(u => new
                {
                    Username = u.UserName,
                    FullName = u.FullName,
                    Id = u.Id,
                })
                .OrderByDescending(x => x.Id);

            Console.WriteLine(authorsQuery);
            Console.WriteLine();

            var orderedAuthors = authorsQuery.ToList();

            foreach (var author in orderedAuthors)
            {
                Console.WriteLine($"Username: {author.Username}");
                Console.WriteLine($"Full Name: {author.FullName}");
            }
        }

        private static void SelectAuthor()
        {
            var db = new BlogDbContext();

            var author = db.Users
                .SelectMany(user => user.Posts, (user, post) => new {user.UserName, user.FullName, post.Id})
                .Single(post => post.Id == 4);

            Console.WriteLine($"Username: {author.UserName}");
            Console.WriteLine($"Full Name: {author.FullName}");
            Console.WriteLine();

            Console.WriteLine(db.Posts.Find(4).User.UserName);
            Console.WriteLine(db.Posts.Find(4).User.FullName);
            Console.WriteLine();
        }

        private static void JoinAuthorsWithTitles()
        {
            var db = new BlogDbContext();

            var query = db.Users
                .SelectMany(u => u.Posts, (user, post) => new {user.UserName, post.Title, user.Posts.Count})
                .OrderByDescending(x => x.Count);

            Console.WriteLine(query);
            Console.WriteLine();

            var users = query.ToList();

            foreach (var user in users)
            {
                Console.WriteLine($"Username: {user.UserName}");
                Console.WriteLine($"Title: {user.Title.Trim()}");
                Console.WriteLine();
            }
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

    class PostInfo
    {
        public int ID { get; set; }
        public ICollection<Comments> PostComments { get; set; }
        public ICollection<Tag> PostTags { get; set; }

    }

    class PostData
    {
        public int ID { get; set; }
        public string Title { get; set; }
        public DateTime Date { get; set; }
    }
}
