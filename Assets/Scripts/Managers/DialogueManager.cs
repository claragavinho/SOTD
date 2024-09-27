using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.SceneManagement;
using System;

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
    Button _nextButton;

    [SerializeField]
    private Canvas _choiceCanvas;

    [SerializeField]
    Dialogue[] _choicesSO;

    [SerializeField] 
    AudioSource typingSource;

    [SerializeField]
    AudioSource VFXSource;

    private Queue<DialogueInfo> _lines;

    private bool _completeCurrentSentence = false;
    private bool _isTyping = false;
    private bool _canSwitchScenes = false;

    private AudioClip typingCurrent;
    private AudioClip VFXcurrent;

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
    public void StartChoice(int choiceRef)
    {
        _nextButton.enabled = true;
        _choiceCanvas.enabled = false;
        _lines.Clear();
        foreach (DialogueInfo dialogueInfo in _choicesSO[choiceRef].dialogueLines)
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
        else 
        { 
            PlayVFX();
        }
        if (_lines.Count == 0 && _canSwitchScenes == false) 
        {
            _choiceCanvas.enabled = true;
            _canSwitchScenes = true;
            _nextButton.enabled = false;
            //EndDialogue();
            return;
        }
        else if (_lines.Count == 0 && _canSwitchScenes)
        {
            SceneManager.LoadScene(_nextScene);
            _choiceCanvas.enabled = false;
            return;
        }

        DialogueInfo currentLine = _lines.Dequeue();
        nameText.text = currentLine.charaName;
        charaSprite.GetComponent<Image>().sprite = currentLine.sprite;
        typingCurrent = currentLine.typing;
        VFXcurrent = currentLine.audienceFeedback;
        

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
        //PlayTyping(typingCurrent);

        while (dialogueText.maxVisibleCharacters < sentenceCharLength) 
        {
            PlayTyping(typingCurrent);

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
    public void PlayTyping(AudioClip clip)
    {
        typingSource.clip = clip;
        typingSource.Play();

        //typingSource.loop = true;
        //typingSource.PlayOneShot(typingCurrent);
    }

    public void PlayVFX()
    {
        //VFXSource.clip = VFXcurrent;
        //VFXSource.PlayOneShot(VFXcurrent);
    }

}


