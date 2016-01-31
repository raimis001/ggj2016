using UnityEngine;
using System.Collections;
using UnityEditor;

public class CustomAssets : Editor
{
    [MenuItem("Piederumi/Radīt/Kubu sagataves")]
    public static void CreateCubeTypes()
    {
        KodējamaisObjekts.Radīt<KubuSagataves>();
    }

	[MenuItem("Piederumi/Radīt/Kubu parametrus")]
	public static void CreateCubeParameters()
	{
		KodējamaisObjekts.Radīt<KubaParametri>();
	}

	[MenuItem("Piederumi/Radīt/Līmeņa konfigurāciju")]
	public static void CreateLevelConfiguration()
	{
		KodējamaisObjekts.Radīt<LīmeņaKonfigurācija>();
	}

	[MenuItem("Piederumi/Radīt/Līmeņu sarakstu")]
	public static void RadītLīmeņuSarakstu()
	{
		KodējamaisObjekts.Radīt<Līmeņi>();
	}
}
