using UnityEngine;
using System.Collections;
using System;
using Random = UnityEngine.Random;

public class GrassCube : CubeAbstract
{
	public Item Item;

	public GameObject[] Items;

	public Material[] Grass;
	public GameObject GrassObject;

	void Start()
	{
		GrassObject.GetComponent<Renderer>().sharedMaterial = Grass[UnityEngine.Random.Range(0, Grass.Length)];
		if (Random.value < 0.1f)
		{
			AddItem(Items[Random.Range(0, Items.Length)]);
		}
	}

	public void AddItem(GameObject item)
	{
		if (Item)
		{
			Destroy(Item.gameObject);
		}

		GameObject obj = Instantiate(item);
		obj.transform.SetParent(transform);
		obj.transform.localPosition = Vector3.zero;
		obj.transform.localScale = Vector3.one;
		Item = obj.GetComponent<Item>();
	}

	public override bool CanMoveTo()
	{
		return true;
	}

	public override void OnPlayerLanded()
	{
		if (Item != null)
		{
			Item.OnItemTake();
			Destroy(Item);
    }
	}


	// Update is called once per frame
	void Update()
	{

	}
}
