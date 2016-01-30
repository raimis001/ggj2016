using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KalnaApraksts : ScriptableObject
{
	public int CubesInFirstRow = 3;
	public int Rows = 10;
	/// <summary>
	/// Starts with 0
	/// </summary>
	public int StartRowIndex = 2;
}

public class KubaApraksts : ScriptableObject
{
	public int RindasIndeks = 0;
	public int IndeksRindā = 0;
	public KubaTips KubaTips = KubaTips.Zāle;
}

public class LīmeņaKonfigurācija : ScriptableObject
{
	public KalnaApraksts KalnaApraksts = ScriptableObject.CreateInstance<KalnaApraksts>();
	public List<KubaApraksts> SagatavotieKubi = new List<KubaApraksts>();
}
