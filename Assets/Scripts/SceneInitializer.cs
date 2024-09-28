using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class SceneInitializer : MonoBehaviour
{
    [SerializeField]
    Slider _discomfortmeter;

    DiscomfortHandler _discomfortHandler;

    // Start is called before the first frame update
    void Start()
    {
        _discomfortHandler = FindObjectOfType<DiscomfortHandler>();
        if (CanvasDiscomfort.Instance != null)
        {
            _discomfortmeter.value = _discomfortHandler.discomfortLevels;
        }
    }
}
