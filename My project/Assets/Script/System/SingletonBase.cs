using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingletonBase< T > : MonoBehaviour where T : MonoBehaviour
{
	// �C���X�^���X
	static private T instance;
	static public GameObject GameObject;

	public static T Instance
	{
		get
		{
			if( instance == null )
			{
				// ��������
				GameObject = new GameObject(nameof(T), typeof(T));
				instance = GameObject.GetComponent<T>();
				
				// �j��s�\��
				DontDestroyOnLoad(instance);
			}
			return instance;
		}
	}


}
