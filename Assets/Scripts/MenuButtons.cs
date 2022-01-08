using System.Collections;
using UnityEngine;

public class MenuButtons : MonoBehaviour
{
	private Rigidbody2D rb;

	public float uturnInterval;
	public float rightImpulse;
	public float leftImpulse;

	public void Start() => rb = GetComponent<Rigidbody2D>();

	public void Hide() => StartCoroutine(HideRoutine());

	private IEnumerator HideRoutine()
	{
		rb.AddForce(Vector2.right * rightImpulse, ForceMode2D.Impulse);
		yield return new WaitForSeconds(uturnInterval);
		rb.AddForce(Vector2.left * leftImpulse, ForceMode2D.Impulse);
		yield return new WaitForSeconds(uturnInterval * 2);
		rb.velocity = Vector2.zero;
	}
}
