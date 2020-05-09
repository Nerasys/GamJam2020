using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsRamassable : MonoBehaviour
{
    ControlerPlayer cP;
    DataInfo dI;


    public int scoreGive = 10;
    public bool isObligatoire = true;


    void Start()
    {
        cP = ControlerPlayer.GetInstance();
        dI = DataInfo.GetInstance();
        cP.OnRamassable += UpdateScore;
     


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void UpdateScore()
    {
        dI.score = scoreGive;

    }





}
