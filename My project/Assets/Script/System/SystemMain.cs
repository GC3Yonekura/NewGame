using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemMain : SingletonBase<SystemMain>
{
	/// <summary>
	/// 初めの一回呼ばれるやつ
	/// </summary>
	[RuntimeInitializeOnLoadMethod]
	public override void Initialize() 
	{
		// それぞれの生成
		MyInputSystem.Instance.Initialize();
	}

	/// <summary>
	/// Update　基本的にはループの最初に呼ぶこと
	/// </summary>
	public　override void UpdateSub()
	{
		MyInputSystem.Instance.UpdateSub();
	}

}
