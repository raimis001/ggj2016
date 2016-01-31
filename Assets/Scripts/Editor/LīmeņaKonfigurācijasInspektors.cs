using UnityEngine;
using System.Collections;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor(typeof(LīmeņaKonfigurācija))]
public class LīmeņaKonfigurācijasInspektors : Editor
{
	LīmeņaKonfigurācija Target = null;
	KubaApraksts Noņemamais = new KubaApraksts();

	void OnEnable()
	{
		Target = (LīmeņaKonfigurācija)target;
	}

	public override void OnInspectorGUI()
	{
		Noņemamais = null;
        EditorGUILayout.LabelField("Kalna informācija");
		Target.KubiPirmajāRindā = EditorGUILayout.IntField("Kubi pirmajā rindā", Target.KubiPirmajāRindā);
		Target.Rindas = EditorGUILayout.IntField("Rindas kalnā", Target.Rindas);
		Target.SākumaRindasIndeks = EditorGUILayout.IntField("Starta rinda", Target.SākumaRindasIndeks);
		EditorGUILayout.LabelField("Laukuma informācija");
		KubaApraksts apraksts;
        for (int indeks = 0; indeks < Target.SagatavotieKubi.Count; indeks++)
		{
			apraksts = Target.SagatavotieKubi[indeks];
			apraksts.RindasIndeks = EditorGUILayout.IntField("Rindas indeks", apraksts.RindasIndeks);
			apraksts.IndeksRindā = EditorGUILayout.IntField("Indeks rindā", apraksts.IndeksRindā);
			apraksts.KubaTips = (KubaTips)EditorGUILayout.EnumPopup("Kuba tips", apraksts.KubaTips);
			if(GUILayout.Button("Noņemt"))
            {
				Noņemamais = apraksts;
			}
		}
		Pievienot();
		Noņemt();
		EditorUtility.SetDirty(Target);
	}

	void Pievienot()
	{
		if(GUILayout.Button("Pievienot"))
		{
			Target.SagatavotieKubi.Add(new KubaApraksts());
		}
	}

	void Noņemt()
	{
		if(Noņemamais != null)
		{
			Target.SagatavotieKubi.Remove(Noņemamais);
		}
    }
}
