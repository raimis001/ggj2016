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
	public static KubaTips Nejaušs(this List<KubaTips> tipi)
	{
		return tipi[Random.Range(0, tipi.Count)];
	}
}

public class CubePrefabs : ScriptableObject
{
    public GameObject Zāle;
    public GameObject Kaza;
    public GameObject Koks;
    public GameObject Akmens;
	public GameObject Purvs;
	public GameObject Nauda;
    public GameObject Pirāts;
    public GameObject Nogruvums;

	/// <summary>
	/// Returns non null prefab types
	/// </summary>
	public List<KubaTips> DefinedTypes
	{
		get
		{
			List<KubaTips> types = new List<KubaTips>();
			foreach (KubaTips type in Enum.GetValues(typeof(KubaTips)))
			{
				if (HavePrefab(type))
				{
					types.Add(type);
				}
			}
			return types;
		}
	}

	public GameObject GetPrefab(KubaTips tips)
	{
		switch(tips)
		{
			case KubaTips.Zāle: return Zāle;
			case KubaTips.Kaza: return Kaza;
			case KubaTips.Koks: return Koks;
			case KubaTips.Akmens: return Akmens;
			case KubaTips.Purvs: return Purvs;
			case KubaTips.Nauda: return Nauda;
			case KubaTips.Pirāts: return Pirāts;
			case KubaTips.Nogruvums: return Nogruvums;
		}
		return null;
	}

	public GameObject GetInstance(KubaTips tips)
	{
		return Instantiate(GetPrefab(tips));
	}

	public bool HavePrefab(KubaTips tips)
	{
		return GetPrefab(tips) != null;
	}
}