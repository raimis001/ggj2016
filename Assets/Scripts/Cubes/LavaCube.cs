using UnityEngine;
using System.Collections;
using System;
using Random = UnityEngine.Random;
using System.Collections.Generic;

public class LavaCube : CubeAbstract
{
	/// <summary>
	/// Smoke on target
	/// </summary>
	[Tooltip("Smoke on target")]
	public GameObject SmokeEffectPrefab;
	/// <summary>
	/// Errupt fire from to time
	/// </summary>
	[Tooltip("Errupt fire from to time")]
	public List<GameObject> FireEffectPrefabs;
	/// <summary>
	/// Offset from cube center to spawn
	/// </summary>
	[Tooltip("Offset from cube center to spawn")]
	public List<Vector3> FireEffectOffsets;

	public	float BurnTimeMin = 1f;
	public float BurnTimeMax = 3f;
	float LeftBurnTime = 1f;
	public float EruptionTimeMin = 0.8f;
	public float EruptionTimeMax = 4f;
	float LeftEruptionTime = 1f;

	public override bool CanMoveTo()
	{
		return true;
	}

	public override void OnPlayerLanded()
	{
		PlayerController.Instance.BurnGirl();
	}

	// Use this for initialization
	protected override void Start()
	{
		base.Start();
		StartCoroutine(Flow());
		StartCoroutine(EruptFromTimeToTime());
    }

	/// <summary>
	/// Slowly flows and consumes neighbour cubes
	/// </summary>
	/// <returns></returns>
	IEnumerator Flow()
	{
		yield return new WaitForFixedUpdate();
		LeftBurnTime = Random.Range(BurnTimeMin, BurnTimeMax);
		CubeAbstract target = null;
		while (true)
		{
			if ((Right == null || Right is LavaCube) && (Left == null || Left is LavaCube))
			{
				yield break;
			}
			if (target == null)
			{
				if (Random.value > 0.5f)
				{
					if (Right != null && !(Right is LavaCube))
					{
						target = Right;
					}
				}
				else
				{
					if (Left != null && !(Left is LavaCube))
					{
						target = Left;
					}
				}
				if(target != null)
				{
					Instantiate(SmokeEffectPrefab).GetComponent<SmokeBehaviour>().Target = target.transform;
				}
			}
			LeftBurnTime -= Time.fixedDeltaTime;
			if (LeftBurnTime <= 0f)
			{
				if (target != null)
				{
					//Sadedzinam meiteni, ja tā ir uz aktīvā kuba
					if(target == SimpleController.Instance.ActiveCube)
					{
						PlayerController.Instance.BurnGirl();
					}
					Mountain.Replace(Instantiate(Mountain.Prefabs.Lava), target);
				}
				LeftBurnTime = Random.Range(BurnTimeMin, BurnTimeMax);
				target = null;
			}
			yield return new WaitForFixedUpdate();
		}
    }

	IEnumerator EruptFromTimeToTime()
	{
		if (FireEffectPrefabs.Count == 0) { yield break; }
		LeftEruptionTime = Random.Range(EruptionTimeMin / 2f, EruptionTimeMax / 2f);
		int random;
		while (true)
		{
			LeftEruptionTime -= Time.fixedDeltaTime;
			if (LeftEruptionTime <= 0f)
			{
				random = Random.Range(0, FireEffectPrefabs.Count);
				Transform fireTransform = Instantiate(FireEffectPrefabs[random]).transform;
				fireTransform.position = transform.position + new Vector3(0.5f, 1f, 0.5f) + FireEffectOffsets[random];
                LeftEruptionTime = Random.Range(EruptionTimeMin, EruptionTimeMax);
			}
				yield return new WaitForFixedUpdate();
		}
	}
}
