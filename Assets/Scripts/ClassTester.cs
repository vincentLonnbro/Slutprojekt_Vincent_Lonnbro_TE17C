using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Threading;

public class ClassTester : MonoBehaviour
{
    [SerializeField]
    Text textStarting;

    [SerializeField]
    Text textOpposing;

    [SerializeField]
    Text counterText;

    [SerializeField]
    Text Goals;

    public static Teams startingFive = new Teams();
    public static Teams opposingFive = new Teams();

    

    public void Tester()
    {
        startingFive.TeamMaker();
        opposingFive.TeamMaker();

        textStarting.text = startingFive.PlayerShower();
        textOpposing.text = opposingFive.PlayerShower();
        counterText.text = startingFive.TeamScoreCalc().ToString() + "\n" + opposingFive.TeamScoreCalc().ToString();
    }

    static string PlayerShower(List<BasePlayer> team)
    {
        string returnVal = "";

        for (int i = 0; i < team.Count; i++)
        {
            returnVal += "Role: " + team[i].Role + "\nPosition: " + team[i].Position + "\nRarity: " + team[i].Rarity + "\nRating: " + team[i].Stat.ToString() + "\n\n";
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

    public void GameStarter()
    {
        int goalsStart = 0;
        int goalsOpp = 0;


        for (int i = 0; i < 90 + Random.Range(1, 7); i++)
        {
            if (startingFive.TeamScoreCalc() > opposingFive.TeamScoreCalc())
            {
                if (Game(startingFive.players, opposingFive.players, "StartingTeam"))
                {
                    goalsStart += 1;
                    Goals.text = goalsStart + " - " + goalsOpp;
                }
            }
            else
            {
                if (Game(opposingFive.players, startingFive.players, "OpposingTeam"))
                {
                    goalsOpp += 1;
                    Goals.text = goalsStart + " - " + goalsOpp;
                }
            }
            StartCoroutine(Timer(1));
        }
    }
    IEnumerator Timer(float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
    }

    private int TeamScoreCalc(List<BasePlayer> team)
    {
        int score = 0;
        for (int i = 0; i < team.Count; i++)
        {
            score += team[i].Stat;
        }
        score += Random.Range(1, 11);
        return score;
    }
    private bool Game(List<BasePlayer> attackingTeam, List<BasePlayer> defendingTeam, string teamName)
    {

        if (Random.Range(1, 101) < 35)
        {
            Debug.Log("Anfall " + teamName);

            if (DefenderCheck(PlayerChooser(defendingTeam[1], defendingTeam[2]), attackingTeam[3]))
            {
                if (GoalkeeperCheck(defendingTeam[0], attackingTeam[4]))
                {
                    Debug.Log("Mål");
                    return true;
                }
                else
                {
                    Debug.Log("Avslut");
                    return false;
                }
            }
            else
            {
                Debug.Log("Brytning försvarare");
                return false;
            }
        }
        else
        {
            Debug.Log("Inget anfall");
            return false;
        }

    }
    static BasePlayer PlayerChooser(BasePlayer p1, BasePlayer p2)
    {
        if (Random.Range(0, 2) == 1)
        {
            return p1;
        }
        else
        {
            return p2;
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
