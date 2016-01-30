using UnityEngine;
using System.Collections;
using System;

public enum SlopeDirection
{
	LEFT,
	RIGHT
}

public class SlopeCube : CubeAbstract
{

	public SlopeDirection Direction;
	public Transform Slope;

	SlopeDirection _direction = SlopeDirection.RIGHT;

	// Use this for initialization
	void Start()
	{
		
  }

	// Update is called once per frame
	void Update()
	{
		if (Direction != _direction)
		{
			_direction = Direction;
			Rotate();
		}
	}

	void Rotate()
	{
		float angle = Direction == SlopeDirection.RIGHT ? 0 : 270;
		Slope.transform.localEulerAngles = new Vector3(0, angle, 0);
	}

	public override void OnPlayerLanded()
	{
		CubeAbstract cube = Direction == SlopeDirection.RIGHT ? this.Right : this.Left;
    PlayerControler.Instance.SlopeGirl(cube);
	}

	public override bool CanMoveTo()
	{
		return true;
	}
}
