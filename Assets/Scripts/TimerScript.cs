using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour
{

    // DETTA HAR JAG INTE GJORT. HAR DOCK GJORT NÅGRA FÖRÄNDRINGAR!

    [SerializeField]
    private Text timerText;
    [SerializeField]
    private float timerCount;

    private float timer;
    private bool canCount = true;
    private bool doOnce = false;

    void Start()
    {
        timer = timerCount;    
    }

    void Update()
    {
        if (timer <= 90.0f && canCount)
        {
            timer += Time.deltaTime;
            timerText.text = timerCount.ToString("F");
        }

        else if (timerCount >= 90.0f && !doOnce)
        {
            canCount = false;
            doOnce = true;
            timerText.text = "90.00";
            timer = 0.0f;
        }
    }
}
