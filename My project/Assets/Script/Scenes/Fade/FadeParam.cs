using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeParam
{

	public enum FadeType
	{
		AlphaFade,

		Defalt = AlphaFade,
	}

	public FadeType type = FadeType.Defalt;
	public Color color = Color.white;
	public float fadeTime = 0.5f;

	public FadeParam( FadeType type, Color color, float fadeTime )
	{
		this.type = type;
		this.color = color;
		this.fadeTime = fadeTime;
	}

}
