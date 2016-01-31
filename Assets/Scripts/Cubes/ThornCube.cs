using UnityEngine;
using System.Collections;
using System;

public class ThornCube : CubeAbstract
{
	public int Value = -10;
	public GameObject SadnessEffectPrefab;
	public Vector3 SadnessEffectOffset;
	public GameObject DustEffectPrefab;
	public Vector3 DustEffectOffset;

	public override bool CanMoveTo()
	{
		return true;
	}

	public override void OnPlayerLanded()
	{
		SadnessEffect();
		PlayerController.AddScore(Value);
		DustEffect();
	}

	// Use this for initialization
	override protected void Start()
	{
		base.Start();
	}

	// Update is called once per frame
	void Update()
	{

	}

	void SadnessEffect()
	{
		if(SadnessEffectPrefab == null) { return; }
		Transform effectTransform = Instantiate(SadnessEffectPrefab).transform;
		effectTransform.position = transform.position + SadnessEffectOffset;
	}

	void DustEffect()
	{
		if (DustEffectPrefab == null) { return; }
		Transform effectTransform = Instantiate(DustEffectPrefab).transform;
		effectTransform.position = transform.position + DustEffectOffset;
	}
}
