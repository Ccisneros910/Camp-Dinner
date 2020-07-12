using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class SO_DialogueNode : ScriptableObject
{
    [SerializeField] private SO_DialogueNode Choice1;
    [SerializeField] private SO_DialogueNode Choice2;

    [SerializeField] private string dialogueText;
    [SerializeField] private int imageToLoad;

    public string GetText()
    {
        return dialogueText;
    }

    public SO_DialogueNode GetNextNode(int choice)
    {
        if(choice == 1)
        {
            return Choice1;
        }else
        {
            return Choice2;
        }
    }

    public int GetImage()
    {
        return imageToLoad;
    }
}
