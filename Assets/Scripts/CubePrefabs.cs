using UnityEngine;
using System.Collections;
using System;
using Random = UnityEngine.Random;
using System.Collections.Generic;

public enum KubaTips
{
	Zāle,
	Kaza,
	Koks,
	Akmens,
	Purvs,
	Nauda,
	Pirāts,
	Nogruvums
}

public static partial class KubaTipaFunkcijas
{
	public static KubaTips Nejaušs()
	{
		int count = Enum.GetNames(typeof(KubaTips)).Length;
		return (KubaTips)Random.Range(0, count);
	}
}

public static partial class Paplašinājumi
{
	public static T Nejaušs<T>(this List<T> tipi)
	{
		if(tipi.Count > 0)
		{
			return tipi[Random.Range(0, tipi.Count)];
		}
		return default(T);
	}
}

public class CubePrefabs : ScriptableObject
{
	[Tooltip("Visaugstākās prioritātes rašanās parametri")]
	public KubaParametri RašanāsPrioritāte;

	public GameObject GetPrefab()
	{
		return RašanāsPrioritāte.IegūtSagatavi();
	}

	public GameObject GetInstance()
	{
		return Instantiate(GetPrefab());
	}
}