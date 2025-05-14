using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ContinueTrigger : MonoBehaviour
{
    DialogueManager dialogueManager;
    void Start()
    {
        dialogueManager = DialogueManager.instance;
    }
    public void Continue()
    {
        dialogueManager.ContinueStory();
    }
}
