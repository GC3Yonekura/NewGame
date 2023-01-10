using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeControll : SingletonBase< FadeControll >
{
	public static readonly FadeParam FadeWhite = new FadeParam( FadeParam.FadeType.AlphaFade, Color.white, 0.4f );


	enum FadeBaseType
	{
		AlphaFade,

		Max,
	}

	private FadeBase[] fadeControll = null; 
	private FadeParam fadeParam = null;

	private FadeBase currentFade = null;

	/// <summary>
	/// èâä˙âª
	/// </summary>
	public override void Initialize()
	{
		base.Initialize();

		fadeControll = new FadeBase[(int)FadeBaseType.Max];
		var obj = (GameObject)Resources.Load("Prefabs/Image");
		fadeControll[(int)FadeBaseType.AlphaFade] = obj.GetComponent<AlphaFadeControll>();

		int contentMax = fadeControll.Length;
		for ( int i = 0; i < contentMax; i++ )
		{
			fadeControll[ i ].Initialize();
		}
	}

	/// <summary>
	/// èIóπèàóù
	/// </summary>
	public override void Release()
	{
		int contentMax = fadeControll.Length;
		for ( int i = 0; i < contentMax; i++ )
		{
			fadeControll[ i ].Release();
		}
	}

	public bool IsPlaying()
	{
		return currentFade.IsPlaying();
	}

	public void PlayIn( FadeParam fadeParam_ )
	{
		SetupFade( fadeParam_ );
		currentFade.PlayIn( fadeParam_.color, fadeParam_.fadeTime );
	}
	public void PlayOut( FadeParam fadeParam_ )
	{
		SetupFade( fadeParam_ );
		currentFade.PlayOut( fadeParam_.color, fadeParam_.fadeTime );
	}

	private void SetupFade( FadeParam fadeParam_ )
	{
		fadeParam = fadeParam_;

		switch ( fadeParam.type )
		{
		case FadeParam.FadeType.AlphaFade: currentFade = fadeControll[ (int)FadeBaseType.AlphaFade ]; break;
		
		default:
			currentFade = fadeControll[ (int)FadeBaseType.AlphaFade ];
			break;
		}
	}

}
