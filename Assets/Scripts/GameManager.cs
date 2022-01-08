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

	public void Start()
	{
		spawnerInstance = Instantiate(spawner);
		spawner.difficulty = difficulty;
		playerInstance = Instantiate(player);
		playerInstance.OnFail += (s, e) => GameOver();
		xCamera.mode = XCameraMode.Game;
		yCamera.mode = CameraMode.Game;
		Director.SetDifficulty(difficulty);
	}

	private void GameOver() => StartCoroutine(GameOverCoroutine());

	private IEnumerator GameOverCoroutine()
	{
		playerInstance.OnFail -= (s, e) => GameOver();
		Director.Stop();
		//mode = CameraMode.Menu;
		xCamera.mode = XCameraMode.PlayerFollowing;
		yCamera.mode = CameraMode.Menu;
		yield return new WaitForSeconds(.5f);
		spawnerInstance.Destory();
		yield return new WaitForSeconds(.5f);
		//gameOverUI.SetActive(true);
	}

	public void Update()
	{
		if (Input.GetMouseButtonDown(0))
			Director.Switch();
	}
}
