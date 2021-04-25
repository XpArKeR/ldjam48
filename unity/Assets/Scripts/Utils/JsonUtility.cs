using System;
using System.Collections.Generic;
using System.IO;

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
        var planetTypeList = UnityEngine.JsonUtility.FromJson<JsonList<T>>(json);
        return planetTypeList.objects;
    }

    public static T FromJson<T>(string path)
    {
        var deserialiizedObject = default(T);

        if (!String.IsNullOrEmpty(path))
        {
            var jsonString = File.ReadAllText(path);
            deserialiizedObject = UnityEngine.JsonUtility.FromJson<T>(jsonString);
        }

        return deserialiizedObject;
    }
}
