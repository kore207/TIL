using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AnimalShelter
{
    class Customer //앞에 아무것도 없으면 internal이 생략되어있다. 
    {
        public string FirstName;
       
        public string LastName;
        public int _Age;
        public string Address;
        public string Description;
        public bool _IsQualified;

        public Customer(string firstName, string lastName, int age)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Age = age;
            this._IsQualified = age >= 18;
        }

        public int GetAge()
        {
            return _Age;
        }

        //public void SetAge(int age)
        //{
        //    _Age = age;
        //    _IsQualified = age >= 18;
        //}
        public int Age //속성 정의 
        {
            get { return _Age; }
            set//SetAge와 같은 기능 
            {
                _Age = value; 
                _IsQualified = value >= 18;
            }
        }
        
        //public bool GetIsQualified()
        //{
        //    return _IsQualified;
        //}
        public bool IsQualified
        {
            get//get만 있으므로 읽기 전용 
            {
                return _IsQualified;
            }
        }

        public string FullName
        {
            get { return FirstName + " " + LastName; }
        }
        
    }
}
