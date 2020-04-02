using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BasePlayer : MonoBehaviour
{

    public static string[] rarityList = { "Bronze", "Silver", "Gold" }; // de olika rarities spelarna kan ha. Detta kommer att ha påverkan på de stats spelarna kommer att ha. 

    string role;
    public string Role
    {
        get
        {
            return role;
        } 
        set
        {
            role = value;
        }
    }

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
    string type;
    public string Type
    {
        get
        {
            return type;
        }
        set
        {
            type = value; 
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

    int exp = 0;
    public int Exp
    {
        get
        {
            return exp;
        }
        set
        {
            exp = value;
        }
    }

    public void ExpCheck()
    {
        if (Exp >= 10)
        {
            Stat += 1;
        }
    }

    public BasePlayer()
    {
        int rnd = Random.Range(1, 11);
        if (rnd <= 7)
        {
            Rarity = rarityList[0];
        }
        else if (rnd > 7 && rnd < 10)
        {
            Rarity = rarityList[1];
        }
        else
        {
            Rarity = rarityList[2];
        }

        for (int i = 0; i < rarityList.Length; i++)
        {
            if (Rarity == rarityList[i])
            {
                Stat = Random.Range((i + 2) * (i + 1), (i + 4) * (i + 1));
            }
        }
    }
}
