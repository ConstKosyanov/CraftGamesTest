using UnityEngine;

public class Spawner : MonoBehaviour
{
	private bool active = true;
	private int bonusCounter;
	private int nextRandomTile = 0;
	private bool randomBonusSpawning;
	private Platform lastPlatform;

	public Platform platformPrefab;
	public int difficulty;
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

	private bool CanSpawnBonus()
	{
		if (bonusCounter > 4)
		{
			bonusCounter = 0;
			nextRandomTile = Random.Range(0, 4);
		}

		return bonusCounter++ == (randomBonusSpawning ? nextRandomTile : 0);
	}

	public void SetRandomBonusSpawning(bool value)
	{
		randomBonusSpawning = value;
		nextRandomTile = value ? Random.Range(0, 4) : 0;
	}

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
