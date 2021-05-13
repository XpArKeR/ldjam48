using System;
using System.Collections.Generic;

using UnityEngine;

[Serializable]
public class PlanetType
{
    public String Name;

    public PlanetResources Resources;

    public List<String> LandSprites;
    public List<String> CloudSprites;

    public List<Color> BaseColors;
    public List<Color> LandColors;
    public List<Color> CloudColors;
}
