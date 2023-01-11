using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMoveBase : ObjectBase
{
	public float X
	{
		get {
			return Position.x;
		}
		set {
			transform.position = new Vector3( value, Position.y, Position.z );
		}
	}
    public float Y
	{
		get {
			return Position.y;
		}
		set {
			transform.position = new Vector3( Position.x, value, Position.z );
		}
	}
    public float Z
	{
		get {
			return Position.z;
		}
		set {
			transform.position = new Vector3( Position.x, Position.y, value );
		}
	}
}
