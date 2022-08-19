using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Ink.Runtime;
using UnityEngine.XR.ARFoundation;
using UnityEngine.EventSystems;
using Ink.UnityIntegration;

public class DialogueManager : MonoBehaviour
{
    [Header("Dialogue UI")]
    [SerializeField] private GameObject dialoguePanel;
    [SerializeField] private TextMeshProUGUI dialogueText;

    [Header("Choices UI")]
    [SerializeField] private GameObject[] choices;
    private TextMeshProUGUI[] choicesText;

    [Header("Globals Ink File")]
    [SerializeField] private InkFile globalsInkFile;

    private Story currentStory;

    public bool dialogueIsPlaying { get; private set; }

    //private bool dialogueIsPlaying;

    private static DialogueManager instance;

    private DialogueVariables dialogeVariables;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("wtf why are there more than 1 dialogue managers in this singleton class. that shit dont make sense");
        }
        instance = this;
        dialogeVariables = new DialogueVariables(globalsInkFile.filePath);
    }

    public static DialogueManager GetInstance()
    {
        return instance;
    }
    // Start is called before the first frame update
    public void Start()
    {
        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);

        choicesText = new TextMeshProUGUI[choices.Length];
        int index = 0;
        foreach (GameObject choice in choices)
        {
            choicesText[index] = choice.GetComponentInChildren<TextMeshProUGUI>();
            index++;
        }

        //if (currentStory.canContinue)
        //{
        //    dialogueText.text = currentStory.Continue();
        //}
        //else
        //    ExitDialogueMode();
    }

    public void EnterDialogue(TextAsset inkJSON)
    {
        currentStory = new Story(inkJSON.text);
        dialogueIsPlaying = true;
        dialoguePanel.SetActive(true);

        dialogeVariables.StartListening(currentStory);
        //if (currentStory.canContinue)
        //{
        //    dialogueText.text = currentStory.Continue();
        //}
        //else
        //{
        //    ExitDialogueMode();
        //}
        ContinueStory();
    }

    private void ContinueStory()
    {
        //if (currentStory.canContinue)
        //{
        //    Debug.Log("check check here");
        //    dialogueText.text = currentStory.Continue();
        //    //DisplayChoices();
        //    string curr = dialogueText.text;
        //}
        //if(!currentStory.canContinue)
        //{
        //    Debug.Log("this calling ?");
        //    StartCoroutine(ExitDialogueMode());
        //}
        if (currentStory.canContinue)
        {
            string temp = currentStory.Continue();
            dialogueText.text = temp;
            DisplayChoices();
        }
        else
        {
            StartCoroutine(ExitDialogueMode());
        }
    }

    private void DisplayChoices()
    {
        List<Choice> currentChoices = currentStory.currentChoices;

        // defensive check to make sure our UI can support the number of choices coming in
        if (currentChoices.Count > choices.Length)
        {
            Debug.LogError("More choices were given than the UI can support. Number of choices given: "
                + currentChoices.Count);
        }

        int index = 0;
        // enable and initialize the choices up to the amount of choices for this line of dialogue
        foreach (Choice choice in currentChoices)
        {
            choices[index].gameObject.SetActive(true);
            choicesText[index].text = choice.text;
            index++;
        }
        // go through the remaining choices the UI supports and make sure they're hidden
        for (int i = index; i < choices.Length; i++)
        {
            choices[i].gameObject.SetActive(false);
        }

        StartCoroutine(SelectFirstChoice());
    }

    private IEnumerator SelectFirstChoice()
    {
        // Event System requires we clear it first, then wait
        // for at least one frame before we set the current selected object.
        EventSystem.current.SetSelectedGameObject(null);
        yield return new WaitForEndOfFrame();
        EventSystem.current.SetSelectedGameObject(choices[0].gameObject);
    }



    private IEnumerator ExitDialogueMode()
    {
        yield return new WaitForSeconds(0.2f);

        dialogeVariables.StopListening(currentStory);

        dialogueIsPlaying = false;
        dialoguePanel.SetActive(false);
        dialogueText.text = "";

    }

    //// Update is called once per frame
    private void Update()
    {

        if (dialogueIsPlaying == false)
        {
            return;
        }
        if (currentStory.currentChoices.Count == 0 && Input.GetKeyDown(KeyCode.E))
        {
            ContinueStory();
        }

    }
    public void MakeChoice(int choiceIndex)
    {
        currentStory.ChooseChoiceIndex(choiceIndex);
        // NOTE: The below two lines were added to fix a bug after the Youtube video was made
        // this is specific to my InputManager script

        ContinueStory();
    }

    public Ink.Runtime.Object GetVariableState(string variableName)
    {
        Ink.Runtime.Object variableValue = null;
        dialogeVariables.variables.TryGetValue(variableName, out variableValue);
        if (variableValue == null)
        {
            Debug.LogWarning("This variable not real" + variableName);
        }
        return variableValue; 
    }
}
