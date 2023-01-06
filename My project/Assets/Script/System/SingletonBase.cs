using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonBase< T > : MonoBehaviour where T : MonoBehaviour
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
				GameObject = new GameObject(nameof(T), typeof(T));
				instance = GameObject.GetComponent<T>();
				
				// 破壊不能に
				DontDestroyOnLoad(instance);
			}
			return instance;
		}
	}


}
