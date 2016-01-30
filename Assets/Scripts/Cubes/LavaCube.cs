using UnityEngine;
using System.Collections;
using System;
using Random = UnityEngine.Random;

public class LavaCube : CubeAbstract
{
	public	float BurnTimeMin = 1f;
	public float BurnTimeMax = 3f;
	float LeftBurnTime = 1f;

	public override bool CanMoveTo()
	{
		return true;
	}

	public override void OnPlayerLanded()
	{
		//PlayerController.Instance.BurnGirl();
	}

	// Use this for initialization
	protected override void Start()
	{
		base.Start();
    }

	// Update is called once per frame
	void FixedUpdate()
	{
		if ((Right == null || Right is LavaCube) && (Left == null || Left is LavaCube))
		{
			return;
		}
		LeftBurnTime -= Time.fixedDeltaTime;
		if (LeftBurnTime > 0f)
		{
			return;
		}
		if (Random.value > 0.5f)
		{
			if(Right != null && !(Right is LavaCube))
            {
				Mountain.Replace(Instantiate(Mountain.Prefabs.Lava), Right);
			}
			
		}
		else
		{
			if (Left != null && !(Left is LavaCube))
			{
				Mountain.Replace(Instantiate(Mountain.Prefabs.Lava), Left);
			}
		}
		if (LeftBurnTime <= 0f)
		{
			LeftBurnTime = Random.Range(BurnTimeMin, BurnTimeMax);
		}
    }
}
