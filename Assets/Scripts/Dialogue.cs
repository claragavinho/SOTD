using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Dialogue")]

public class Dialogue : ScriptableObject
{
    public List<DialogueInfo> dialogueLines = new List<DialogueInfo>();
    //public string [] nextSceneName;
    public bool canChoose;
    //public UnityEngine.SceneManagement.Scene[] nextScenes; 
}
[System.Serializable]
public class DialogueInfo
{
    public Sprite sprite;
    public string charaName;

    public AudioClip typing;
    public AudioClip audienceFeedback;

    [TextArea(3, 10)]
    public string sentence;
}