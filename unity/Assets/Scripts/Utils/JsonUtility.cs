using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class JsonUtility
{
    private class JsonList<T>
    {
        public List<T> objects;
    }

    public static List<T> ListFromJson<T>(string path)
    {
        string json = File.ReadAllText(path);
        json = "{\"objects\":" + json + "}";
        Debug.Log(json);
        var planetTypeList = UnityEngine.JsonUtility.FromJson<JsonList<T>>(json);
        return planetTypeList.objects;
    }
}
