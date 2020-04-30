using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Threading;

public class ClassTester : MonoBehaviour
{
    //Det här är det script där självaste *spelet* händer


    // Dessa används i Unity
    [SerializeField]    // Alla stat, rating, och position för ens "egna" lag
    Text textStarting;

    [SerializeField]    // Alla stat, rating och position för motståndarlager
    Text textOpposing;

    [SerializeField]    // Skulle användas för minuter, blev ej färdig med det.     
    Text counterText;

    [SerializeField]    // Används för att visa resultatet
    Text Goals;

    //public bool newGameIsh = false;

    public int goalsStart = 0;  // int för ens egna lag
    public int goalsOpp = 0;    // int för motståndarlaget

    public static Teams startingFive = new Teams(); // Skapar två nya instanser av klassen lag, ett eget och ett motståndarlag
    public static Teams opposingFive = new Teams(); 





    public void Tester()    // Den här metoden körs när man trycker på reroll knappen i spelet. Gör de två lagen och får ut dess data på skärmen
    {
        startingFive.TeamMaker(); // Kolla metoden
        opposingFive.TeamMaker();

        textStarting.text = startingFive.PlayerShower(); // Kolla metoden
        textOpposing.text = opposingFive.PlayerShower();
        counterText.text = startingFive.TeamScoreCalc().ToString() + "\n" + opposingFive.TeamScoreCalc().ToString(); // Kolla metoden
    }

    public void GameStarter()   // Spelar matchen. 
    {
        //counterText.text = startingFive.TeamScoreCalc().ToString() + "\n" + opposingFive.TeamScoreCalc().ToString();

        goalsOpp = 0;   // Dessa två föklaras ovanför
        goalsStart = 0;


        for (int i = 0; i < 90 + Random.Range(1, 7); i++)   // Loopen som spelar matchen egentligen. Körs en gång för varje minut i en match + 1-7 minuter (tillägstid)
        {
            if (startingFive.TeamScoreCalc() / 5 + Random.Range(1, 10) > opposingFive.TeamScoreCalc() / 5 + Random.Range(1, 10))  // Kollar vilket av lagen som ska få anfalla. Använder sig av en kvot av lagets poäng + ett random tal för att det inte ska vara så obalanserat. 
            {
                if (Game(startingFive.players, opposingFive.players, "StartingTeam"))   // Kolla Metoden Game(). Om Game() returnerar true var det ett anfall där det attackerande laget gjorde mål. Returneras false blev det inget mål och inget händer
                {
                    goalsStart += 1;
                    Goals.text = goalsStart + " - " + goalsOpp;
                }
            }
            else
            {
                if (Game(opposingFive.players, startingFive.players, "OpposingTeam"))   // ^^^^^
                {
                    goalsOpp += 1;
                    Goals.text = goalsStart + " - " + goalsOpp;
                }
            }


        }
    }

    private bool Game(List<BasePlayer> attackingTeam, List<BasePlayer> defendingTeam, string teamName)  // Får en lista av alla spelare i varje lag, ett som attackera och ett som försvarar, samt namnet på vilket lag som attackerar
    {

        if (Random.Range(1, 101) < 35)  // Räknade ut hur många anfall Premier Leagues bästa och sämsta lag hade och räknade sedan ut att det var ett anfall ungefär var tredje minut
        {
            Debug.Log("Anfall " + teamName);    // Bara för att jag ska veta vilket lag som attackerade. Skulle skrivas ut i spelet, men hann ej. 

            if (StatCheck(PlayerChooser(defendingTeam[1], defendingTeam[2]), attackingTeam[3])) // Väljer först en av det försvarandes lag två försvarare och mäter sedan dens stat i jämförelse med det anfallande lagets mittfältare
            {
                if (StatCheck(defendingTeam[0], attackingTeam[4]))  // Om mittfältaren tar sig förbi försvararna görs samma jämförelse med försvarande lagets målvakt och anfallande lagets striker
                {
                    Debug.Log("Mål");   
                    return true;        // Anfallande laget gjorde mål, därför returneras true
                }
                else
                {
                    Debug.Log("Avslut");
                    return false;       // Målvakten räddade, inget mål, därför returneras false
                }
            }
            else
            {
                Debug.Log("Brytning försvarare");
                return false;       // Försvararen bröt, inget mål, därför returneras false
            }
        }
        else
        {
            Debug.Log("Inget anfall");
            return false;       // Inget anfall, inget mål, därför returneras false
        }

    }
    static BasePlayer PlayerChooser(BasePlayer p1, BasePlayer p2)   // Metod som används för att välja en av två försvarare, väldigt enkel. Får två BasePlayers, skickar tillbaka en.  
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

    static bool StatCheck(BasePlayer defending, BasePlayer attacker)    // Används för att kolla vilken av två spelare som har högst stat, samt ge den spelaren exp om den vinner checken
    {
        if (defending.Stat + Random.Range(3, 10) > attacker.Stat + Random.Range(3, 10))     // För att det inte ska vara allt för obalanserat måste jag lägga till ett till värde som gör att den med lägre stat har chans att vinna
        {
            defending.ExpCheck(1);      // En metod som ger spelaren exp
            return false;
        }
        else
        {
            attacker.ExpCheck(1);       // ^^^^^^
            return true;
        }
    }
}
