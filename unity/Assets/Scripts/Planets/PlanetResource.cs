
using System;

using UnityEngine;

[Serializable]
public class PlanetResource
{
    [SerializeField]
    private float value;
    public float Value
    {
        get
        {
            return this.value;
        }
        set
        {
            if (this.value != value)
            {
                this.value = value;
            }
        }
    }

    [SerializeField]
    private float rangeMin;
    public float RangeMin
    {
        get
        {
            return this.rangeMin;
        }
        set
        {
            if (this.rangeMin != value)
            {
                this.rangeMin = value;
            }
        }
    }

    [SerializeField]
    private float rangeMax;
    public float RangeMax
    {
        get
        {
            return this.rangeMax;
        }
        set
        {
            if (this.rangeMax != value)
            {
                this.rangeMax = value;
            }
        }
    }

    [SerializeField]
    private float dispersion;
    public float Dispersion
    {
        get
        {
            return this.dispersion;
        }
        set
        {
            if (this.dispersion != value)
            {
                this.dispersion = value;
            }
        }
    }

    [SerializeField]
    private float dispersionRangeMin;
    public float DispersionRangeMin
    {
        get
        {
            return this.dispersionRangeMin;
        }
        set
        {
            if (this.dispersionRangeMin != value)
            {
                this.dispersionRangeMin = value;
            }
        }
    }

    [SerializeField]
    private float dispersionRangeMax;
    public float DispersionRangeMax
    {
        get
        {
            return this.dispersionRangeMax;
        }
        set
        {
            if (this.dispersionRangeMax != value)
            {
                this.dispersionRangeMax = value;
            }
        }
    }
}
