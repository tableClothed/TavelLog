using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace TrVELLog.Models
{
    public class Post
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(255)]
        public string Experience { get; set; }
        public string VenueName { get; set; }
        public string CategoryId { get; set; }
        public string CategoryName { get; set; }
        public string Address { get; set; }
        public double Longitude { get; set; }
        public double Latitude { get; set; }
        public int Distance { get; set; }
        public static void Insert(Post post)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                conn.CreateTable<Post>();
                int rows = conn.Insert(post);

                if (rows > 0)
                    throw new Exception("Cos poszlo nie tak");

            }
        }

        public static void Delete(Post post)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                try {
                    conn.CreateTable<Post>();
                    conn.Delete(post);
                } catch (Exception ex)
                {
                    throw new Exception("Cos poszlo nie tak");

                }
            }
        }

        public static List<Post> Read()
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                try
                {
                    conn.CreateTable<Post>();
                    var posts = conn.Table<Post>().ToList() as List<Post>;

                    return posts;

                }
                catch (Exception ex)
                {
                    throw new Exception("Cos poszlo nie tak");

                }

            }
        }

        public static Dictionary<string, int> PostCategories(List<Post> posts)
        {
            using (SQLiteConnection conn = new SQLiteConnection(App.DatabaseLocation))
            {
                var postTable = conn.Table<Post>().ToList();

                var categories = postTable.OrderBy(u => u.CategoryId).Select(u => u.CategoryName).Distinct().ToList();

                Dictionary<string, int> categoriesCount = new Dictionary<string, int>();
                foreach (var cat in categories)
                {
                    var count = postTable.Where(u => u.CategoryName == cat).ToList().Count();

                    categoriesCount.Add(cat, count);
                }

                return categoriesCount;

            }
        }
    }
}
