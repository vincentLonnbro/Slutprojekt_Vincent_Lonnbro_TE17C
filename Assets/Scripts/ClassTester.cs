using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClassTester : MonoBehaviour
{
    [SerializeField]
    Text TestText;


    

    // Start is called before the first frame update
    void Start()
    {
        


        BasePlayer test = new StrikerPlayer();

        TestText.text = "Position: " + test.Position + "\nRarity: " + test.Rarity + "\nRating: " + test.Stat;  
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
