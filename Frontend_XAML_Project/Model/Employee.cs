﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Newtonsoft.Json;

namespace AccountsManager.Model
{
    public class Employee : INotifyPropertyChanged
    {
        private int _Id;
        [JsonProperty("id")]
        public int Id
        {
            get { return _Id; }
            set
            {
                _Id = value;
                RaisePropertyChanged("Id");
            }
        }

        private string _Name;
        [JsonProperty("name")]
        public string Name
        {
            get { return _Name; }
            set
            {
                _Name = value;
                RaisePropertyChanged("Name");
            }
        }

        private int _CompanyId;
        [JsonProperty("companyId")]
        public int CompanyId
        {
            get { return _CompanyId; }
            set
            {
                _CompanyId = value;
                RaisePropertyChanged("CompanyId");
            }
        }

        protected void RaisePropertyChanged(string propertyName)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public override bool Equals(object obj)
        {
            return obj is Employee && ((Employee)obj).Id.Equals(Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
