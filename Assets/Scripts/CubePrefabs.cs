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
	[Tooltip("Visaugstākās prioritātes rašanās parametri")]
	public KubaParametri RašanāsPrioritāte;

    public GameObject Zāle;
    public GameObject Kaza;
    public GameObject Koks;
    public GameObject Akmens;
	public GameObject Purvs;
	public GameObject Nauda;
    public GameObject Pirāts;
    public GameObject Nogruvums;

	public GameObject GetPrefab()
	{
		return RašanāsPrioritāte.IegūtSagatavi();
	}

	public GameObject GetInstance()
	{
		return Instantiate(GetPrefab());
	}
}