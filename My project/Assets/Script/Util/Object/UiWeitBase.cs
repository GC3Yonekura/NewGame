using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UiWeitBase : ObjectBase
{

	private StateMachine< State > stateMachine = null;
	enum State
	{
		Start,
		Loop,
		End,

		Max,
	}

	public override void Initialize()
	{
		base.Initialize();
		stateMachine = new StateMachine< State >();


		stateMachine.Initialize( (int)State.Max );
	}

	public override void Release()
	{
		base.Release();
		stateMachine?.Release();
		stateMachine = null;
	}
	public override void UpdateSub()
	{
		stateMachine.UpdateSub();
	}
}
