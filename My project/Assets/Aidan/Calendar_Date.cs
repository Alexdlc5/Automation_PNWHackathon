using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calendar_Date
{
    public int Year;
    public int Month;
    public int Day;
    public Calendar_Date(int day, int month, int year)
    {
        Day = day;
        Month = month;
        Year = year;
    }

    public bool Equals(Calendar_Date other)
    {
        return Year == other.Year && Month == other.Month && Day == other.Day;
    }

    public override string ToString()
    {
        return Month.ToString() + "/" + Day.ToString() + "/" + Day.ToString();
    }
}
