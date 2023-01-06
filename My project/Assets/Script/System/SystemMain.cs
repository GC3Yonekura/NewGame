using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemMain : SingletonBase<SystemMain>
{
	/// <summary>
	/// 初めの一回呼ばれるやつ
	/// </summary>
	[RuntimeInitializeOnLoadMethod]
	static void Initialize()
	{
		// インスタンス作っとく
		_ = SystemMain.Instance;

		// それぞれの生成
		MyInputSystem.Instance.Initialize();
	}

	/// <summary>
	/// Update　基本的にはループの最初に呼ぶこと
	/// </summary>
	public void UpdateSub()
	{
		MyInputSystem.Instance.UpdateSub();
	}

}
