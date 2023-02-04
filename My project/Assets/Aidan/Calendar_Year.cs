using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Calendar_Year
{


    Calendar_Month[] Months = new Calendar_Month[12];


    public Calendar_Year(int year)
    {
        int febDays = (year % 4 == 0 ? 29 : 28);
        Months = new Calendar_Month[12]{
            new Calendar_Month("Jan", 31),
            new Calendar_Month("Feb", febDays),
            new Calendar_Month("Mar", 31),
            new Calendar_Month("Apr", 30),
            new Calendar_Month("May", 31),
            new Calendar_Month("Jun", 30),
            new Calendar_Month("Jul", 31),
            new Calendar_Month("Aug", 31),
            new Calendar_Month("Sep", 30),
            new Calendar_Month("Oct", 31),
            new Calendar_Month("Nov", 30),
            new Calendar_Month("Dec", 31),
                };
    }

}
