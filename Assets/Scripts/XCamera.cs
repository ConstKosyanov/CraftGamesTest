using UnityEngine;

public enum XCameraMode { Menu, Game, PlayerFollowing }

public class XCamera : MonoBehaviour
{
	public XCameraMode mode;

	private void Update()
	{
		switch (mode)
		{
			case XCameraMode.Menu:
				transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(0, 0, 0), 10 * Time.deltaTime);
				break;
			case XCameraMode.Game:
				transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(20, 0, 0), 10 * Time.deltaTime);
				break;
			case XCameraMode.PlayerFollowing:
				transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(90, 0, 0), 3 * Time.deltaTime);
				break;
		}
	}
}
