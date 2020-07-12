using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private SO_DialogueNode currentDialogueNode;

    [SerializeField] private GameObject textBox;

    [SerializeField] private Text textContainer;

    [SerializeField] private bool dialogueStarted;

    public SO_DialogueNode DummyDialogue;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            StartDialogue(DummyDialogue);
        }

        if (dialogueStarted)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                SO_DialogueNode temp = currentDialogueNode.GetNextNode(1);
                if (temp != null)
                {
                    currentDialogueNode = temp;
                    StartDialogue(currentDialogueNode);
                }
                else
                {
                    EndDialogue();
                }
            }
        }
    }

    public void StartDialogue(SO_DialogueNode node)
    {
        currentDialogueNode = node;
        dialogueStarted = true;
        ActivatePanel(true);
        textContainer.text = currentDialogueNode.GetText();
    }

    public void EndDialogue()
    {
        dialogueStarted = false;
        ActivatePanel(false);
    }

    public void ActivatePanel(bool state)
    {
        textBox.SetActive(state);
    }
}
