using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Dialogue")]

public class Dialogue : ScriptableObject
{
    public List<DialogueInfo> dialogueLines = new List<DialogueInfo>();
}
[System.Serializable]
public class DialogueInfo
{
    public Sprite sprite;
    public string charaName;

    [TextArea(3, 10)]
    public string sentence;
}