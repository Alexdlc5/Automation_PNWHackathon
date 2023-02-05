using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Backround_Color : MonoBehaviour
{
    public float color_multiplier = 1.2f;
    public RawImage backround;
    public RawImage[] rawImage;
    public Slider[] sliders;
    public bool[] going_right = new bool[] {true, true, true};
    public Toggle party_toggle;
    public Color current_party_color = Color.white;
    // Update is called once per frame
    void Update()
    {
        if (party_toggle.isOn)
        {
            Color color = current_party_color;
            float random = Random.Range(0,1f);
            if (going_right[0])
            {
                if (sliders[0].value + random * Time.deltaTime > 1)
                {
                    sliders[0].value = 1;
                    going_right[0] = false;
                }
                else
                {
                    sliders[0].value += random * Time.deltaTime;
                }
            }
            else
            {
                if (sliders[0].value - random * Time.deltaTime < 0)
                {
                    sliders[0].value = 0;
                    going_right[0] = true;
                }
                else
                {
                    sliders[0].value -= random * Time.deltaTime;
                }
            }
            if (going_right[1])
            {
                random = Random.Range(0, 1f);
                if (sliders[1].value + random * Time.deltaTime > 1)
                {
                    sliders[1].value = 1;
                    going_right[1] = false;
                }
                else
                {
                    sliders[1].value += random * Time.deltaTime;
                }
            }
            else
            {
                if (sliders[1].value - random * Time.deltaTime < 0)
                {
                    sliders[1].value = 0;
                    going_right[1] = true;
                }
                else
                {
                    sliders[1].value -= random * Time.deltaTime;
                }
            }
            if (going_right[2])
            {
                random = Random.Range(0, 1f);
                if (sliders[2].value + random * Time.deltaTime > 1)
                {
                    sliders[2].value = 1;
                    going_right[2] = false;
                }
                else
                {
                    sliders[2].value += random * Time.deltaTime;
                }
            }
            else
            {
                if (sliders[2].value - random * Time.deltaTime < 0)
                {
                    sliders[2].value = 0;
                    going_right[2] = true;
                }
                else
                {
                    sliders[2].value -= random * Time.deltaTime;
                }
            }
        }
        backround.color = new Color(sliders[0].value, sliders[1].value, sliders[2].value);    
    }
}
