using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectBase : MonoBehaviour
{
	// 初めの一回は取得するようにする
	private GameObject myGameObject = null;
	public GameObject GameObject
	{
		get {
			if ( gameObject == null )
			{
				myGameObject = gameObject;
			}
			return myGameObject;
		}
	}

	// アクティブ
	public bool IsActive
	{
		get {
			return myGameObject == null ? false : GameObject.activeSelf;
		}
		set {
			if ( myGameObject != null )
			{
				return;
			}
			myGameObject.SetActive( value );
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

	public virtual void Release()
	{
		myGameObject = null;
	}
}
