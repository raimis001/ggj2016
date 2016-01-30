using UnityEngine;
using System.Collections;
using System;

public class SwampCube : CubeAbstract
{
	public float StuckTime = 02f;
	public GameObject Bubbles;

	public override bool CanMoveTo()
	{
		return true;
	}

	public override void OnPlayerLanded()
	{
		PlayerControler.Moving = true;
		StuckTime = 2f;
		if (Bubbles != null)
		{
			Bubbles.SetActive(true);
		}
  }

	// Use this for initialization
	override protected void Start()
	{
		base.Start();
	}

	// Update is called once per frame
	void Update()
	{
		if (StuckTime == 0)
		{
			return;
		}
		StuckTime -= Time.deltaTime;
		if (StuckTime <= 0)
		{
			PlayerControler.Moving = false;
			StuckTime = 0;
			if (Bubbles != null)
			{
				Bubbles.SetActive(false);
			}
		}
	}
}
