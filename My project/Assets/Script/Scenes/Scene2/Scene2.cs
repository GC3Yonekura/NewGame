using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene2 : SceneBase
{
	public override void UpdateSub()
	{
		if ( MyInputSystem.Instance.isPush( MyInputSystem.MyKey.W ) )
		{
			Debug.Log("�V�[��2");
		}
		if ( MyInputSystem.Instance.isPush( MyInputSystem.MyKey.A ) )
		{
			SceneControll.Instance.ChangeScene("Scene1");
		}
	}
}
