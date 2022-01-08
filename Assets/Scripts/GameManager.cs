using System.Collections;
using UnityEngine;

public class GameManager : MonoBehaviour
{
	private Player playerInstance;
	private Spawner spawnerInstance;

	public int difficulty;
	public Spawner spawner;
	public Player player;
	public YCamera yCamera;
	public XCamera xCamera;
	public GameObject gameOverUI;

	public void Start()
	{
		gameOverUI.SetActive(false);

		spawnerInstance = Instantiate(spawner);
		spawnerInstance.difficulty = difficulty;

		playerInstance = Instantiate(player);
		playerInstance.OnFail += (s, e) => GameOver();

		xCamera.mode = XCameraMode.Game;
		yCamera.mode = CameraMode.Game;

		Director.SetDifficulty(difficulty);
	}

	private void GameOver() => StartCoroutine(GameOverCoroutine());

	private IEnumerator GameOverCoroutine()
	{
		Director.Stop();

		playerInstance.OnFail -= (s, e) => GameOver();

		xCamera.mode = XCameraMode.PlayerFollowing;
		yCamera.mode = CameraMode.Menu;

		yield return new WaitForSeconds(.5f);

		spawnerInstance.Destory();
		
		yield return new WaitForSeconds(.5f);
		
		gameOverUI.SetActive(true);
	}

	public void Restart()
	{
		Start();
	}

	public void Update()
	{
		if (Input.GetMouseButtonDown(0))
			Director.Switch();
	}
}
