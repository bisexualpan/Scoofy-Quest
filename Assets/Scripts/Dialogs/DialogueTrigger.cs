using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
	public Dialogue[] dialogues;
	public static int DialogueCounter = 1;
    public void TriggerDialogue()
    {
		if (DialogueCounter <= dialogues.Length)
		{
			FindObjectOfType<DialogueManager>().StartDialogue(dialogues[DialogueCounter - 1]);
		}
		else
		{
			FindObjectOfType<DialogueManager>().StartDialogue(dialogues[dialogues.Length - 1]);
		}
	}
}
