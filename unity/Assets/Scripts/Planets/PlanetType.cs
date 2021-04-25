
using System;
using System.Collections.Generic;

using UnityEngine;

[Serializable]
public class PlanetType
{
    public string Name;

    public PlanetResources Resources;

    public List<string> LandSprites;
    public List<string> CloudSprites;

    public List<Color> BaseColors;
    public List<Color> LandColors;
    public List<Color> CloudColors;
}
