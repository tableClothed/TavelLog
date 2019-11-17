using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace TrVELLog.Models
{
    class Place : INotifyPropertyChanged
    {
        private string id;
        public string Id
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }
        private string experience;

        public string Experience
        {
            get { return Experience; }
            set
            {
                experience = value;
                OnPropertyChanged("Experience");
            }
        }
        private string venueName { get; set; }
        public string VenueName
        {
            get { return venueName; }
            set
            {
                venueName = value;
                OnPropertyChanged("VenueName");
            }
        }
        private string categoryId;
        public string CategoryId
        {
            get { return categoryId; }
            set
            {
                categoryId = value;
                OnPropertyChanged("CategoryId");
            }
        }
        private string categoryName;
        public string CategoryName
        {
            get { return categoryName; }
            set
            {
                categoryName = value;
                OnPropertyChanged("CategoryName");
            }
        }
        private string address;
        public string Address
        {
            get { return address; }
            set
            {
                address = value;
                OnPropertyChanged("Address");
            }
        }
        private double longitude;
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
        private int distance;
        public int Distance
        {
            get { return distance; }
            set
            {
                distance = value;
                OnPropertyChanged("Distance");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
