using System.Collections;
using System.Collections.Generic;
using Ink;
using Ink.Runtime;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public TextAsset inkAsset;
    Story activeStory;
    string currentSpeaker;
    string currentEnvironment;
    CameraManager cameraManager;
    DialogueUIManager dialogueUI;
    SwapperManager swapperManager;
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
        dialogueUI = DialogueUIManager.instance;
        swapperManager = SwapperManager.Instance;
    }
    void Start()
    {
        SetSingletons();
        BeginDialogue(inkAsset);
        activeStory.onError += (string message, ErrorType type) =>
        {
            Debug.Log("story error : " + message + " " + type);
        };
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
            if (tags.Count >= 1)
                currentSpeaker = tags[0];
            else
                currentSpeaker = "Narrator";
            Debug.Log("speaker is " + currentSpeaker);
            if (tags.Count >= 2)
                currentEnvironment = tags[1];
            state = DialogueState.NORMAL;

            if (activeStory.currentChoices.Count > 0)
            {
                state = DialogueState.CHOICE;
            }
            // DisplayContent();
            // DisplayChoice();
            dialogueUI.SetDialogue(state == DialogueState.NORMAL ? DialogueUIManager.DialogueType.SingleChoice : DialogueUIManager.DialogueType.MultipleChoice, currentSpeaker, activeStory.currentText, activeStory.currentChoices);
            swapperManager.SwapCharacter(currentSpeaker);
            swapperManager.SwapBackground(currentEnvironment);
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
