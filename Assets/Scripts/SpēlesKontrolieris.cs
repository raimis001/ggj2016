using UnityEngine;
using System.Collections;

public class SpēlesKontrolieris : MonoBehaviour
{
	public static SpēlesKontrolieris Instance;
	public Līmeņi Līmeņi;
	public static int LīmeņaIndeks = 0;
	public LīmeņaKonfigurācija Līmenis
	{
		get
		{
			if (LīmeņaIndeks < 0 || LīmeņaIndeks >= Līmeņi.Skaits) { return null; }
			return Līmeņi.Saraksts[LīmeņaIndeks];
		}

	}

	void Awake()
	{
		Instance = this;
	}

	// Use this for initialization
	void Start ()
	{
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
