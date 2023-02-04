using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calendar_Main : MonoBehaviour
{
    public Dictionary<int, Calendar_Year> Years;
    List<Calendar_Event> Events = new List<Calendar_Event>();

    public void Start()
    {
        Years.Add(System.DateTime.Today.Year, new Calendar_Year(System.DateTime.Today.Year));
    }

    public Calendar_Year GetYear(int year)
    {
        if (Years.ContainsKey(year))
        {
            Years.TryGetValue(year, out Calendar_Year returner);
            return returner;
        }
        else
        {
            Calendar_Year newYear = new Calendar_Year(year);
            Years.Add(year, newYear);
            return newYear;
        }
    }

    public void AddEventToCalendar(Calendar_Event toAdd)
    {
        Events.Add(toAdd);
    }

    public List<Calendar_Event> GetEvents() { return Events; }
}
