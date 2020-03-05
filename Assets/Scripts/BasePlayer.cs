using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BasePlayer : MonoBehaviour
{

    public static string[] rarityList = { "Bronze", "Silver", "Gold" }; // de olika rarities spelarna kan ha. Detta kommer att ha påverkan på de stats spelarna kommer att ha. 

    string position;
    public string Position
    {
        get
        {
            return position;
        }
        set
        {
            position = value;
        }
    }

    int stat; 
    public int Stat
    {
        get
        {
            return stat;
        }
        set
        {
            stat = value;
        }
    }

    string rarity;    
    public string Rarity
    {
        get
        {
            return rarity;
        }
        set
        {
            rarity = value;
        }
    }

    string playerName;
    public string PlayerName
    {
        get; set; 
    }

    public BasePlayer()
    {
        Rarity = rarityList[Random.Range(0, rarityList.Length)];

        for (int i = 0; i < rarityList.Length; i++)
        {
            if (Rarity == rarityList[i])
            {
                Stat = Random.Range((i + 2) * (i + 1), (i + 4) * (i + 1));
            }
        }
    }
}
