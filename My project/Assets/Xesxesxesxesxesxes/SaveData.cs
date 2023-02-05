using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class SaveData
{
    List<Calendar_Event> events;
    float[] color;
    public SaveData(List<Calendar_Event> Events, float[] color)
    {
        this.events = Events;
        this.color = color;
    }
}
