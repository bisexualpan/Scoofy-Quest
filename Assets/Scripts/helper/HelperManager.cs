using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HelperManager : MonoBehaviour
{
	public TMP_Text helperText;

	public Animator boxHelpAnim;
	public Animator startHelpAnim;

	private Queue<string> sentences;

	private void Start()
	{
		sentences = new Queue<string>();
	}

	public void StartHelping(Helper help)
	{
		boxHelpAnim.SetBool("boxHelperOpen", true);
		//startHelpAnim.SetBool("startHelperOpen", false);

		sentences.Clear();

		foreach (var sentence in help.sentences)
		{
			sentences.Enqueue(sentence);
		}
		DisplayNextHelpSentence();
	}

	public void DisplayNextHelpSentence()
	{
		if (sentences.Count == 0)
		{
			EndHelping();
			return;
		}
		string sentence = sentences.Dequeue();
		StopAllCoroutines();
		StartCoroutine(TypeSentence(sentence));
	}

	IEnumerator TypeSentence(string sentence)
	{
		helperText.text = "";
		foreach (char letter in sentence.ToCharArray())
		{
			helperText.text += letter;
			yield return null;
		}
	}

	public void EndHelping()
	{
		boxHelpAnim.SetBool("boxHelperOpen", false);
		DialogueTrigger.DialogueCounter += 1;
	}
}
