using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.UI;
using TMPro;
using UnityEngine.UIElements;

public class DialogueManager : MonoBehaviour
{
    public TMP_Text dialogueText;

    public Animator boxAnim;
    public Animator startAnim;

	private Queue<string> sentences;

	private void Start()
	{
		sentences = new Queue<string>();
	}

	public void StartDialogue(Dialogue dialogue)
	{
		boxAnim.SetBool("boxOpen", true);
		//startAnim.SetBool("startOpen", false);

		sentences.Clear();

		foreach(var sentence in dialogue.sentences)
		{
			sentences.Enqueue(sentence);
		}
		DisplayNextSentence();
	}

	public void DisplayNextSentence()
	{
		if (sentences.Count == 0)
		{
			EndDialogue();
			return;
		}
		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence(string sentence)
	{
		dialogueText.text = "";
		foreach(char letter in sentence.ToCharArray())
		{
			dialogueText.text += letter;
			yield return null;
		}
	}

	public void EndDialogue()
	{
		boxAnim.SetBool("boxOpen", false);
		HelperTrigger.HelperCounter += 1;
	}
}
