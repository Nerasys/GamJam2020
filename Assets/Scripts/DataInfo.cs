using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataInfo : MonoBehaviour
{
    // Start is called before the first frame update

    private static DataInfo instance;
    public int level = 0;
    public int numberObjectInit = 3;
    public int numberObjectFalcu = 3;

    public int score;
    

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

    [SerializeField]
    public List<GameObject> myListItems = new List<GameObject>();

    [SerializeField]
    List<GameObject> prefabsCourse = new List<GameObject>();


   public bool isGenerate = false;

    private void Awake()
    {

        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this.gameObject);
        }
        
        DontDestroyOnLoad(this.gameObject);
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
        if (!isGenerate)
        {
            GenerateItems();
            Debug.Log(level);
            isGenerate = true;
        }
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
            cancer += Time.deltaTime * cancerBoost ;
        }
    }






    void GenerateItems()
    {
        List<int> temp = new List<int>();
        int number;
        bool isGood;
        for (int i = 0; i < numberObjectInit + level; i++)
        {
      
            do
            {
                isGood = true;
                number = Random.Range(0, prefabsCourse.Count);
                for (int j = 0; j < temp.Count; j++)
                {
                    if (number == temp[j])
                    {
                        isGood = false;
                    }
                }
            } while (isGood == false);
            temp.Add(number);
            prefabsCourse[number].GetComponent<Items>().isObligatoire = true;
            myListItems.Add(prefabsCourse[number]);


        }
           for (int i = 0; i < numberObjectFalcu + level; i++)
           {
               isGood = true;
               do
               {
                   isGood = true;
                   number = Random.Range(0, prefabsCourse.Count);
                   for (int j = 0; j < temp.Count; j++)
                   {
                       if (number == temp[j])
                       {
                           isGood = false;
                       }
                   }
               } while (isGood == false);
               temp.Add(number);
               prefabsCourse[number].GetComponent<Items>().isObligatoire = false;
               myListItems.Add(prefabsCourse[number]);
             
           }



    
    }
}
