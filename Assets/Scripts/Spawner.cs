using UnityEngine;

public class Spawner : MonoBehaviour
{
	private bool active = true;
	private int bonusCounter;
	private Platform lastPlatform;

	public Platform platformPrefab;
	public int difficulty;
	public bool randomBonusSpawning;
	public ScoreCapturedDelegate scoreCaptured;

	private void SpawnPlatform(Vector3 position, bool allowBonusSpawning)
	{
		lastPlatform = Instantiate(platformPrefab, position, transform.rotation);
		lastPlatform.scoreCaptured = scoreCaptured;
		lastPlatform.SetSize(difficulty);
		lastPlatform.transform.parent = transform;
		if (allowBonusSpawning && CanSpawnBonus())
			lastPlatform.SpawnBonus();
	}

	private bool CanSpawnBonus() => randomBonusSpawning
		? Random.value < .2f
		: (bonusCounter = (1 + bonusCounter % 5)) > 3;

	public void Start()
	{
		SpawnPlatform(Vector3.forward * 1.5f + Vector3.forward * difficulty / 2, false);
		SpawnPlatform(lastPlatform.transform.position + Vector3.forward * difficulty, false);
	}

	public void Update()
	{
		if (active)
		{
			for (var i = gameObject.transform.childCount; i < 90 / difficulty; i++)
				SpawnPlatform(GetRandomPosition(), true);
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
