using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calendar_Month
{
    string Name;
    Calendar_Day[] Days;
    public Calendar_Month(string name, int days)
    {
        Name = name;
        Days = new Calendar_Day[days];
    }

    public int GetNumberOfDays()
    {
        return Days.Length;
    }
}
