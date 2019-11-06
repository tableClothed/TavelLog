using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SQLite;

namespace TrVELLog.Models
{
    public class Post : INotifyPropertyChanged
    {
        public string id;
        public string Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        public string experience;

        public string Experience
        {
            get { return Experience; }
            set {
                experience = value;
                OnPropertyChanged("Experience");
            }
        }
        public string venueName { get; set; }
        public string VenueName
        {
            get { return venueName; }
            set
            {
                venueName = value;
                OnPropertyChanged("VenueName");
            }
        }
        public string categoryId;
        public string CategoryId
        {
            get { return categoryId; }
            set
            {
                categoryId = value;
                OnPropertyChanged("CategoryId");
            }
        }
        public string categoryName;
        public string CategoryName
        {
            get { return categoryName; }
            set
            {
                categoryName = value;
                OnPropertyChanged("CategoryName");
            }
        }
        public string address;
        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                OnPropertyChanged("Address");
            }
        }
        public double longitude;
        public double Longitude
        {
            get { return longitude; }
            set
            {
                longitude = value;
                OnPropertyChanged("Longitude");
            }
        }
        public double latitude;
        public double Latitude
        {
            get { return latitude; }
            set
            {
                latitude = value;
                OnPropertyChanged("Latitude");
            }
        }
        public int distance;
        public int Distance
        {
            get { return distance; }
            set
            {
                distance = value;
                OnPropertyChanged("Distance");
            }
        }
        public string userId;
        public string UserId
        {
            get { return userId; }
            set
            {
                userId = value;
                OnPropertyChanged("UserId");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public async static void Insert(Post post)
        {
            await App.sql_conn.CreateTableAsync<Post>();
            await App.sql_conn.InsertAsync(post);
        }

        public async static void Delete(Post post)
        {
            await App.sql_conn.CreateTableAsync<Post>();
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

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
