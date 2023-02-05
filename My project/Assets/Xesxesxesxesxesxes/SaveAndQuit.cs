using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SaveAndQuit : MonoBehaviour
{
    public Calendar_Main c;
    public RawImage rawImage;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            //SaveSystem.Save(c., color);
            Application.Quit();
        }
    }
}
