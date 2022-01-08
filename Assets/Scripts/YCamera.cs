using UnityEngine;

public class YCamera : MonoBehaviour
{
	public CameraMode mode;
	public float inMenuRotationSpeed;

	private void Update()
	{
		switch (mode)
		{
			case CameraMode.Menu: Rotation(); break;
			case CameraMode.Game: IngameUpdate(); break;
		}
	}

	private void Rotation() => transform.Rotate(Vector3.up * inMenuRotationSpeed * Time.deltaTime);

	private void IngameUpdate() => transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.Euler(Director.CameraDirection), 3f * Time.deltaTime);
}