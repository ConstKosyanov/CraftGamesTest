using UnityEngine;

public class Platform : MonoBehaviour
{
	public GameObject platformTop;
	public float speed;

	private void Update()
	{
		transform.Translate(Director.PlatformsDirection * speed * Time.deltaTime);

		if (transform.localPosition.z < -5 || transform.localPosition.y > 15)
			Destroy(gameObject);
	}

	internal void SetSize(int scale)
	{
		var material = platformTop.GetComponent<Renderer>().material;
		material.mainTextureScale = Vector2.one * scale;
		if (scale % 2 == 1)
			material.mainTextureOffset = new Vector2(.5f, 0);
		platformTop.transform.localScale = platformTop.transform.localScale * scale;
	}

	public Vector3 Position => transform.position;
}
