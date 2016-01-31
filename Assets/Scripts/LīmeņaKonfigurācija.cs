using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;

[Serializable]
public class KubaApraksts
{
	public int RindasIndeks = 0;
	public int IndeksRindā = 0;
	public KubaTips KubaTips = KubaTips.Zāle;
}

public class LīmeņaKonfigurācija : ScriptableObject
{
	public int KubiPirmajāRindā = 3;
	public int Rindas = 10;
	/// <summary>
	/// Tiks izmantots, ja nebūs nodefinēta taka
	/// </summary>
	public int SākumaRindasIndeks = 2;

	public List<KubaApraksts> SagatavotieKubi = new List<KubaApraksts>();
}
