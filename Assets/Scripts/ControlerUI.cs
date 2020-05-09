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


    private float timerCal =0.0f;
    private int timeFinal = 0;

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
        timeFinal = (int)timerCal;
        timer.text = timeFinal.ToString();
    }

    private void UpdateScore()
    {
        score.text = dI.score.ToString();
    }
}
