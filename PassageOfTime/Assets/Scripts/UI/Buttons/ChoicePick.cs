using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChoicePick : MonoBehaviour
{
    public int choiceIndex;
    Button button;
    DialogueManager dialogueManager;
    void Start()
    {
        button = GetComponent<Button>();
        dialogueManager = DialogueManager.instance;
        button.onClick.AddListener(() => dialogueManager.PickChoice(choiceIndex));
    }
}
