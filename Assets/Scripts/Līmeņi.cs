using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Līmeņi : ScriptableObject
{
	public int Skaits
	{
		get
		{
			if (Saraksts == null) { return 0; }
			return Saraksts.Count;
		}
	}

	public List<LīmeņaKonfigurācija> Saraksts = new List<LīmeņaKonfigurācija>();
}
