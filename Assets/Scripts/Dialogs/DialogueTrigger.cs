using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
	public Dialogue[] dialogues;
    public void TriggerDialogue()
    {
		if (Counter.count <= dialogues.Length)
		{
			FindObjectOfType<DialogueManager>().StartDialogue(dialogues[Counter.count - 1]);
		}
		else
		{
			FindObjectOfType<DialogueManager>().StartDialogue(dialogues[^1]);
		}
	}
}
