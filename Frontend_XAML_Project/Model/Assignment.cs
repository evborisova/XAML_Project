using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using Newtonsoft.Json;

namespace AccountsManager.Model
{
    public class Assignment : INotifyPropertyChanged
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

        private int _WorkingHoursPercentage;
        [JsonProperty("workingHoursPercentage")]
        public int WorkingHoursPercentage
        {
            get { return _WorkingHoursPercentage; }
            set
            {
                _WorkingHoursPercentage = value;
                RaisePropertyChanged("WorkingHoursPercentage");
            }
        }

        private string _Description;
        [JsonProperty("description")]
        public string Description
        {
            get { return _Description; }
            set
            {
                _Description = value;
                RaisePropertyChanged("Description");
            }
        }

        private float _Cost;
        [JsonProperty("cost")]
        public float Cost
        {
            get { return _Cost; }
            set
            {
                _Cost = value;
                RaisePropertyChanged("Cost");
            }
        }

        private DateTime _CreationDate;
        [JsonProperty("creationDate")]
        public DateTime CreationDate
        {
            get { return _CreationDate; }
            set
            {
                _CreationDate = value;
                RaisePropertyChanged("CreationDate");
            }
        }

        private DateTime _StartDate;
        [JsonProperty("startDate")]
        public DateTime StartDate
        {
            get { return _StartDate; }
            set
            {
                _StartDate = value;
                RaisePropertyChanged("StartDate");
            }
        }

        private DateTime _EndDate;
        [JsonProperty("endDate")]
        public DateTime EndDate
        {
            get { return _EndDate; }
            set
            {
                _EndDate = value;
                RaisePropertyChanged("EndDate");
            }
        }

        private int? _CompanyId;
        [JsonProperty("companyId")]
        public int? CompanyId
        {
            get { return _CompanyId; }
            set
            {
                _CompanyId = value;
                RaisePropertyChanged("CompanyId");
            }
        }

        private int? _EmployeeId;
        [JsonProperty("employeeId")]
        public int? EmployeeId
        {
            get { return _EmployeeId; }
            set
            {
                _EmployeeId = value;
                RaisePropertyChanged("EmployeeId");
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
            return obj is Assignment && ((Assignment)obj).Id.Equals(Id);
        }

        public override int GetHashCode()
        {
            return Id.GetHashCode();
        }
    }
}
