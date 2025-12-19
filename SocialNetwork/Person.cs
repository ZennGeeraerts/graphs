using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SocialNetwork
{
    internal class Person
    {
        private int _id;
        private string _name;

        public Person(int id, string name)
        {
            _id = id; _name = name;
        }

        public override string ToString()
        {
            return $"Person with id: {_id} and name: {_name}";
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(_id.GetHashCode(), _name.GetHashCode());
        }
    }
}
