using System;

using Balancer.Model;

namespace Balancer.Views.TypeTesting.Statistics
{
    public class ResourceStatistic : NotifyingObject
    {
        private String name;
        public String Name
        {
            get
            {
                return this.name;
            }
            set
            {
                SetProperty(ref this.name, value);
            }
        }

        private float minValue = float.MaxValue;
        public float MinValue
        {
            get
            {
                return this.minValue;
            }
            set
            {
                SetProperty(ref this.minValue, value);
            }
        }

        private float maxValue;
        public float MaxValue
        {
            get
            {
                return this.maxValue;
            }
            set
            {
                SetProperty(ref this.maxValue, value);
            }
        }

        private float averageValue;
        public float AverageValue
        {
            get
            {
                return this.averageValue;
            }
            set
            {
                SetProperty(ref this.averageValue, value);
            }
        }

        private Int32 amount;
        public Int32 Amount
        {
            get
            {
                return this.amount;
            }
            set
            {
                SetProperty(ref this.amount, value);
            }
        }
    }
}
