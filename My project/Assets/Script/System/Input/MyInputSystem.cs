using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyInputSystem : SingletonBase<MyInputSystem>
{
	MyKey nowKeyCode		= MyKey.Err;
	MyKey beforKeyCode	= MyKey.Err;

	float[] repTime = null;

	[Flags]
	public enum MyKey
	{
		None = 0,

		W			= 1	<< 0,
		A			= 1 << 1,
		S			= 1 << 2,
		D			= 1 << 3,
		Spc			= 1 << 4,
		LeftClick	= 1 << 5,
		RightClick	= 1 << 6,
		Enter		= 1 << 7,

		Max,

		Err,

	}

   public void Initialize()
	{
		beforKeyCode = 0;
		nowKeyCode = 0;

		repTime = new float[ (int)MyKey.Max];
	}

	public void UpdateSub()
	{
		beforKeyCode = nowKeyCode;
		nowKeyCode = MyKey.None;

		if( Input.GetKeyDown(UnityEngine.KeyCode.A) )
		{
			nowKeyCode |= MyKey.A;
		}

		if (Input.GetKeyDown(UnityEngine.KeyCode.W))
		{
			nowKeyCode |= MyKey.W;
		}

		if (Input.GetKeyDown(UnityEngine.KeyCode.S))
		{
			nowKeyCode |= MyKey.S;
		}

		if (Input.GetKeyDown(UnityEngine.KeyCode.D))
		{
			nowKeyCode |= MyKey.D;
		}


		RepUpdate();
	}


	private void RepUpdate()
	{
		RepCalc(MyKey.A);
		RepCalc(MyKey.W);
		RepCalc(MyKey.S);
		RepCalc(MyKey.D);
		RepCalc(MyKey.Spc);
		RepCalc(MyKey.LeftClick);
		RepCalc(MyKey.RightClick);
	}

	private void RepCalc( MyKey key )
	{
		if (isPush(key))
		{
			repTime[(int)key] += Time.deltaTime;
		}
		else
		{
			repTime[(int)key] = 0.0f;
		}
	}



	/// <summary>
	/// ç°âüÇ≥ÇÍÇΩÇ©
	/// </summary>
	/// <param name="key"></param>
	/// <returns></returns>
	public bool isPush( MyKey key )
	{
		if( ( beforKeyCode & key ) == 0 && ( nowKeyCode & key ) != 0 )
		{
			return true;
		}
		return false;
	}

	public bool isDown( MyKey key )
	{
		if( (nowKeyCode & key ) != 0 )
		{
			return true;
		}
		return false;
	}

	public bool isRelease(MyKey key)
	{
		if ((beforKeyCode & key) != 0 && (nowKeyCode & key) == 0)
		{
			return true;
		}
		return false;
	}
	

}
