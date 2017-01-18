using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICharacterSelectionManager : MonoBehaviour
{
    public RectTransform list;
    public GameObject card;

    List<CharacterTemp> characters = new List<CharacterTemp>() { new CharacterTemp(), new CharacterTemp() };
    public RectTransform list;
    public RectTransform card;

    void Awake()
    {
        CreateCards();
    }

    private void CreateCards()
    {
        list.DetachChildren(); //Remove Editor Children

        foreach (CharacterTemp resistance in characters)
        foreach (CharacterTemp character in characters)
        {
            var res = Instantiate(card, list);
            //res.FindChild("Label").GetComponent<Text>().text = resistance.Description;
            //res.FindChild("ResText").GetComponent<Text>().text = resistance.Value.ToString();
            var _card = Instantiate(card, list);
            _card.FindChild("CharName").GetComponent<Text>().text = character.Name;
            _card.FindChild("Campaign").GetComponent<Text>().text = character.Campaign;
            _card.FindChild("ClassLevels").GetComponent<Text>().text = character.ClassLevels;
        }
    }


}
