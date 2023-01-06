using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SystemMain : SingletonBase<SystemMain>
{
	/// <summary>
	/// ���߂̈��Ă΂����
	/// </summary>
	[RuntimeInitializeOnLoadMethod]
	static void Initialize()
	{
		// �C���X�^���X����Ƃ�
		_ = SystemMain.Instance;

		// ���ꂼ��̐���
		MyInputSystem.Instance.Initialize();
	}

	/// <summary>
	/// Update�@��{�I�ɂ̓��[�v�̍ŏ��ɌĂԂ���
	/// </summary>
	public void UpdateSub()
	{
		MyInputSystem.Instance.UpdateSub();
	}

}
