using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FournitureSelection : MonoBehaviour
{
	// Start is called before the first frame update
	public GameObject[] fournitures;
	public GameObject fourniturMenu;
	public GameObject fournitureselection;
	public static int selectedCharacter = 0;

	public int getselected()
    {
		return selectedCharacter;
    }

	public void NextCharacter()
	{
		fournitures[selectedCharacter].SetActive(false);
		selectedCharacter = (selectedCharacter + 1) % fournitures.Length;
		fournitures[selectedCharacter].SetActive(true);
	}

	public void PreviousCharacter()
	{
		fournitures[selectedCharacter].SetActive(false);
		selectedCharacter--;
		if (selectedCharacter < 0)
		{
			selectedCharacter += fournitures.Length;
		}
		fournitures[selectedCharacter].SetActive(true);
	}

	public void StartGame()
	{
		/*for (var i= 0; i<fournitures.Length; i++)
            {
			fournitures[i].gameObject.SetActive(false);
            }*/

		ReferencePointCreator reference = new ReferencePointCreator();
		reference.setObjectMethod();
		fourniturMenu.SetActive(false);
		fournitureselection.SetActive(false);
		//PlayerPrefs.SetInt("selectedCharacter", selectedCharacter);
		
	}
}
