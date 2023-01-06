using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingletonBase< T > : MonoBehaviour where T : MonoBehaviour
{
	// インスタンス
	static private T instance;
	static public GameObject GameObject;

	public static T Instance
	{
		get
		{
			if( instance == null )
			{
				// 生成して
				GameObject = new GameObject(typeof(T).Name, typeof(T));
				instance = GameObject.GetComponent<T>();

				instance.transform.SetParent( SystemMain.instance.transform );

				// 破壊不能に
				DontDestroyOnLoad(instance);
			}
			return instance;
		}
	}

	/// <summary>
	/// 初期化
	/// </summary>
	virtual public void Initialize()
	{
	}

	/// <summary>
	/// アップデート
	/// </summary>
	virtual public void UpdateSub()
	{
	}

	/// <summary>
	/// Release
	/// </summary>
	virtual public void Release()
	{
	}

}
