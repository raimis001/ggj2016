using UnityEngine;
using System.Collections;

public class KubaParametri : ScriptableObject
{
	public KubaTips Tips;
	public GameObject Sagatave;
	public float RašanāsIespēja;
	[Tooltip("Neizdodos radīt atkrīt uz šiem parametriem")]
	public KubaParametri Atkritējs;

	public GameObject IegūtSagatavi()
	{
		float iespēja = Random.Range(0f, 100f);
		if (iespēja < RašanāsIespēja)
		{
			return Sagatave;
		}
		else
		{
			if(Atkritējs != null)
			{
				return Atkritējs.IegūtSagatavi();
			}
		}
		return Sagatave;
	}
}