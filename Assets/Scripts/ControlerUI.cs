using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlerUI : MonoBehaviour
{
    // Start is called before the first frame update
    DataInfo dI;
    [SerializeField] Image cancerImage;
    [SerializeField] Image boostImage;

    [SerializeField] Text score;
    [SerializeField] Text timer;


    private float timerCal = 0.0f;
    private int timeSecond = 0;
    private int timeMinute = 0;
    void Start()
    {
        dI = DataInfo.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateHealth();
        UpdateBoost();
        UpdateTimer();
        UpdateScore();
    }



    private void UpdateHealth()
    {
        dI.cancer = Mathf.Clamp(dI.cancer, 0, dI.cancerMax);
        float amount = (float)dI.cancer / dI.cancerMax;
        cancerImage.fillAmount = amount;
    }

    private void UpdateBoost()
    {
        dI.boost = Mathf.Clamp(dI.boost, 0, dI.boostMax);
        float amount = (float)dI.boost / dI.boostMax;
        boostImage.fillAmount = amount;
    }



    private void UpdateTimer()
    {
        timerCal += Time.deltaTime;
        timeSecond = (int)timerCal;

        if (timeSecond > 59)
        {
            timeSecond -= 60;
            timerCal -= 60;
            timeMinute += 1;
        }
        if (timeMinute < 10)
        {
            if (timeSecond < 10)
            {
                timer.text = " 0" + timeMinute.ToString() + " : 0" + timeSecond.ToString();
            }
            else
            {
                timer.text = " 0" + timeMinute.ToString() + " : " + timeSecond.ToString();
            }

        }
        else
        {
            if (timeSecond < 10)
            {
                timer.text = timeMinute.ToString() + " : 0" + timeSecond.ToString();
            }
            else
            {
                timer.text = timeMinute.ToString() + ": " + timeSecond.ToString();
            }

        }
    }

    private void UpdateScore()
    {
        score.text = dI.score.ToString();
    }
}
