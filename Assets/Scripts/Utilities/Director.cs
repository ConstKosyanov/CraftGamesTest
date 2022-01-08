using System;
using UnityEngine;

public static class Director
{
	private static bool isActive = false;
	private static bool isForward = true;
	private static float speed = 1;

	public static Vector3 CameraDirection { get; private set; } = Vector3.zero;
	public static Vector3 PlatformsDirection { get; private set; } = Vector3.zero;

	private static void SetState(bool newValue)
	{
		isActive = true;
		isForward = newValue;
		CameraDirection = isForward
			? Vector3.zero
			: Vector3.up * 90;

		PlatformsDirection = isForward
			? Vector3.back * speed
			: Vector3.left * speed;
	}

	public static void Switch() => SetState(isActive != isForward);

	internal static void Pause()
	{
		isActive = false;
		PlatformsDirection = Vector3.zero;
	}

	internal static void Stop()
	{
		isActive = false;
		isForward = true;
		CameraDirection = Vector3.zero;
		PlatformsDirection = Vector3.zero;
	}

	public static void SetSpeed(float s) => speed = s;
}