using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    
    [SerializeField] private int priority = 0;
    [SerializeField] private string name = "";
    [SerializeField] private float time = 0;
    [SerializeField] private string description = "";
    [SerializeField] private int timeLeft = 0;
    // Start is called before the first frame update
    public Task(int priority, string name, float time, string description, int timeLeft)
    {
        this.priority = priority;
        this.name = name;
        this.time = time;
        this.description = description;
        this.timeLeft = timeLeft;
    }

    public void setPriority(int priority)
    {
        this.priority = priority;
    }

    public void setName(string name)
    {
        this.name = name;
    }

    public void setTime(float time)
    {
        this.time = time;
    }

    public void setDescription(string description)
    {
        this.description = description;
    }

    public void setTimeLeft(int timeLeft)
    {
        this.timeLeft = timeLeft;
    }

    public int getPriority()
    {
        return priority;
    }

    public string getName()
    {
        return name;
    }

    public float getTime()
    {
        return time;
    }

    public string getDescription()
    {
        return description;
    }

    public int getTimeLeft()
    {
        return timeLeft;
    }
}

