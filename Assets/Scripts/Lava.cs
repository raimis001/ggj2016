using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Mountain))]
public class Lava : MonoBehaviour
{
    Mountain Mountain = null;
    
	// Use this for initialization
	void Start ()
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
        cube.Nāvējošs = true;
        cube.Renderer.material.color = Color.red;
    }
}
