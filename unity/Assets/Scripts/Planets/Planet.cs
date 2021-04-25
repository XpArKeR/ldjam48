using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Planet
{


    public string Type { get; set; }

    public bool Scanned { get; set; }


    public PlanetResources Resources { get; set; }


    public Color BaseColor { get; set; }
    public Color LandColor { get; set; }
    public Color CloudColor { get; set; }

    public Sprite LandSprite { get; set; }
    public Sprite CloudSprite { get; set; }


}
