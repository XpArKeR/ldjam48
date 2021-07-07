using System;
using System.Collections.ObjectModel;

using Balancer.Model.Planets;

namespace Balancer.Model
{
    public class Turn : NotifyingObject
    {
        private Int32 number;
        public Int32 Number
        {
            get
            {
                return this.number;
            }
            set
            {
                SetProperty(ref this.number, value);
            }
        }

        private ObservableCollection<Planet> planets = new ObservableCollection<Planet>();
        public ObservableCollection<Planet> Planets
        {
            get
            {
                return this.planets;
            }
        }
    }
}
