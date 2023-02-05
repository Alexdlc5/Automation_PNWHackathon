using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calendar_Event
{
    public string Name;
    public string Description;
    public string Location;
    public Calendar_Date Date;

    public Calendar_Event(string name, string decription, string location, Calendar_Date date)
    {
        Name = name;
        Description = decription;
        Location = location;
        Date = date;
    }
}
