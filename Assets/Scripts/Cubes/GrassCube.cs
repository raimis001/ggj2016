using UnityEngine;
using System.Collections;
using System;
using Random = UnityEngine.Random;

public class GrassCube : CubeAbstract
{
	/// <summary>
	/// Can it randomize for item
	/// </summary>
	public bool CanHaveItem = true;
	public Item Item;

	public GameObject[] Items;

	public Material[] Grass;
	public GameObject GrassObject;

	override protected void Start()
	{
		base.Start();
		GrassObject.GetComponent<Renderer>().sharedMaterial = Grass[Random.Range(0, Grass.Length)];
		if (CanHaveItem)
		{
			if (Random.value < 0.1f)
			{
				AddItem(Items[Random.Range(0, Items.Length)]);
			}
		}
	}

	public void AddItem(GameObject item)
	{
		if (Item)
		{
			return;
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
			Destroy(Item.gameObject);
			Item = null;
		}
	}


	// Update is called once per frame
	void Update()
	{

	}
}
