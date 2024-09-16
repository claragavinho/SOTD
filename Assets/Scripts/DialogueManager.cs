using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;

public class DialogueManager : MonoBehaviour
{
    [SerializeField]
    TMP_Text nameText;

    [SerializeField]
    TMP_Text dialogueText;

    [SerializeField]
    Image charaSprite;

    [SerializeField]
    Dialogue dialogueSO;

    [SerializeField]
    private float _dialogueLoad = 0.1f;

    [SerializeField]
    private string _nextScene;

    [SerializeField]
    private float _typingSpeed = 0.05f;

    [SerializeField]
    private bool _canChoose;

    [SerializeField]
    private Canvas _choiceCanvas;

    [SerializeField]
    Button[] _choiceButtons;

    [SerializeField]
    Dialogue[] _choicesSO; 

    //public UnityEvent OnDialogueEnd;

    private Queue<DialogueInfo> _lines;

    private bool _completeCurrentSentence = false;
    private bool _isTyping = false;

    private void Awake()
    {
        _lines = new Queue<DialogueInfo>();
        _choiceCanvas.enabled = false;
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
    public void StartChoice1()
    {
        _choiceCanvas.enabled = false;

        _lines.Clear();

        //dialogue contains a list of dialogue, then you are essentially iterating over that list
        foreach (DialogueInfo dialogueInfo in _choicesSO[0].dialogueLines)
        {
            _lines.Enqueue(dialogueInfo);
        }

        DisplayNextSentence();
    }
    public void StartChoice2()
    {
        _choiceCanvas.enabled = false;

        _lines.Clear();

        foreach (DialogueInfo dialogueInfo in _choicesSO[1].dialogueLines)
        {
            _lines.Enqueue(dialogueInfo);
        }

        DisplayNextSentence();
    }
    public void StartChoice3()
    {
        _choiceCanvas.enabled = false;

        _lines.Clear();

        foreach (DialogueInfo dialogueInfo in _choicesSO[2].dialogueLines)
        {
            _lines.Enqueue(dialogueInfo);
        }

        DisplayNextSentence();
    } // sean please dont yell at me i promise i'll fix this later
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
            if (_canChoose == true) 
            { 
                _choiceCanvas.enabled = true;
            }
            EndDialogue();
            return;
        }

        DialogueInfo currentLine = _lines.Dequeue();
        nameText.text = currentLine.charaName;
        charaSprite.GetComponent<Image>().sprite = currentLine.sprite;

        StopAllCoroutines();

        StartCoroutine(TypeSentence(currentLine));
    }
    
    IEnumerator TypeSentence(DialogueInfo dialogueLine)
    {
        dialogueText.text = dialogueLine.sentence;
        string fullSentence = dialogueText.text;
        dialogueText.maxVisibleCharacters = 0;
        dialogueText.text = fullSentence;
        int sentenceCharLength = fullSentence.Length;
        _isTyping = true;
        _completeCurrentSentence = false;

        while (dialogueText.maxVisibleCharacters < sentenceCharLength) 
        { 
            if (_completeCurrentSentence)
            {
                dialogueText.maxVisibleCharacters = sentenceCharLength;
                break;
            }

            dialogueText.maxVisibleCharacters++; //increases visible characters one by one
            yield return new WaitForSecondsRealtime(_typingSpeed);
        }

        _isTyping = false;
        _completeCurrentSentence = false;
    }

    public void EndDialogue()
    {
        if (dialogueSO.canChoose == true)
        {
            _choiceCanvas.enabled = true;
        }
        else if (_choicesSO[_choicesSO.Length].canChoose == false)
        {
            SceneManager.LoadScene(_nextScene);
        }
        /*
        foreach ()
        if (dialogueSO.nextSceneName[] != "")
        {
            SceneManager.LoadScene(dialogueSO.nextSceneName);
        }*/
    }

}


