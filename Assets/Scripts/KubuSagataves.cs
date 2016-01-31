using UnityEngine;
using System.Collections;
using System;
using Random = UnityEngine.Random;
using System.Collections.Generic;

public enum KubaTips
{
	Zāle,
	Koks,
	Akmens,
	Purvs,
	Kaza,
	Nauda,
	Dzelkšņi,
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

public class KubuSagataves : ScriptableObject
{
	[Tooltip("Visaugstākās prioritātes rašanās parametri")]
	public KubaParametri RašanāsPrioritāte;

	public GrassCube Zāle;
	public SwampCube Purvs;
	public GrassCube Kaza;
	public GrassCube Nauda;
	public ThornCube Dzelkšņi;
	public LavaCube Lava;

	/// <summary>
	/// Atgriež sagatavi no prioritāšu ķēdes
	/// </summary>
	public GameObject IegūtSagatavi()
	{
		return RašanāsPrioritāte.IegūtSagatavi();
	}

	/// <summary>
	/// Atgriež sagatavi, kas atbilst padotajam tipam
	/// </summary>
	public GameObject IegūtSagatavi(KubaTips tips)
	{
		switch(tips)
		{
			case KubaTips.Zāle: return Zāle.gameObject;
			case KubaTips.Purvs: return Purvs.gameObject;
			case KubaTips.Kaza: return Kaza.gameObject;
			case KubaTips.Nauda: return Nauda.gameObject;
			case KubaTips.Dzelkšņi: return Dzelkšņi.gameObject;
			default: return Zāle.gameObject;
		}
	}

	/// <summary>
	/// Atgriež instanci no prioritāšu ķēdes
	/// </summary>
	public GameObject IegūtInstanci()
	{
		return Instantiate(IegūtSagatavi());
	}

	/// <summary>
	/// Atgriež instanci no sagataves, kas atbilst padotajam tipam
	/// </summary>
	public GameObject IegūtInstanci(KubaTips tips)
	{
		return Instantiate(IegūtSagatavi(tips));
	}
}