using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class FinalSceneDialogue : MonoBehaviour
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
    AudioSource typingSource;

    [SerializeField]
    AudioSource VFXSource;

    private Queue<DialogueInfo> _lines;

    private bool _completeCurrentSentence = false;
    private bool _isTyping = false;

    private AudioClip typingCurrent;
    private AudioClip VFXcurrent;

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
        foreach (DialogueInfo dialogueInfo in dialogueSO.dialogueLines)
        {
            _lines.Enqueue(dialogueInfo);
        }

        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        DialogueInfo currentLine = _lines.Dequeue();
        nameText.text = currentLine.charaName;
        charaSprite.GetComponent<Image>().sprite = currentLine.sprite;
        typingCurrent = currentLine.typing;
        VFXcurrent = currentLine.audienceFeedback;

        if (_isTyping == true)
        {
            _completeCurrentSentence = true;
            _isTyping = false;
            return;
        }
        else
        {
            PlayVFX(VFXcurrent);
        }
        if (_lines.Count == 0)
        {
            SceneManager.LoadScene(_nextScene);
            return;
        }


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
    }
    public void PlayVFX(AudioClip clip)
    {
        VFXSource.clip = VFXcurrent;
        VFXSource.PlayOneShot(clip);
    }
}
