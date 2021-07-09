using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOP
{
    public class User
    {
        // private boolean to setting displayAge to true
        private bool _displayAge = true;
        // private nullish integer
        private int? _age;

        // class constructor requiring birthday parameter
        public User(DateTime birthday)
        {
            Birthday = birthday;
            Age = DateTime.Now.Year - Birthday.Year;
        }

        // public fields
        public string FullName { get; set; }
        public string Email { get; set; }
        public DateTime Birthday { get; set; }

        /* About Getters and Setters
           - A read-only property implements a get accessor
           - A write-only property implements a set accessor
           - A read-write property implements both, a get and set accessor
        */
        public int? Age
        {
            get { return _displayAge ? _age : null; } // get returns a property value
            set { _age = value; } // set accessor, assigns a new value using the "value" keyword
        }
        public Gender Gender { get; set; }
        public string Password { get; set; }
        public DateTime Created { get; } = DateTime.Now;

        public void ToggleAgePrivacy()
        {
            _displayAge = !_displayAge;
        }
    }
}
