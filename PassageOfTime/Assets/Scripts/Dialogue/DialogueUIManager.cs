using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Ink.Runtime;

public class DialogueUIManager : MonoBehaviour
{
    public static DialogueUIManager instance;
    public TextMeshProUGUI speakerTMP;
    public TextMeshProUGUI messageTMP;
    public GameObject nextButton;
    public GameObject choicesParent;
    public GameObject choiceButtonPrefab;
    public enum DialogueType
    {
        SingleChoice,
        MultipleChoice
    }

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else
            Destroy(gameObject);
    }

    public void SetDialogue(DialogueType type, string speaker, string message, List<Choice> responses = null)
    {
        speakerTMP.text = speaker;
        if (message == "Narrator")
            message = "";
        messageTMP.text = message;

        ClearChoices();

        if (type == DialogueType.SingleChoice)
        {
            nextButton.SetActive(true);
            choicesParent.SetActive(false);
        }
        else if (type == DialogueType.MultipleChoice && responses != null)
        {
            nextButton.SetActive(false);
            choicesParent.SetActive(true);

            for (int i = 0; i < responses.Count; i++)

            {
                string response = responses[i].text;
                GameObject choiceObj = Instantiate(choiceButtonPrefab, choicesParent.transform);
                TextMeshProUGUI choiceText = choiceObj.GetComponentInChildren<TextMeshProUGUI>();
                choiceText.text = response;

                ChoicePick cp = choiceObj.AddComponent<ChoicePick>();
                cp.SetIndex(i);
            }
        }
    }

    private void ClearChoices()
    {
        foreach (Transform child in choicesParent.transform)
        {
            Destroy(child.gameObject);
        }
    }

}
