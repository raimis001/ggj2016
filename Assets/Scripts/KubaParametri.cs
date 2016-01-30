using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class KubaParametri : ScriptableObject
{
	public KubaTips Tips;
	public GameObject Sagatave;
	public float RašanāsIespēja;
	[Tooltip("Neizdodos radīt atkrīt uz kādu no šiem parametriem ar vienādu iespēju")]
	public List<KubaParametri> Atkritēji = new List<KubaParametri>();

	public GameObject IegūtSagatavi()
	{
		float iespēja = Random.Range(0f, 100f);
		if (iespēja < RašanāsIespēja)
		{
			return Sagatave;
		}
		else
		{
			KubaParametri atkritējs = IegūtAkritēju();
            if (atkritējs != null)
			{
				return atkritējs.IegūtSagatavi();
			}
		}
		return Sagatave;
	}

	KubaParametri IegūtAkritēju()
	{
		if(Atkritēji.Count != 0)
		{
			return Atkritēji.Nejaušs();
		}
		return null;
	}
}