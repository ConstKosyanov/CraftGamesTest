using UnityEngine;

public class Spawner : MonoBehaviour
{
	private bool active = true;
	private Platform lastPlatform;

	public Platform platformPrefab;
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
		if (active)
		{
			for (var i = gameObject.transform.childCount; i < 90 / difficulty; i++)
				SpawnPlatform(GetRandomPosition());
		}
		else
		{
			transform.Translate(Vector3.up * 10 * Time.deltaTime);
		}

	}

	public void Destory()
	{
		active = false;
		Destroy(gameObject, 1);
	}

	private Vector3 GetRandomPosition() => lastPlatform.transform.position + GetRandomDirection();

	private Vector3 GetRandomDirection() => Random.value <= .5f
		? Vector3.right * difficulty
		: Vector3.forward * difficulty;
}
