using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperAnimator : MonoBehaviour
{
	public Animator startHelperAnim;
	public HelperManager hm;

	public void OnTriggerEnter2D(Collider2D other)
	{
		startHelperAnim.SetBool("startHelperOpen", true);
	}

	public void OnTriggerExit2D(Collider2D other)
	{
		startHelperAnim.SetBool("startHelperOpen", false);
		hm.EndHelping();
	}
}
