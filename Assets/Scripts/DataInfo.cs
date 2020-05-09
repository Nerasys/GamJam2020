using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataInfo : MonoBehaviour
{
    // Start is called before the first frame update

    private static DataInfo instance;

    public int score;
    public int scoreByItems = 10;

    [SerializeField]
    public float cancer;
    [SerializeField]
    public float cancerMax;


    [SerializeField]
    public float boost;
    [SerializeField]
    public float boostMax;

    [SerializeField]
    public float cancerBoost;

    [SerializeField]
    public float regenBoost;

    [SerializeField]
    public float DegatsIA;

    [SerializeField]
    public float DistanceDegatsIA;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    public static DataInfo GetInstance()
    {
        return instance;
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        BoostRegen();
        CancerRegen();
    }


    void BoostRegen()
    {
        if(boost < boostMax)
        {
            boost += Time.deltaTime * regenBoost;
        }
    }

    void CancerRegen()
    {
        if (cancer < cancerMax)
        {
            cancer += Time.deltaTime * cancerBoost;
        }
    }

}
