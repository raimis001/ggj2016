using UnityEngine;
using System.Collections;

public class ScrollingUVs_Layers : MonoBehaviour 
{
	//public int materialIndex = 0;
	public Vector2 uvAnimationRate = new Vector2( 1.0f, 0.0f );
	public string textureName = "_MainTex";
	
	Vector2 uvOffset = Vector2.zero;
	Renderer Renderer = null;

	void Start()
	{
		Renderer = GetComponent<Renderer>();
    }

	void LateUpdate() 
	{
		uvOffset += ( uvAnimationRate * Time.deltaTime );
		if( Renderer.enabled )
		{
			Renderer.material.SetTextureOffset( textureName, uvOffset );
		}
	}
}