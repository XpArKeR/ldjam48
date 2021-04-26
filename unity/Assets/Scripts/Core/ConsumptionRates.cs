using System;

using UnityEngine;

[Serializable]
public class ConsumptionRates
{
    [SerializeField]
    private float scan;
    public float Scan
    {
        get
        {
            return this.scan;
        }
        set
        {
            if (this.scan != value)
            {
                this.scan = value;
            }
        }
    }

    [SerializeField]
    private float movement;
    public float Movement
    {
        get
        {
            return this.movement;
        }
        set
        {
            if (this.movement != value)
            {
                this.movement = value;
            }
        }
    }

    [SerializeField]
    private float gatherOxygen;
    public float GatherOxygen
    {
        get
        {
            return this.gatherOxygen;
        }
        set
        {
            if (this.gatherOxygen != value)
            {
                this.gatherOxygen = value;
            }
        }
    }

    [SerializeField]
    private float gatherFood;
    public float GatherFood
    {
        get
        {
            return this.gatherFood;
        }
        set
        {
            if (this.gatherFood != value)
            {
                this.gatherFood = value;
            }
        }
    }

    [SerializeField]
    private float gatherFuel;
    public float GatherFuel
    {
        get
        {
            return this.gatherFuel;
        }
        set
        {
            if (this.gatherFuel != value)
            {
                this.gatherFuel = value;
            }
        }
    }
}
