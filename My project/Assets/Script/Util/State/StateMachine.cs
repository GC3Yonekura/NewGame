using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class StateMachine<T> where T : struct
{
	private Dictionary< T, Action > stateAction = null;
	private Action stateUpdate = null;
	private T nowKey = default( T );

	public int Phase = 0;

	// ���݂̃X�e�[�g
	public T NowState
	{
		get { return nowKey; }
	}

	/// <summary>
	/// ������
	/// </summary>
	/// <param name="max"></param>
	public void Initialize( int max )
	{
		stateAction = new Dictionary< T, Action >( max );
	}

	/// <summary>
	/// �I������
	/// </summary>
	public void Release()
	{
		stateAction?.Clear();
		stateAction = null;
		stateUpdate = null;
	}

	/// <summary>
	/// �X�e�[�g�ǉ�
	/// </summary>
	/// <param name="key"></param>
	/// <param name="state"></param>
	public void AddState( T key, Action state )
	{
		stateAction.Add( key, state);
	}

	/// <summary>
	/// �A�b�v�f�[�g
	/// </summary>
	public void UpdateSub()
	{
		if ( stateUpdate != null )
		{
			stateUpdate();
		}
	}

	/// <summary>
	/// �X�e�[�g�ύX
	/// </summary>
	/// <param name="key"></param>
	public void ChangeState( T key )
	{
		Phase = 0;
		nowKey = key;
		stateUpdate = stateAction[ key ];
	}

	public void StepPhase( int stepCount = 1 )
	{
		Phase += stepCount;
	}
}
