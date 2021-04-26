using System;
using System.IO;

using Assets.Scripts;

using UnityEngine;

[Serializable]
public class Planet
{
    [SerializeField]
    private String type;
    public String Type
    {
        get
        {
            return this.type;
        }
        set
        {
            if (this.type != value)
            {
                this.type = value;
            }
        }
    }

    [SerializeField]
    private Boolean scanned;
    public Boolean Scanned
    {
        get
        {
            return this.scanned;
        }
        set
        {
            if (this.scanned != value)
            {
                this.scanned = value;
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
    private Color baseColor;
    public Color BaseColor
    {
        get
        {
            return this.baseColor;
        }
        set
        {
            if (this.baseColor != value)
            {
                this.baseColor = value;
            }
        }
    }

    [SerializeField]
    public Color landColor;
    public Color LandColor
    {
        get
        {
            return this.landColor;
        }
        set
        {
            if (this.landColor != value)
            {
                this.landColor = value;
            }
        }
    }

    [SerializeField]
    private Color cloudColor;
    public Color CloudColor
    {
        get
        {
            return this.cloudColor;
        }
        set
        {
            if (this.cloudColor != value)
            {
                this.cloudColor = value;
            }
        }
    }

    [SerializeField]
    private String landSpriteName;
    private Sprite landSprite;
    public Sprite LandSprite
    {
        get
        {
            if ((this.landSprite == default) && (!String.IsNullOrEmpty(landSpriteName)))
            {
                landSprite = LoadSprint(landSpriteName);
            }

            return this.landSprite;
        }
        set
        {
            if (this.landSprite != value)
            {
                this.landSprite = value;
                this.landSpriteName = value?.name;
            }
        }
    }

    [SerializeField]
    private String cloudSpriteName;
    private Sprite cloudSprite;
    public Sprite CloudSprite
    {
        get
        {
            if ((this.cloudSprite == default) && (!String.IsNullOrEmpty(cloudSpriteName)))
            {
                cloudSprite = LoadSprint(cloudSpriteName);
            }

            return this.cloudSprite;
        }
        set
        {
            if (this.cloudSprite != value)
            {
                this.cloudSprite = value;
                this.cloudSpriteName = value?.name;
            }
        }
    }

    private Sprite LoadSprint(String spriteName)
    {
        return Core.ResourceCache.GetSprite(Path.Combine("Planets", "Sprites", spriteName));
    }
}
