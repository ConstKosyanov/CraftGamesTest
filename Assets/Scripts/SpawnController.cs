using UnityEngine;

public class SpawnController : MonoBehaviour
{
	private PlatformController lastPlatform;

	public PlatformController platformPrefab;
	public int difficulty;

	private void SpawnPlatform(Vector3 position)
	{
		lastPlatform = Instantiate(platformPrefab, position, transform.rotation);
		lastPlatform.SetSize(difficulty);
		lastPlatform.transform.parent = transform;
	}

	public void Start()
	{
		SpawnPlatform(Vector3.forward * 1.5f + Vector3.forward * difficulty / 2);
		SpawnPlatform(lastPlatform.transform.position + Vector3.forward * difficulty);
	}

	public void Update()
	{
		for (var i = gameObject.transform.childCount; i < 90 / difficulty; i++)
			SpawnPlatform(GetRandomPosition());
	}

	private Vector3 GetRandomPosition() => lastPlatform.transform.position + GetRandomDirection();

	private Vector3 GetRandomDirection() => Random.value <= .5f
		? Vector3.right * difficulty
		: Vector3.forward * difficulty;
}
