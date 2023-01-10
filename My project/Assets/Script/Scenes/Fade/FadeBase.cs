using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class FadeBase : ObjectBase
{
	protected bool isPlaying = false;

	abstract public void PlayIn( Color color, float Time );
	abstract public void PlayOut( Color color, float Time );

	/// <summary>
	/// 動いている途中か
	/// </summary>
	/// <returns></returns>
	public bool IsPlaying()
	{
		return isPlaying;
	}
}
