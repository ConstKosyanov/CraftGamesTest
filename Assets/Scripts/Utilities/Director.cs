using UnityEngine;

public static class Director
{
	private static bool isForward = false;
	private static float coef = 1;

	public static Vector3 CameraDirection { get; private set; } = Vector3.zero;
	public static Vector3 PlatformsDirection { get; private set; } = Vector3.zero;

	private static void SetState(bool newValue)
	{
		isForward = newValue;
		CameraDirection = isForward
			? Vector3.zero
			: Vector3.up * 90;

		PlatformsDirection = isForward
			? Vector3.back * coef
			: Vector3.left * coef;
	}

	public static void Switch() => SetState(!isForward);

	internal static void Stop()
	{
		isForward = false;
		CameraDirection = Vector3.zero;
		PlatformsDirection = Vector3.zero;
	}

	public static void SetDifficulty(int difficulty) => coef = 1 - (2 - difficulty) / 4;
}