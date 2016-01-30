using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Mountain))]
public class Lava : MonoBehaviour
{
    Mountain Mountain = null;
	CubePrefabs CubePrefabs = null;
    
	// Use this for initialization
	protected virtual void Start()
    {
        Mountain = GetComponent<Mountain>();
		ConsumeFirstRow();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    /// <summary>
    /// Converts all row cubes into lava
    /// </summary>
    void ConsumeFirstRow()
    {
        foreach(CubeAbstract cube in Mountain.FirstRow)
        {
            Consume(cube);
        }
    }

    /// <summary>
    /// Converts cube into lava
    /// </summary>
    void Consume(CubeAbstract cube)
    {
		Mountain.Replace(Instantiate(Mountain.Prefabs.Lava), cube);
    }
}
