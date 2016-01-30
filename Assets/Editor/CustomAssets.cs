using UnityEngine;
using System.Collections;
using UnityEditor;

public class CustomAssets : Editor
{
    [MenuItem("Piederumi/Radīt/KubuTipi")]
    public static void CreateCubeTypes()
    {
        KodējamaisObjekts.Radīt<CubePrefabs>();
    }
}
