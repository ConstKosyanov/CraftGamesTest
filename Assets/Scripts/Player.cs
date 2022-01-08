using System;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
	public UnityEvent onFalling = new UnityEvent();

	private void Update()
	{
		if (transform.position.y < .1f)
		{
			onFalling.Invoke();
			Destroy(gameObject, 5);
			enabled = false;
		}
	}
}
