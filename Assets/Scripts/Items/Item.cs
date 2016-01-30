using UnityEngine;
using System.Collections;

public class Item : MonoBehaviour
{
	public int Value = 5;

	public virtual void OnItemTake()
	{
		PlayerControler.AddScore(Value);
	}

}
