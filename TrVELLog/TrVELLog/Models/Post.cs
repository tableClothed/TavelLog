using System;
using System.Collections.Generic;
using System.Linq;
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
        public async static void Insert(Post post)
        {
            await App.sql_conn.InsertAsync(post);
        }

        public async static void Delete(Post post)
        {
            await App.sql_conn.DeleteAsync(post);
        }

        public async static Task<List<Post>> Read()
        {
            var posts = await App.sql_conn.Table<Post>().ToListAsync() as List<Post>;

            return posts;
        }

        public static Dictionary<string, int> PostCategories(List<Post> posts)
        {
           
            var categories = posts.OrderBy(u => u.CategoryId).Select(u => u.CategoryName).Distinct().ToList();

            Dictionary<string, int> categoriesCount = new Dictionary<string, int>();
            foreach (var cat in categories)
            {
                var count = posts.Where(u => u.CategoryName == cat).ToList().Count();

                categoriesCount.Add(cat, count);
            }

            return categoriesCount;

            
        }
    }
}
