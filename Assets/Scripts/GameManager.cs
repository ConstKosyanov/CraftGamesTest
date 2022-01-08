using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
	private bool gameMode = false;
	private Player playerInstance;
	private Spawner spawnerInstance;
	private readonly ScoreModel scoreModel = new ScoreModel();

	public int difficulty;
	public float speed;
	public Spawner spawner;
	public Player player;
	public YCamera yCamera;
	public XCamera xCamera;
	public GameObject gameOverUI;
	public GameObject pauseUI;
	public Score scoreUI;
	public Toggle randomModeToggle;
	public bool randomBonusSpawning = true;

	public void Start() => randomModeToggle.onValueChanged.AddListener(x => randomBonusSpawning = x);

	public void StartGame(int difficulty)
	{
		if (!gameMode)
		{
			this.difficulty = difficulty;

			gameOverUI.SetActive(false);
			scoreUI.gameObject.SetActive(true);

			spawnerInstance = Instantiate(spawner);
			spawnerInstance.difficulty = difficulty;
			spawnerInstance.SetRandomBonusSpawning(randomBonusSpawning);
			spawnerInstance.scoreCaptured = UpdateScore;

			playerInstance = Instantiate(player);
			playerInstance.onFalling.AddListener(GameOver);

			xCamera.mode = XCameraMode.Game;
			yCamera.mode = CameraMode.Game;

			Director.SetSpeed(speed);

			gameMode = true;
		}
	}

	private void UpdateScore(ScoreType type)
	{
		switch (type)
		{
			case ScoreType.Tile: scoreModel.Tiles++; break;
			case ScoreType.Cristal: scoreModel.Cristals++; break;
		}

		scoreUI.ShowScore(scoreModel);
	}

	private void GameOver() => StartCoroutine(GameOverCoroutine());

	private IEnumerator GameOverCoroutine()
	{
		gameMode = false;
		Director.Stop();

		xCamera.mode = XCameraMode.PlayerFollowing;
		yCamera.mode = CameraMode.Menu;

		yield return new WaitForSeconds(.5f);

		spawnerInstance.Destory();

		yield return new WaitForSeconds(.5f);

		gameOverUI.SetActive(true);
	}

	public void Restart() => StartGame(difficulty);

	public void Update()
	{
		if (gameMode)
		{
			if (Input.GetMouseButtonDown(0))
			{
				Director.Switch();
				pauseUI.SetActive(false);
			}

			if (Input.GetKey(KeyCode.Escape))
			{
				Director.Pause();
				pauseUI.SetActive(true);
			}
		}
	}
}
