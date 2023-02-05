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
            saveData save;
            save.Events = c.Events;
            save.color = rawImage.color;
            UtilClass.SaveToFile(Application.persistentDataPath + "", "txt", "bingus", save);
            //SaveSystem.Save(c.Events, new float[]{rawImage.color.r, rawImage.color.g, rawImage.color.b}  );
            Application.Quit();
        }
    }

    struct saveData
    {
        public List<Calendar_Event> Events;
        public Color color;

       
    }
}
