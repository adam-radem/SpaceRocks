using UnityEngine;

public class ScreenWrap : Rigidbody2DBehavior
{
	private void FixedUpdate()
	{
		bool moved = false;
		var screenRect = Boundaries.FullScreen;

		var pos = trans.position;
		if(pos.x < screenRect.xMin)
		{
			moved = true;
			pos.x += Boundaries.Width;
		}
		else if(pos.x > screenRect.xMax)
		{
			moved = true;
			pos.x -= Boundaries.Width;
		}
		if(pos.y < screenRect.yMin)
		{
			moved = true;
			pos.y += Boundaries.Height;
		}
		else if(pos.y > screenRect.yMax)
		{
			moved = true;
			pos.y -= Boundaries.Height;
		}

		if (moved) {
			body.MovePosition(pos);
		}
	}
}