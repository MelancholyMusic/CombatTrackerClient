using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICharacterSelectionManager : MonoBehaviour
{
    public RectTransform list;
    public GameObject card;

    List<CharacterTemp> characters = new List<CharacterTemp>() { new CharacterTemp(), new CharacterTemp() };

    void Awake()
    {
        CreateCards();
    }

    private void CreateCards()
    {
        list.DetachChildren(); //Remove Editor Children

        foreach (CharacterTemp resistance in characters)
        {
            var res = Instantiate(card, list);
            //res.FindChild("Label").GetComponent<Text>().text = resistance.Description;
            //res.FindChild("ResText").GetComponent<Text>().text = resistance.Value.ToString();
        }
    }


}
