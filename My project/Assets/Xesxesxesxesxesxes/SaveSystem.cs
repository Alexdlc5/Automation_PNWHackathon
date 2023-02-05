using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public class SaveSystem 
{
    static readonly string path = Application.persistentDataPath + "/bingus.save";

    public static void Save(List<Calendar_Event> Events, float[] color)
    {
        BinaryFormatter formatter = new BinaryFormatter();

        FileStream stream = new FileStream(path, FileMode.Create);

        SaveData data = new SaveData(Events, color);

        formatter.Serialize(stream, data);
        stream.Close();

    }
}
