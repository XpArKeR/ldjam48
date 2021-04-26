using System;

using UnityEngine;

[Serializable]
public class Planet
{
    public String Type;
    public Boolean Scanned;
    public PlanetResources Resources;
    public Color BaseColor;
    public Color LandColor;
    public Color CloudColor;

    public Sprite LandSprite;
    public Sprite CloudSprite;
}
