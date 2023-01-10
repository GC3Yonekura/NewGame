using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class AlphaFadeControll : FadeBase
{
	[SerializeField] private Image fadeImage = null;
	private Tweener tweener = null;

	public override void PlayIn( Color color, float time )
	{
		FadeInternal( SetAlphaColor( color, 1.0f ), SetAlphaColor( color, 0.0f ), time );
	}

	public override void PlayOut( Color color, float time )
	{
		FadeInternal( SetAlphaColor( color, 0.0f ), color, time );
	}

	/// <summary>
	/// フェード内部制御
	/// </summary>
	private void FadeInternal( Color startColor, Color endColor, float time )
	{
		KillTweener();

		fadeImage.color = startColor;
		fadeImage.DOColor( endColor, time );
	}
	/// <summary>
	/// 移動削除
	/// </summary>
	private void KillTweener()
	{
		tweener?.Kill();
		tweener = null;
	}

	/// <summary>
	/// alphaを設定して、色を返す
	/// </summary>
	private Color SetAlphaColor( Color color, float alpha )
	{
		return new Color( color.r, color.g, color.b, alpha );
	}
}
