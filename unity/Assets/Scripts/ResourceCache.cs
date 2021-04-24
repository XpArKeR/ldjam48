using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResourceCache 
{
    readonly Dictionary<string, Sprite> spriteCache = new Dictionary<string, Sprite>();

    public Sprite GetSprit(string path)
    {
        if (!spriteCache.TryGetValue(path, out Sprite sprite))
        {
            sprite = Resources.Load<Sprite>(path);
            if (sprite != default)
            {
                spriteCache[path] = sprite;
            }
        }
        return sprite;
    }


}
