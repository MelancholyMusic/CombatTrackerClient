using Player;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UICharacterVitalsManager : MonoBehaviour {

    private CharacterTemp character = new CharacterTemp();

    public Image Portrait;
    public RectTransform HPFillMask;
    public Text HitPoints;
    public Text NegPoints;
    public Text AC;
    public Text CMD;
    public Text Fort;
    public Text Ref;
    public Text Will;
    public Text Init;
    public Text Perception;
    public Text Speed;
    public RectTransform ResistanceList;
    public RectTransform ResistanceUI;
    public RectTransform StatusList;
    public RectTransform StatusUI;

    void Start ()
    {
        Portrait = PortraitImage();
        HitPoints.text = HitPointText();
        AC.text = ACText();
        CMD.text = CMDText();
        Fort.text = FortText();
        Ref.text = RefText();
        Will.text = WillText();
        Init.text = InitText();
        Perception.text = PerceptionText();
        Speed.text = SpeedText();
        
        CreateResistanceList();
        CreateStatusList();
	}

    private Image PortraitImage()
    {
        return character.Portrait;
    }

    private void CreateStatusList()
    {
        StatusList.DetachChildren(); //Remove Editor Children

        foreach (PStatus status in character.Statuses)
        {
            Instantiate(StatusUI, StatusList);
        }
    }

    private void CreateResistanceList()
    {
        ResistanceList.DetachChildren(); //Remove Editor Children

        foreach (PResistance resistance in character.Resistances)
        {
            var res = Instantiate(ResistanceUI, ResistanceList);
            res.FindChild("Label").GetComponent<Text>().text = resistance.Description;
            res.FindChild("ResText").GetComponent<Text>().text = resistance.Value.ToString();
        }

        ResizeResistancePanel();
    }

    private void ResizeResistancePanel()
    {
        if (ResistanceList.childCount > 0)
            ResistanceList.sizeDelta = new Vector2(ResistanceList.sizeDelta.x, 16 + 96 * ResistanceList.childCount);
        else
            ResistanceList.sizeDelta = new Vector2(0, 0);
    }

    private string SpeedText()
    {
        return character.Speed.ToString();
    }

    private string PerceptionText()
    {
        return ToBonus(character.Perception);
    }

    private string InitText()
    {
        return ToBonus(character.Init);
    }

    private string WillText()
    {
        return ToBonus(character.Will);
    }

    private string RefText()
    {
        return ToBonus(character.Ref);
    }

    private string FortText()
    {
        return ToBonus(character.Fort);
    }

    private string CMDText()
    {
        return character.CMD.ToString();
    }

    private string ACText()
    {
        return character.AC.ToString();
    }

    private string HitPointText()
    {
        
        HPFillMask.sizeDelta = new Vector2(HPFillMask.sizeDelta.x, Math.Max(150 * character.HP_Current / character.HP_Max, 0.1f));

        if (character.HP_Current <= 0)
        {

        }

        return character.HP_Current + "/" + character.HP_Max;
    }

    private string ToBonus(int Var)
    {
        if (Var < 0)
            return "-" + Var;

        return "+" + Var;
    }

    public void ReduceHitPoints()
    {
        character.HP_Current -= 3;

        HitPoints.text = HitPointText();
    }
}
