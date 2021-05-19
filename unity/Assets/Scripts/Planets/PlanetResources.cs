using System;

using UnityEngine;

[Serializable]
public class PlanetResources
{
    [SerializeField]
    private PlanetResource oxygen;
    public PlanetResource Oxygen
    {
        get
        {
            return this.oxygen;
        }
        set
        {
            if (this.oxygen != value)
            {
                this.oxygen = value;
            }
        }
    }

    [SerializeField]
    private PlanetResource food;
    public PlanetResource Food
    {
        get
        {
            return this.food;
        }
        set
        {
            if (this.food != value)
            {
                this.food = value;
            }
        }
    }

    [SerializeField]
    private PlanetResource fuel;
    public PlanetResource Fuel
    {
        get
        {
            return this.fuel;
        }
        set
        {
            if (this.fuel != value)
            {
                this.fuel = value;
            }
        }
    }
}
