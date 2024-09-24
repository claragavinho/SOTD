using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public enum ChoiceReference { First, Second, Third, Fourth, Fifth}
public class ChoicesButtons : MonoBehaviour
{
    [SerializeField]
    Dialogue _choiceSO;
    [SerializeField]
    int _choiceRef;

    public UnityEvent<int> StartChoiceDialogue;

    public void StartFromChoice(List<DialogueInfo> _choiceSO)
    {
        StartChoiceDialogue?.Invoke(_choiceRef); // Invokes the event to start dialogue when selecting a button
    }
}
