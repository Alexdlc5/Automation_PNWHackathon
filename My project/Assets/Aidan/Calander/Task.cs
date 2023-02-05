using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Task : MonoBehaviour
{
    
    [SerializeField] private int priority = 0;
    [SerializeField] private string taskName = "";
    [SerializeField] private float time = 0;
    [SerializeField] private string description = "";
    [SerializeField] private int timeLeft = 0;
    // Start is called before the first frame update
    public Task(int priority, string taskName, float time, string description, int timeLeft)
    {
        this.priority = priority;
        this.taskName = taskName;
        this.time = time;
        this.description = description;
        this.timeLeft = timeLeft;
    }

    public void setPriority(int priority)
    {
        this.priority = priority;
    }

    public void settaskName(string taskName)
    {
        this.taskName = taskName;
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

    public string gettaskName()
    {
        return taskName;
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

