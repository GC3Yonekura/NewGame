using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene1 : SceneBase
{
    public override void UpdateSub()
	{
		if ( MyInputSystem.Instance.isPush( MyInputSystem.MyKey.W ) )
		{
			Debug.Log("�V�[��1");
		}
		if ( MyInputSystem.Instance.isPush( MyInputSystem.MyKey.A ) )
		{
			SceneControll.Instance.ChangeScene("Scene2");
		}
	}
}
