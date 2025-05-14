using System.Collections;
using System.Collections.Generic;
using Ink.Runtime;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public TextAsset inkAsset;
    Story activeStory;
    string currentSpeaker;
    CameraManager cameraManager;
    enum DialogueState
    {
        OUT, // Not in a dialogue at all
        CHOICE, // Have option(s)
        NORMAL // Text only, can only continue
    }
    DialogueState state;
    

    void SetSingletons()
    {
        cameraManager = CameraManager.instance;
    }
    void RegisterVariableChange()
    {
        activeStory.ObserveVariable("camera", (string varName, object value) =>
        {
            cameraManager.ChangeCamera((string)value);
        });
    }
    void Start()
    {
        SetSingletons();
        RegisterVariableChange();
        BeginDialogue(inkAsset);
    }
    void DisplayChoice()
    {
        if (activeStory.currentChoices.Count > 0)
        {
            state = DialogueState.CHOICE;
            for (int i = 0; i < activeStory.currentChoices.Count; ++i)
            {
                Choice choice = activeStory.currentChoices[i];
                Debug.Log("Choice " + (i + 1) + ". " + choice.text);
            }
        }
    }
    void DisplayContent()
    {
        state = DialogueState.NORMAL;
        Debug.Log("[" + currentSpeaker + "] " + activeStory.currentText);
    }
    void LogTags(List<string> tags)
    {
        foreach (string tag in tags)
        {
            Debug.Log("[tag] " + tag);
        }
    }
    public void ContinueStory()
    {
        if (activeStory.canContinue)
        {
            activeStory.Continue();

            List<string> tags = activeStory.currentTags;
            currentSpeaker = tags[0];
            DisplayContent();
            DisplayChoice();
        }
        else if (state != DialogueState.OUT && state != DialogueState.CHOICE)
        {
            EndDialogue();
        }
    }
    void BeginDialogue(TextAsset inkAsset)
    {
        inkAsset = this.inkAsset;
        activeStory = new Story(inkAsset.text);
        // Enable UI and shit
        ContinueStory();
    }
    void EndDialogue()
    {
        state = DialogueState.OUT;
        // Disable UI and shit 
        Debug.Log("dialogue ended");
    }
    public void PickChoice(int index)
    {
        activeStory.ChooseChoiceIndex(index);
        ContinueStory();
    }
    #region Singleton
    public static DialogueManager instance;
    void Awake()
    {
        activeStory = new Story(inkAsset.text);
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != this)
        {
            Destroy(this);
        }
    }
    #endregion
}
