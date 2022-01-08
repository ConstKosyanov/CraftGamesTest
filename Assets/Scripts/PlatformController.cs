using UnityEngine;

public class PlatformController : MonoBehaviour
{
	public GameObject platformTop;

	private void Start()
	{

	}

	// Update is called once per frame
	private void Update()
	{

	}

	internal void SetSize(int scale)
	{
		platformTop.GetComponent<Renderer>().material.mainTextureScale = Vector2.one * scale;
		platformTop.transform.localScale = platformTop.transform.localScale * scale;
	}

	public Vector3 Position => transform.position;
}
