using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CanvasDiscomfort : MonoBehaviour
{
    public static CanvasDiscomfort Instance;

    public DiscomfortmeterNew discomfortmeter {  get; private set; }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this); //will keep the object on the scene when the scene loads
        }
        else
            Destroy(this);

        discomfortmeter = GetComponentInChildren<DiscomfortmeterNew>();
    }
}
