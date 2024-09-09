using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.Events;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text nameText;
    public TMP_Text dialogueText;
    public Sprite charaSprite;

    public UnityEvent OnDialogueEnd;

    //private Queue<string> names;
    private Queue<string> sentences;
    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
    }
    public void StartDialogue(Dialogue dialogue)
    {
        nameText.text = dialogue.name;
        charaSprite = dialogue.sprite;

        //foreach (string name in dialogue.names)
        //{
        //    names.Enqueue(name);
        //}

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
        }

        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue();
        //string name = names.Dequeue();
        dialogueText.text = sentence;
    }
    public void EndDialogue()
    {
        OnDialogueEnd.Invoke();
    }
}
