using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Calendar_Main : MonoBehaviour
{
    public Dictionary<int, Calendar_Year> Years = new Dictionary<int, Calendar_Year>();
    List<Calendar_Event> Events = new List<Calendar_Event>();
    [SerializeField] GameObject DayNumber;
    [SerializeField] Vector2 DayNumberOffset = Vector2.zero;
    [SerializeField] Mouse_Manager mouse_Manager;
    [SerializeField] TMP_Text MonthText;
    [SerializeField] TMP_Text YearText;

    [SerializeField] GameObject Canvas;

    [SerializeField] GameObject EventCreationPopupPrefab;

    List<GameObject> DayNumbers = new List<GameObject>();

    private int NumberOfActiveDays;

    public int SelectedYear;
    [Range(1, 12)]
    public int SelectedMonth;

    public void Start()
    {
    }

    bool firstUpdate = true;

    int tempYear;
    int tempMonth;
    private void Update()
    {
        if (firstUpdate)
        {
            firstUpdate = false;
            SelectedYear = System.DateTime.Today.Year;
            SelectedMonth = System.DateTime.Today.Month;
            //Years.Add(System.DateTime.Today.Year, new Calendar_Year(System.DateTime.Today.Year));
            GetYear(SelectedYear);
            SetupCalendar(SelectedYear);

            tempYear = SelectedYear;
            tempMonth = SelectedMonth;
        }
        if (tempYear != SelectedYear || tempMonth != SelectedMonth)
        {
            SetupCalendar(SelectedYear);
            tempYear = SelectedYear;
            tempMonth = SelectedMonth;
        }
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

    public List<Calendar_Event> GetEventsOnDate(Calendar_Date date)
    {
        List<Calendar_Event> returner = new List<Calendar_Event>();
        foreach (Calendar_Event CE in Events)
        {
            if (CE.Date.Equals(date))
            {
                returner.Add(CE);
            }
        }
        return returner;
    }

    public bool DateHasEvents(Calendar_Date date)
    {
        foreach (Calendar_Event CE in Events)
        {
            if (CE.Date.Equals(date))
            {
                return true;
            }
        }
        return false;
    }

    public void SetupCalendar(int year)
    {
        foreach (GameObject go in DayNumbers)
        {
            Destroy(go);
        }
        DayNumbers.Clear();

        Calendar_Year SelYear = GetYear(year);
        Calendar_Month SelMonth = SelYear.GetMonth(SelectedMonth);
        MonthText.text = SelMonth.GetName();
        YearText.text = SelYear.GetYear().ToString();
        NumberOfActiveDays = SelMonth.GetNumberOfDays();

        Debug.Log("mouse_Manager.snap_points.Length:"+ mouse_Manager.snap_points.Length);
        Debug.Log("SelMonth.GetNumberOfDays():" + SelMonth.GetNumberOfDays());
        for (int i = 0; i < mouse_Manager.snap_points.Length; i++)
        {
            if (i < SelMonth.GetNumberOfDays())
            {
                mouse_Manager.snap_points[i].SetActive(true);
                GameObject temp = Instantiate(DayNumber);
                temp.transform.SetParent(Canvas.transform);
                temp.GetComponent<TMP_Text>().text = (i + 1).ToString();
                temp.transform.position = mouse_Manager.snap_points[i].transform.position;
                temp.transform.position += new Vector3(DayNumberOffset.x, DayNumberOffset.y, -5);
                DayNumbers.Add(temp);
            }
            else
            {
                mouse_Manager.snap_points[i].SetActive(false);
            }
        }
    }

    public int GetNumberOfActiveDays()
    {
        return NumberOfActiveDays;
    }

    public int GetMaxDays(int year, int month)
    {
        Calendar_Year temp = GetYear(year);
        Calendar_Month tempM = temp.GetMonth(month);
        return tempM.GetNumberOfDays();
    }

    public void IncreaseMonth()
    {
        SelectedMonth += 1;
        if (SelectedMonth > 12)
        {
            SelectedMonth = 1;
            SelectedYear++;
        }
    }

    public void DecreaseMonth()
    {
        SelectedMonth -= 1;
        if (SelectedMonth < 1)
        {
            SelectedMonth = 12;
            SelectedYear--;
        }
    }

    public void IncreaseYear()
    {
        int delta = 1;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            delta = 10;
        }
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.LeftControl))
        {
            delta = 100;
        }
        SelectedYear += delta;
    }
    public void DecreaseYear()
    {
        int delta = 1;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            delta = 10;
        }
        if (Input.GetKey(KeyCode.LeftShift) && Input.GetKey(KeyCode.LeftControl))
        {
            delta = 100;
        }
        SelectedYear -= delta;
    }
    public void AddNewEventRequest()
    {
        EventCreationPopupHandler temp = Instantiate(EventCreationPopupPrefab).GetComponent<EventCreationPopupHandler>();
        temp.returnCall += (input) => { AddEventToCalendar(input); };
    }
}
