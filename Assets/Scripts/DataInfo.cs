using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DataInfo : MonoBehaviour
{
    // Start is called before the first frame update

    private static DataInfo instance;
    public float level = 1;

    public int numberObjectInit = 3;
    public int numberObjectFalcu = 3;

    public int score;
    public bool death = false;

    [SerializeField]
    public float cancer;
    [SerializeField]
    public float cancerMax;
    [SerializeField]
    public float multiplicator;

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
    public List<GameObject> prefabsCourse = new List<GameObject>();


    [SerializeField]
    public GameObject prefabsPNJ;

    [SerializeField] public GameObject canvasList;
    public int indexGenerateO;
    public int indexGenerateB;
    [SerializeField]
    public GameObject canvasEndGame;


    public bool isGenerate = false;

    public float timertemp = 0.0f;
    public GameObject roomA;
    public GameObject roomB;
    public GameObject roomC;
    public GameObject roomD;

    GameObject item;
    GameObject pnj;
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
        roomA = GameObject.Find("RNG_Room_A");
        roomB = GameObject.Find("RNG_Room_B");
        roomC = GameObject.Find("RNG_Room_C");
        roomD = GameObject.Find("RNG_Room_D");
        canvasEndGame = GameObject.Find("@CanvasEndGame");
        canvasList = GameObject.Find("Canvas").transform.GetChild(7).gameObject;
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


        if (timertemp > 1.0f)
        {
            if (!isGenerate)
            {



                if (roomA && roomB && roomC && roomD)
                {
                    GenerateItems();
                }
                else
                {
                    roomA = GameObject.Find("RNG_Room_A");
                    roomB = GameObject.Find("RNG_Room_B");
                    roomC = GameObject.Find("RNG_Room_C");
                    roomD = GameObject.Find("RNG_Room_D");
                    canvasEndGame = GameObject.Find("@CanvasEndGame");
                    canvasList = GameObject.Find("Canvas").transform.GetChild(7).gameObject;
                    GenerateItems();
                }
                isGenerate = true;
            }
            BoostRegen();
            CancerRegen();
            Death();
        }
        else
        {
            timertemp += Time.deltaTime;
        }
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
            cancer += Time.deltaTime * cancerBoost* (level* multiplicator);
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
            canvasEndGame.transform.GetChild(0).gameObject.SetActive(true);
            if (PlayerPrefs.GetInt("scoreMax") < score)
            {
                PlayerPrefs.SetInt("scoreMax", score);
                canvasEndGame.transform.GetChild(0).GetChild(4).GetComponent<Text>().text = score.ToString();
                canvasEndGame.transform.GetChild(0).GetChild(3).GetComponent<Text>().text = score.ToString();
            }
            else
            {
                canvasEndGame.transform.GetChild(0).GetChild(4).GetComponent<Text>().text = PlayerPrefs.GetInt("scoreMax").ToString();
                canvasEndGame.transform.GetChild(0).GetChild(3).GetComponent<Text>().text = score.ToString();
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
        roomA = GameObject.Find("RNG_Room_A");
        roomB = GameObject.Find("RNG_Room_B");
        roomC = GameObject.Find("RNG_Room_C");
        roomD = GameObject.Find("RNG_Room_D");
        canvasEndGame = GameObject.Find("@CanvasEndGame");
        canvasList = GameObject.Find("Canvas").transform.GetChild(7).gameObject;


        for (int j = 0; j < canvasList.transform.GetChild(3).childCount; j++)
        {
            canvasList.transform.GetChild(3).GetChild(j).gameObject.GetComponent<Text>().enabled =false;
        }

        for (int j = 0; j < canvasList.transform.GetChild(2).childCount; j++)
        {

            canvasList.transform.GetChild(2).GetChild(j).gameObject.GetComponent<Text>().enabled = false;
        }

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
        
            canvasList.transform.GetChild(2).GetChild(indexGenerateO).gameObject.GetComponent<Text>().enabled = true;
            canvasList.transform.GetChild(2).GetChild(indexGenerateO).GetComponent<Text>().text = "-" + prefabsCourse[number].GetComponent<Items>().name;
            indexGenerateO++;


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
            canvasList.transform.GetChild(3).GetChild(indexGenerateB).gameObject.GetComponent<Text>().enabled = true; 
            canvasList.transform.GetChild(3).GetChild(indexGenerateB).GetComponent<Text>().text = "-" + prefabsCourse[number].GetComponent<Items>().name;
            indexGenerateB++;
            myListItems.Add(prefabsCourse[number]); 
        }
        
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
            tempSpawn.Add(spawn);
            switch (spawn.room)
            {
                case 0:
                    for (int k = 0; k < roomA.transform.childCount; k++)
                    {
                        if (roomA.transform.GetChild(k).gameObject.activeSelf)
                        {
                            item = Instantiate(myListItems[i], roomA.transform.GetChild(i).Find("Spawn_Item_" + spawn.spawn.ToString()).transform.position, Quaternion.identity);
                            item.gameObject.name = myListItems[i].name;
                        }
                    }
                    break;
                case 1:
                    for (int k = 0; k < roomB.transform.childCount; k++)
                    {
                        if (roomB.transform.GetChild(k).gameObject.activeSelf)
                        {
                            item = Instantiate(myListItems[i], roomB.transform.GetChild(i).Find("Spawn_Item_" + spawn.spawn.ToString()).transform.position, Quaternion.identity);
                            item.gameObject.name = myListItems[i].name;
                        }
                    }
                    break;
                case 2:
                    for (int k = 0; k < roomC.transform.childCount; k++)
                    {
                        if (roomC.transform.GetChild(k).gameObject.activeSelf)
                        {
                            item = Instantiate(myListItems[i], roomC.transform.GetChild(i).Find("Spawn_Item_" + spawn.spawn.ToString()).transform.position, Quaternion.identity);
                            item.gameObject.name = myListItems[i].name;
                        }
                    }
                    break;
                case 3:
                    for (int k = 0; k < roomD.transform.childCount; k++)
                    {
                        if (roomD.transform.GetChild(k).gameObject.activeSelf)
                        {
                            item = Instantiate(myListItems[i], roomD.transform.GetChild(i).Find("Spawn_Item_" + spawn.spawn.ToString()).transform.position, Quaternion.identity);
                            item.gameObject.name = myListItems[i].name;
                        }
                    }
                    break;


            }

        }

    }
   
}
