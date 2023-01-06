using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingletonBase< T > : MonoBehaviour where T : MonoBehaviour
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
				GameObject = new GameObject(typeof(T).Name, typeof(T));
				instance = GameObject.GetComponent<T>();

				instance.transform.SetParent( SystemMain.instance.transform );

				// �j��s�\��
				DontDestroyOnLoad(instance);
			}
			return instance;
		}
	}

	/// <summary>
	/// ������
	/// </summary>
	virtual public void Initialize()
	{
	}

	/// <summary>
	/// �A�b�v�f�[�g
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
