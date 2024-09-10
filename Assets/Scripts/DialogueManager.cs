using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;
using Unity.VisualScripting;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    TMP_Text nameText;

    [SerializeField]
    TMP_Text dialogueText;

    [SerializeField]
    Sprite charaSprite;

    [SerializeField]
    Dialogue dialogueSO;

    [SerializeField]
    private float _dialogueLoad;

    public UnityEvent OnDialogueEnd;

    private Queue<DialogueInfo> _lines;

    private bool _completeCurrentSentence = false;
    private bool _isTyping = false;

    private void Awake()
    {
        _lines = new Queue<DialogueInfo>();
    }
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(WaitForLoad());
    }
    private IEnumerator WaitForLoad()
    {
        dialogueText.text = ""; 
        nameText.text = ""; // clears speaker name

        yield return new WaitForSeconds(_dialogueLoad); // wait time for readability or dramatic effect

        StartDialogue(dialogueSO.dialogueLines);
    }
    public void StartDialogue(List<DialogueInfo> aboutDialogue)
    {
        _lines.Clear();

        //dialogue contains a list of dialogue, then you are essentially iterating over that list
        foreach(DialogueInfo dialogueInfo in dialogueSO.dialogueLines)
        {
            _lines.Enqueue(dialogueInfo);
        }

        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if (_isTyping == true) 
        {
            _completeCurrentSentence = true;
            _isTyping=false;
            return;
        }
        if (_lines.Count == 0) 
        { 
            EndDialogue();
            return;
        }

        DialogueInfo currentLine = _lines.Dequeue();
        nameText.text = currentLine.charaName;

        StopAllCoroutines();

        //StartCoroutine(TypeSentence(currentLine));
    }
    //private IEnumerator TypeSentence(DialogueInfo dialogueInfo)

    public void EndDialogue()
    {
        OnDialogueEnd.Invoke();
    }
}


