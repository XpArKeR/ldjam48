using System;
using System.Collections.Generic;

using UnityEngine;

[Serializable]
public class PlanetType
{
    [SerializeField]
    private String name;
    public String Name
    {
        get
        {
            return this.name;
        }
        set
        {
            if (this.name != value)
            {
                this.name = value;
            }
        }
    }

    [SerializeField]
    private PlanetResources resources;
    public PlanetResources Resources
    {
        get
        {
            return this.resources;
        }
        set
        {
            if (this.resources != value)
            {
                this.resources = value;
            }
        }
    }

    [SerializeField]
    private List<String> landSprites;
    public List<String> LandSprites
    {
        get
        {
            return this.landSprites;
        }
    }

    [SerializeField]
    private List<String> cloudSprites;
    public List<String> CloudSprites
    {
        get
        {
            return this.cloudSprites;
        }
    }

    [SerializeField]
    private List<Color> baseColors;
    public List<Color> BaseColors
    {
        get
        {
            return this.baseColors;
        }
    }

    [SerializeField]
    private List<Color> landColors;
    public List<Color> LandColors
    {
        get
        {
            return this.landColors;
        }
    }

    [SerializeField]
    private List<Color> cloudColors;
    public List<Color> CloudColors
    {
        get
        {
            return this.cloudColors;
        }
    }
}
