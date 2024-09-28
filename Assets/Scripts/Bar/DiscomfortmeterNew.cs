using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiscomfortmeterNew : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    DiscomfortHandler handlerRef;

    public int maxComfort = 6;
    //public int currentDiscomfort;

    private void Start()
    {
        handlerRef = FindObjectOfType<DiscomfortHandler>();
        SetDiscomfort(handlerRef.discomfortLevels);
    }
    public void SetMaxDiscomfort()
    {
        slider.maxValue = maxComfort;
        slider.value = 3;
    }

    public void SetDiscomfort(int discomfort)
    {
        slider.value = discomfort;
    }
    public void MakeUncomfortable()
    {
        handlerRef.discomfortLevels++;

        SetDiscomfort(handlerRef.discomfortLevels);
    }
    public void MakeComfortable()
    {
        handlerRef.discomfortLevels--;
        SetDiscomfort(handlerRef.discomfortLevels);
    }
}
