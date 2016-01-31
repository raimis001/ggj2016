using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Mountain : MonoBehaviour
{
	public static Mountain Instance;

	public LīmeņaKonfigurācija Konfigurācija = null;
	/// <summary>
	/// Iekšēji izmantot šo
	/// </summary>
	LīmeņaKonfigurācija KonfigurācijasInstance;
	/// <summary>
	/// All cube type prefab list
	/// </summary>
	[Tooltip("All cube type prefab list")]
	public KubuSagataves Prefabs;
	/// <summary>
	/// All mountain rows with cubes
	/// </summary>
	public List<List<CubeAbstract>> Content = new List<List<CubeAbstract>>();
	/// <summary>
	/// Grass plains under mountain
	/// </summary>
	[HideInInspector]
	public List<CubeAbstract> Plains = null;

	void Awake()
	{
		Instance = this;
	}

	void Start()
	{
		SpēlesKontrolieris spēle = SpēlesKontrolieris.Instance;
        if (spēle != null && spēle.Līmenis != null)
		{
			Konfigurācija = spēle.Līmenis;
            KonfigurācijasInstance = Instantiate(spēle.Līmenis);
		}
		else
		{
			KonfigurācijasInstance = ScriptableObject.Instantiate(Konfigurācija);
		}
		KonfigurācijasInstance.SākumaRindasIndeks = Mathf.Clamp(Konfigurācija.SākumaRindasIndeks, 0, Konfigurācija.Rindas - 1);
		Generate();
	}

	public void Generate()
	{
		List<CubeAbstract> currentRow = null;
		GameObject block = null;
		CubeAbstract cube;
		int cubesPerRow = KonfigurācijasInstance.KubiPirmajāRindā;
		bool plainsAssigned = false;
		//Start position for row
		Vector3 startPosition = Vector3.zero;
		Vector3 currentPosition = Vector3.zero;
		for (int row = 0; row < KonfigurācijasInstance.Rindas + 3; row++)
		{
			currentRow = new List<CubeAbstract>();
			currentPosition = startPosition;
			for (int cubeIndex = 0; cubeIndex < cubesPerRow; cubeIndex++)
			{
				//creation
				if (row < KonfigurācijasInstance.Rindas)
				{
					//apskata vai ir kāds kubs sagatavots šim lauciņam
					KubaApraksts apraksts = GetCubeDescription(row, cubeIndex);
					if (apraksts != null)
					{
						block = Prefabs.IegūtInstanci(apraksts.KubaTips);
					}
					else
					{
						block = Prefabs.IegūtInstanci();
					}
				}
				else
				{
					block = Instantiate(Prefabs.Zāle.gameObject);
				}
				block.transform.position = currentPosition;
				block.transform.parent = transform;
				currentPosition += new Vector3(-1f, 0f, 1f);
				//assigning self as move target
				cube = block.GetComponent<CubeAbstract>();
				//Not letting plain grass get items
				if (row >= KonfigurācijasInstance.Rindas)
				{
					((GrassCube)cube).CanHaveItem = false;
				}
				cube.Row = row;
				cube.Index = cubeIndex;
				currentRow.Add(cube);
			}
			if (row < KonfigurācijasInstance.Rindas)
			{
				Content.Add(currentRow);
				startPosition += new Vector3(1f, -1f, 0f);
			}
			else
			{
				startPosition += new Vector3(1f, 0f, 0f);
				if (plainsAssigned == false)
				{
					Plains = currentRow;
					plainsAssigned = true;
				}
			}
			cubesPerRow++;
		}
	}

	KubaApraksts GetCubeDescription(int row, int index)
	{
		return KonfigurācijasInstance.SagatavotieKubi.Find(x => x.RindasIndeks == row && x.IndeksRindā == index);
	}

	public List<CubeAbstract> GetStartRow()
	{
		return Content[KonfigurācijasInstance.SākumaRindasIndeks];
	}

	/// <summary>
	/// Changer takes target place and destroys it
	/// </summary>
	public void Replace(CubeAbstract changer, CubeAbstract target)
	{
		Content[target.Row][target.Index] = changer;
		changer.transform.position = target.transform.position;
		changer.transform.parent = target.transform.parent;
		changer.Row = target.Row;
		changer.Index = target.Index;
		GameObject.Destroy(target.gameObject);
	}
}
