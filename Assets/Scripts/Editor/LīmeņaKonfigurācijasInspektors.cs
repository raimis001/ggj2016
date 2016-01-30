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
		Target.KalnaApraksts.CubesInFirstRow = EditorGUILayout.IntField("Kubi pirmajā rindā", Target.KalnaApraksts.CubesInFirstRow);
		Target.KalnaApraksts.Rows = EditorGUILayout.IntField("Rindas kalnā", Target.KalnaApraksts.Rows);
		Target.KalnaApraksts.StartRowIndex = EditorGUILayout.IntField("Starta rinda", Target.KalnaApraksts.StartRowIndex);
		EditorGUILayout.LabelField("Laukuma informācija");
		KubaApraksts apraksts;
        for (int indeks = 0; indeks < Target.SagatavotieKubi.Count; indeks++)
		{
			EditorGUILayout.BeginHorizontal();
			EditorGUILayout.LabelField("Vienības indeks");
			EditorGUILayout.SelectableLabel(indeks.ToString());
			EditorGUILayout.EndHorizontal();
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
