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
        dI.timerCal += Time.deltaTime;
        dI.timeSecond = (int)dI.timerCal;

        if (dI.timeSecond > 59)
        {
            dI.timeSecond -= 60;
            dI.timerCal -= 60;
            dI.timeMinute += 1;
        }
        if (dI.timeMinute < 10)
        {
            if (dI.timeSecond < 10)
            {
                timer.text = " 0" + dI.timeMinute.ToString() + " : 0" + dI.timeSecond.ToString();
            }
            else
            {
                timer.text = " 0" + dI.timeMinute.ToString() + " : " + dI.timeSecond.ToString();
            }

        }
        else
        {
            if (dI.timeSecond < 10)
            {
                timer.text = dI.timeMinute.ToString() + " : 0" + dI.timeSecond.ToString();
            }
            else
            {
                timer.text = dI.timeMinute.ToString() + ": " + dI.timeSecond.ToString();
            }

        }
    }

    private void UpdateScore()
    {
        score.text = dI.score.ToString();
    }
}
