using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

public class FinalScene : MonoBehaviour
{
    [SerializeField]
    GameObject _goodEnding;

    [SerializeField]
    GameObject _neutralEnding;

    [SerializeField]
    GameObject _badEnding;

    private DiscomfortHandler _discomfortmeter;

    private void Awake()
    {
        _goodEnding.SetActive(false);
        _neutralEnding.SetActive(false);
        _badEnding.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        _discomfortmeter = FindObjectOfType<DiscomfortHandler>();
        ChangeEndings();
    }

    public void ChangeEndings()
    {
        if (_discomfortmeter.discomfortLevels == 0)
        {
            _goodEnding.SetActive(true);
        }
        else if (_discomfortmeter.discomfortLevels == 6)
        {
            _badEnding.SetActive(true);
        }
        else 
        { 
            _neutralEnding.SetActive(true);
        }
    }
}
