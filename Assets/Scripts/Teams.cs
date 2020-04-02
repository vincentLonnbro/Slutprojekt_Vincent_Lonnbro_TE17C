using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;


public class Teams
{
    public List<BasePlayer> players = new List<BasePlayer>();
    public void TeamMaker()
    {
        players.Clear();
        players.Add(new Goalkeeper());
        players.Add(new Defender());
        players.Add(new Defender());
        players.Add(new Midfielder());
        players.Add(new Striker());
    }

    public string PlayerShower()
    {
        string returnVal = "";

        for (int i = 0; i < players.Count; i++)
        {
            returnVal += "Role: " + players[i].Role + "\nPosition: " + players[i].Position + "\nRarity: " + players[i].Rarity + "\nRating: " + players[i].Stat.ToString() + "\n\n";
        }
        return returnVal;
    }

    public int TeamScoreCalc()
    {
        int score = 0;
        for (int i = 0; i < players.Count; i++)
        {
            score += players[i].Stat;
        }
        return score;
    }

}

