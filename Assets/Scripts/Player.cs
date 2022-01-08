using System;
using UnityEngine;

public class Player : MonoBehaviour
{
	public event EventHandler OnFail;

	private void Update()
	{
		if (transform.position.y < .1f)
		{
			OnFail?.Invoke(this, new EventArgs());
			Destroy(gameObject, 5);
			enabled = false;
		}
	}
}
