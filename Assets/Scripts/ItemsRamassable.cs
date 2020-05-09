using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemsRamassable : MonoBehaviour
{
    ControlerPlayer cP;
    DataInfo dI;


    public int scoreGive = 10;


    void Start()
    {
        cP = ControlerPlayer.GetInstance();
        dI = DataInfo.GetInstance();
        cP.OnRamassable += UpdateScore;
        cP.OnRamassable += DestroyGameObject;


    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void UpdateScore()
    {
        dI.score = scoreGive;

    }

    void DestroyGameObject()
    {
        Destroy(gameObject);
    }



}
