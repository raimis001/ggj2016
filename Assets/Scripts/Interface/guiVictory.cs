using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class guiVictory : MonoBehaviour
{

	public Text GoatText;
	public Text GoatName;

	public Text MoneyText;
	public Text MoneyName;

	string[] goatNames =
	{
		"scary",
		"ugly",
		"nice",
		"atletic",
		"godlike"

	};
	string[] moneyNames =
	{
		"poor",
		"mean",
		"average",
		"rich",
		"golden"
	};

	public void Open()
	{
		GoatText.text = PlayerController.Goats.ToString();
		int goat = PlayerController.Goats < 4 ? PlayerController.Goats : 4;
		GoatName.text = goatNames[goat];

		MoneyText.text = PlayerController.Score.ToString();
		int money = PlayerController.Score / 4;
		money = money < 5 ? money : 4;
		MoneyName.text = moneyNames[money];
		gameObject.SetActive(true);
	}

	// Use this for initialization
	void Start()
	{

	}

	// Update is called once per frame
	void Update()
	{

	}
}
