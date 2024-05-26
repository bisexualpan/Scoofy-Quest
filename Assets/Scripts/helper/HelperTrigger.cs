using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperTrigger : MonoBehaviour
{
	public Helper[] helpers;
	public void TriggerHelper()
	{
		if (Counter.count <= helpers.Length)
			FindObjectOfType<HelperManager>().StartHelping(helpers[Counter.count - 1]);
		else
			FindObjectOfType<HelperManager>().StartHelping(helpers[^1]);
	}
}
