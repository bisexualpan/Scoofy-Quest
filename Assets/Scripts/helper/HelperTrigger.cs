using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperTrigger : MonoBehaviour
{
	public Helper[] helpers;
	public static int HelperCounter = 1;
	public void TriggerHelper()
	{
		if (HelperCounter <= helpers.Length)
			FindObjectOfType<HelperManager>().StartHelping(helpers[HelperCounter - 1]);
		else
			FindObjectOfType<HelperManager>().StartHelping(helpers[^1]);
	}
}
