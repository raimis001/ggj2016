using UnityEngine;
using System.Collections;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class SwampCube : CubeAbstract
{
	/// <summary>
	/// Splash when dropping in swamp
	/// </summary>
	[Tooltip("Errupt fire from to time")]
	public List<GameObject> SplashEffectPrefabs;
	/// <summary>
	/// Offset from cube center to spawn
	/// </summary>
	[Tooltip("Offset from cube center to spawn")]
	public List<Vector3> SplashEffectOffsets;
	/// <summary>
	/// Effect while stuck
	/// </summary>
	[Tooltip("Effect while stuck")]
	public GameObject BubbleEffectPrefab;

	public float StuckTime = 2f;
	public bool Stuck
	{
		get
		{
			return _Stuck;
		}
		protected set
		{
			_Stuck = value;
		}
	}
	bool _Stuck = false;

	public override bool CanMoveTo()
	{
		return true;
	}

	public override void OnPlayerLanded()
	{
		PlayerController.Instance.PlaySound(1);
		StuckIn();
		Splash();

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

	void Splash()
	{
		int random = Random.Range(0, SplashEffectPrefabs.Count);
		Transform fireTransform = Instantiate(SplashEffectPrefabs[random]).transform;
		fireTransform.position = transform.position + new Vector3(0.5f, 1f, 0.5f) + SplashEffectOffsets[random];
	}

	void StuckIn()
	{
		StuckTime = 2f;
		Stuck = true;
		PlayerController.Moving = true;
		StartCoroutine(Unstucking());
	}

	/// <summary>
	/// Unstucking over time with effects
	/// </summary>
	IEnumerator Unstucking()
	{
		yield return new WaitForSeconds(0.2f);
		EffectLooper looper = Instantiate(BubbleEffectPrefab).GetComponent<EffectLooper>();
		looper.transform.position = transform.position + new Vector3(0.5f, 1f, 0.5f);
		while (Stuck)
		{
			StuckTime -= Time.fixedDeltaTime;
			if (StuckTime <= 0f)
			{
				PlayerController.Moving = false;
				StuckTime = 0f;
				Stuck = false;
				looper.Stop();
            }
			yield return new WaitForFixedUpdate();
		}
	}
}
