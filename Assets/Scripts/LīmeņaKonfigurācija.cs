using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class KalnaApraksts
{
	public int CubesInFirstRow = 3;
	public int Rows = 10;
	/// <summary>
	/// Starts with 0
	/// </summary>
	public int StartRowIndex = 2;
}

[Serializable]
public class KubaApraksts
{
	public int RindasIndeks = 0;
	public int IndeksRindā = 0;
	public KubaTips KubaTips = KubaTips.Zāle;
}

public class LīmeņaKonfigurācija : ScriptableObject
{
	public KalnaApraksts KalnaApraksts = new KalnaApraksts();
	public List<KubaApraksts> SagatavotieKubi = new List<KubaApraksts>();
}
