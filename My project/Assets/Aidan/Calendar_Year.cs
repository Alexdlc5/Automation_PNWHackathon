using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calendar_Year
{

    int Year;
    Calendar_Month[] Months = new Calendar_Month[12];


    public Calendar_Year(int year)
    {
        Year = year;
        int febDays = (year % 4 == 0 ? 29 : 28);
        Months = new Calendar_Month[12]{
            new Calendar_Month("January", 31),
            new Calendar_Month("February", febDays),
            new Calendar_Month("March", 31),
            new Calendar_Month("April", 30),
            new Calendar_Month("May", 31),
            new Calendar_Month("June", 30),
            new Calendar_Month("July", 31),
            new Calendar_Month("Augest", 31),
            new Calendar_Month("September", 30),
            new Calendar_Month("October", 31),
            new Calendar_Month("November", 30),
            new Calendar_Month("December", 31),
                };
    }

    public Calendar_Month GetMonth(int month)
    {
        return Months[month - 1];
    }

    public int GetYear()
    {
        return Year;
    }

}
