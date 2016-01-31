using UnityEngine;
using System.Collections;


public class Item : MonoBehaviour
{
	public KubaTips ItemType;
	public int Value = 5;

	public GameObject TakeEffectPrefab;
	public Vector3 TakeEffectOffset;

	public virtual void OnItemTake()
	{
		if (ItemType == KubaTips.Kaza)
		{
			PlayerController.AddGoat(Value);
		}
		else
		{
			PlayerController.AddScore(Value);
		}		

		if(TakeEffectPrefab != null)
		{
            Transform effectTransform = Instantiate(TakeEffectPrefab).transform;
			effectTransform.position = transform.position + TakeEffectOffset;
		}
	}
}
