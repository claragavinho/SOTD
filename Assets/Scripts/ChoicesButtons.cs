using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ChoicesButtons : MonoBehaviour
{
    [SerializeField]
    Dialogue _choiceSO;

    public UnityEvent StartChoiceDialogue;

    public void StartFromChoice(List<DialogueInfo> _choiceSO)
    {
        StartChoiceDialogue?.Invoke(); // Invokes the event to start dialogue when selecting a button
    }
}
