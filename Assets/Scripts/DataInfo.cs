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
    public bool death = false;

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


    [SerializeField]
    GameObject canvasEndGame;


    public bool isGenerate = false;


    public GameObject roomA;
    public GameObject roomB;
    public GameObject roomC;
    public GameObject roomD;

    GameObject item;

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
        if (boost < boostMax)
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


    void Death()
    {
        if (cancerMax <= cancer)
        {
            death = true;
        }

        if (death)
        {

            if (PlayerPrefs.GetInt("scoreMax") < score)
            {
                PlayerPrefs.SetInt("scoreMax", score);

            }


        }
    }

    struct SpawnItem
    {
        public int room;
        public int spawn;

    }




    void GenerateItems()
    {
        List<int> temp = new List<int>();
        int number;
        bool isGood;
        for (int i = 0; i < numberObjectInit; i++)
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
        for (int i = 0; i < numberObjectFalcu; i++)
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

        Debug.Log(myListItems.Count);
        for (int i = 0; i < myListItems.Count; i++)
        {
            List<SpawnItem> tempSpawn = new List<SpawnItem>();
            bool isGood2;
            SpawnItem spawn = new SpawnItem();
            do
            {
                isGood2 = true;
                int randomRoom = Random.Range(0, 4);
                int randomItemsSpawn = Random.Range(1, 11);
                spawn.room = randomRoom;
                spawn.spawn = randomItemsSpawn;

                for (int j = 0; j < tempSpawn.Count; j++)
                {
                    if (spawn.room == tempSpawn[j].room)
                    {
                        if (spawn.spawn == tempSpawn[j].spawn)
                        {
                            isGood2 = false;
                        }
                    }
                }


            } while (!isGood2);

           switch (spawn.room)
            {
                 case 0:
                     for (int k = 0; k< roomA.transform.childCount; k++)
                     {
                         if (roomA.transform.GetChild(k).gameObject.activeSelf)
                         {
                            item = Instantiate(myListItems[i],roomA.transform.GetChild(i).Find("Spawn_Item_"+ spawn.spawn.ToString()).transform.position, Quaternion.identity);
                         }
                     }
                    break;
                 case 1:
                    for (int k = 0; k < roomB.transform.childCount; k++)
                    {
                        if (roomB.transform.GetChild(k).gameObject.activeSelf)
                        {
                            item = Instantiate(myListItems[i], roomB.transform.GetChild(i).Find("Spawn_Item_" + spawn.spawn.ToString()).transform.position, Quaternion.identity);
                        }
                    }
                    break;
                case 2:
                    for (int k = 0; k < roomC.transform.childCount; k++)
                    {
                        if (roomC.transform.GetChild(k).gameObject.activeSelf)
                        {
                            item = Instantiate(myListItems[i], roomC.transform.GetChild(i).Find("Spawn_Item_" + spawn.spawn.ToString()).transform.position, Quaternion.identity);
                        }
                    }
                    break;
                case 3:
                    for (int k = 0; k < roomD.transform.childCount; k++)
                    {
                        if (roomD.transform.GetChild(k).gameObject.activeSelf)
                        {
                            item = Instantiate(myListItems[i], roomD.transform.GetChild(i).Find("Spawn_Item_" + spawn.spawn.ToString()).transform.position, Quaternion.identity);
                        }
                    }
                    break;


            }
        }


    }
   
}
