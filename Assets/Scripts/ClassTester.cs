using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class ClassTester : MonoBehaviour
{
    [SerializeField]
    Text textStarting;

    [SerializeField]
    Text textOpposing;

    [SerializeField]
    Text counterText;

    static List<BasePlayer> startingFive = new List<BasePlayer>();
    static List<BasePlayer> opposingFive = new List<BasePlayer>();


    public void Tester()
    {
        startingFive.Clear();
        opposingFive.Clear();
        PlayerListSetter(startingFive);
        PlayerListSetter(opposingFive);

        textStarting.text = PlayerShower(startingFive);
        textOpposing.text = PlayerShower(opposingFive);
    }

    static string PlayerShower(List<BasePlayer> team)
    {
        string returnVal = "";

        for (int i = 0; i < team.Count; i++)
        {
            returnVal += "Role: " +  team[i].Role + "\nPosition: " + team[i].Position + "\nRarity: " + team[i].Rarity + "\nRating: " + team[i].Stat + "\n\n";
        }
        return returnVal;
    }
    static void PlayerListSetter(List<BasePlayer> team)
    {
        team.Add(new Goalkeeper());
        team.Add(new Defender());
        team.Add(new Defender());
        team.Add(new Midfielder());
        team.Add(new Striker());
    }

    public void Game()
    {
        Debug.Log("HALLÅ");
        for (int i = 0; i < 90; i++)
        {
            if (MidfielderCheck(opposingFive[3], PlayerChooser(startingFive[1], startingFive[2])))
            {
                if (DefenderCheck(PlayerChooser(opposingFive[1], opposingFive[2]), startingFive[3]))
                {
                    if (GoalkeeperCheck(opposingFive[0], startingFive[4]))
                    {
                        Debug.Log("Mål" + (i + 1));
                    }
                    else
                    {
                        Debug.Log("Avslut");
                    }
                }
                else
                {
                    Debug.Log("Brytning försvarare");
                }
            }
            else
            {
                Debug.Log("Brytning MIttfältare");
            }
        }
    }
    static BasePlayer PlayerChooser(BasePlayer p1, BasePlayer p2)
    {
        if (Random.Range(0,2) == 1)
        {
            return p1;
        }
        else
        {
            return p2;
        }
    }
    static bool MidfielderCheck(BasePlayer defending, BasePlayer attacker)
    {
        if (defending.Stat + Random.Range(3, 10) > attacker.Stat + Random.Range(3, 10))
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    static bool DefenderCheck(BasePlayer defending, BasePlayer attacker)
    {
        if (defending.Stat + Random.Range(3, 10) > attacker.Stat + Random.Range(3, 10))
        {
            return false;
        }
        else
        {
            return true;
        }
    }
    static bool GoalkeeperCheck(BasePlayer defending, BasePlayer attacker)
    {
        if (defending.Stat + Random.Range(3, 10) > attacker.Stat + Random.Range(3, 10))
        {
            return false;
        }
        else
        {
            return true;
        }
    }
}
