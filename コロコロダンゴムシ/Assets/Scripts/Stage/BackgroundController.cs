using UnityEngine;
using System.Collections;

public class BackgroundController : MonoBehaviour
{
	void Update()
	{
		transform.Translate(-0.01f, 0, 0);
		if (transform.position.x < -19.19897f)
		{
			transform.position = new Vector3(19.19897f, 0, 1);
		}
	}
}