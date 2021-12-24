using UnityEngine;
using System.Collections;

public class ScrollingUVs_Layers : MonoBehaviour 
{
	//public int materialIndex = 0;
	private Vector2 uvAnimationRate = new Vector2(-0.05f, 0.0f);
	private string textureName = "_LavaTex";
	
	Vector2 uvOffset = Vector2.zero;
	
	void LateUpdate() 
	{
		uvOffset += ( uvAnimationRate * Time.deltaTime );
		if( GetComponent<Renderer>().enabled )
		{
			GetComponent<Renderer>().sharedMaterial.SetTextureOffset( textureName, uvOffset );
		}
	}
}