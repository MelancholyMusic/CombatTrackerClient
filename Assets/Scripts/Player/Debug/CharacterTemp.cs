using Player;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharacterTemp
{
    public string Name = "Vanlith", ClassLevels = "Channeler 5", Campaign = "Midnight";
    public int HP_Current = 28, HP_Max = 28, AC = 15, CMD = 14, Fort = 3, Ref = 5, Will = 11, Init = 2, Perception = 8, Speed = 20;
    public List<PResistance> Resistances = new List<PResistance>() { new PResistance("DR / -", 5), new PResistance("Fire resistance", 10)};
    public List<PStatus> Statuses = new List<PStatus>() { new PStatus(), new PStatus(), new PStatus()};
    public Image Portrait;
}
