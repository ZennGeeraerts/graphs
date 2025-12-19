using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DroneDelivery
{
    internal class City
    {
        private string _name;
        private bool _canRecharge;

        public City(string name, bool canRecharge)
        {
            _name = name;
            _canRecharge = canRecharge;
        }

        public string Name { get { return _name; } }
        public bool CanRecharge { get { return _canRecharge; } }
    }
}
