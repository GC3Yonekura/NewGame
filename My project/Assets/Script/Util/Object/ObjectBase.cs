using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBase : MonoBehaviour
{
	// 初めの一回は取得するようにする
	private GameObject myGameObject = null;
	private Transform myTransform = null;
	public new GameObject gameObject
	{
		get {
			if ( gameObject == null )
			{
				myGameObject = base.gameObject;
			}
			return myGameObject;
		}
	}
	public new Transform transform
	{
		get {
			if ( myTransform == null )
			{
				myTransform = base.transform;
			}
			return myTransform;
		}
	}

	// アクティブ
	public bool IsActive
	{
		get {
			return myGameObject == null ? false : gameObject.activeSelf;
		}
		set {
			if ( myGameObject != null )
			{
				return;
			}
			myGameObject.SetActive( value );
		}
	}

	public Vector3 Position
	{
		get 
		{
			return transform.position;
		}
		set 
		{
			transform.position = value;
		}
	}

	/// <summary>
	/// 初期化
	/// </summary>
	public virtual void Initialize()
	{
	}

	/// <summary>
	///  アップデート
	/// </summary>
	public virtual void UpdateSub()
	{
	}

	/// <summary>
	/// 終了処理
	/// </summary>
	public virtual void Release()
	{
		myGameObject = null;
	}
}
