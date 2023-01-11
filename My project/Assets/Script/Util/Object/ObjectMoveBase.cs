using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMoveBase : ObjectBase
{
	float X
	{
		get {
			return Position.x;
		}
		set {
			transform.position = new Vector3( value, Position.y, Position.z );
		}
	}
		float Y
	{
		get {
			return Position.y;
		}
		set {
			transform.position = new Vector3( Position.x, value, Position.z );
		}
	}
		float Z
	{
		get {
			return Position.z;
		}
		set {
			transform.position = new Vector3( Position.x, Position.y, value );
		}
	}
}
