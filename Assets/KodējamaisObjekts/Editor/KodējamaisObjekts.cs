#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.IO;

public static class KodējamaisObjekts
{
    /// <summary>
    /// Ļauj radīt un saglabāt mantotu kodējamo objektu
    /// </summary>
    /// <typeparam name="T">Mantotā kodējamā objetka tips</typeparam>
    public static void Radīt<T> () where T : ScriptableObject
    {
        T asset = ScriptableObject.CreateInstance<T> ();
        
        string path = AssetDatabase.GetAssetPath (Selection.activeObject);
        if (path == "") 
        {
            path = "Assets";
        } 
        else if (Path.GetExtension (path) != "") 
        {
            path = path.Replace (Path.GetFileName (AssetDatabase.GetAssetPath (Selection.activeObject)), "");
        }
        
        string assetPathAndName = AssetDatabase.GenerateUniqueAssetPath (path + "/Jauns " + typeof(T).ToString() + ".asset");
        
        AssetDatabase.CreateAsset (asset, assetPathAndName);
        
        AssetDatabase.SaveAssets ();
        EditorUtility.FocusProjectWindow ();
        Selection.activeObject = asset;
    }
}
#endif
