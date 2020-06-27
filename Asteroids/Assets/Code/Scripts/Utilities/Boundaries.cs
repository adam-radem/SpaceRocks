using UnityEngine;

public static class Boundaries
{
	static Camera _cached;
	static Camera MainCamera
	{
		get
		{
			if(!_cached)
			{
				_cached = Camera.main;
			}
			return _cached;
		}
	}

	public static float Height => MainCamera.orthographicSize * 2f;
	public static float Width => Height * MainCamera.aspect;

	public static Vector2 Center => MainCamera.ViewportToWorldPoint(Vector2.one / 2f);
	public static Vector2 LowerLeft => MainCamera.ViewportToWorldPoint(Vector2.zero);
	public static Vector2 UpperLeft => MainCamera.ViewportToWorldPoint(Vector2.up);
	public static Vector2 UpperRight => MainCamera.ViewportToWorldPoint(Vector2.one);
	public static Vector2 LowerRight => MainCamera.ViewportToWorldPoint(Vector2.right);

	public static Rect FullScreen => new Rect(LowerLeft, new Vector2(Width, Height));

	public static Vector2 RandomInScreen()
	{
		var fullScreen = FullScreen;
		return new Vector2(
			Random.Range(fullScreen.xMin, fullScreen.xMax),
			Random.Range(fullScreen.yMin, fullScreen.yMax)
		);
	}
}
