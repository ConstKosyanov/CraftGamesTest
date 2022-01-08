using UnityEngine;

public class Bonus : MonoBehaviour
{
	private const float middle = .5f;

	private Vector3 directoin = Vector3.down;

	public float shift;
	public float pulseSpeed;
	public float breakCoefficient;
	public ParticleSystem particles;

	private void Update()
	{
		var coef = breakCoefficient - Mathf.Abs(transform.localPosition.y - middle) / shift;
		transform.Translate(directoin * pulseSpeed * coef * Time.deltaTime);

		if (transform.localPosition.y < middle - shift)
			directoin = Vector3.up;

		if (transform.localPosition.y > middle + shift)
			directoin = Vector3.down;
	}

	private void OnTriggerEnter(Collider other)
	{
		Instantiate(particles, transform.parent);
		Destroy(gameObject);
	}
}
