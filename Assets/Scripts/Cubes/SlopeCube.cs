using UnityEngine;
using System.Collections;
using System;
using Random = UnityEngine.Random;

public enum SlopeDirection
{
	Left,
	Right
}

public class SlopeCube : CubeAbstract
{
	public bool RandomDirection = true;
	public SlopeDirection Direction = SlopeDirection.Left;
	public Transform Slope;

	// Use this for initialization
	override protected void Start()
	{
		base.Start();
		if(RandomDirection)
		{
			if(Random.value > 0.5f)
			{
				Direction = SlopeDirection.Left;
            }
			else
			{
				Direction = SlopeDirection.Right;
			}
		}
		Rotate();
	}

	void Rotate()
	{
		float angle = Direction == SlopeDirection.Right ? 180 : -90;
		Slope.transform.localEulerAngles = new Vector3(0, angle, 0);
	}

	public override void OnPlayerLanded()
	{
		float direction = Direction == SlopeDirection.Right ? 1f : -1f;
		Mountain.GetComponent<SimpleController>().DropToCube(direction);
	}

	public override bool CanMoveTo()
	{
		return true;
	}
}
