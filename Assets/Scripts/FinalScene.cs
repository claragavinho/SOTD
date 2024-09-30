using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class FinalScene : MonoBehaviour
{
    [SerializeField]
    GameObject _goodEnding;

    [SerializeField]
    GameObject _neutralEnding;

    [SerializeField]
    GameObject _badEnding;

    [SerializeField]
    GameObject _goodButton;

    [SerializeField]
    GameObject _badButton;

    [SerializeField]
    GameObject _trueButton;

    private DiscomfortHandler _discomfortmeter;

    private void Awake()
    {
        _goodEnding.SetActive(false);
        _neutralEnding.SetActive(false);
        _badEnding.SetActive(false);

        _goodButton.SetActive(false);
        _badButton.SetActive(false);
        _trueButton.SetActive(false);
    }
    // Start is called before the first frame update
    void Start()
    {
        _discomfortmeter = FindObjectOfType<DiscomfortHandler>();
        ChangeEndings();
    }

    public void ChangeEndings()
    {
        if (_discomfortmeter.discomfortLevels <=2)
        {
            _goodEnding.SetActive(true);
            _goodButton.SetActive(true);
        }
        else if (_discomfortmeter.discomfortLevels >= 4)
        {
            _badEnding.SetActive(true);
            _badButton.SetActive(true);
        }
        else 
        { 
            _neutralEnding.SetActive(true);
            _trueButton.SetActive(true);
        }
    }
}
