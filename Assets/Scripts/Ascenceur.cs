using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ascenceur : MonoBehaviour
{
    // Start is called before the first frame update
    DataInfo data;
    bool victory = true;
    void Start()
    {
        data = DataInfo.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("Player;");
            for(int i = 0; i < data.myListItems.Count; i++)
            {
                if (data.myListItems[i].GetComponent<Items>().isObligatoire == true)
                {
                    victory = false;
                    Debug.Log("pa sla victoire");
                }

            }

            if (victory)
            {
                data.level++;
                data.myListItems.Clear();
                data.isGenerate = false;
                data.cancer = 0.0f;
                data.boost = 0.0f;
                data.indexGenerateB = 0;
                data.indexGenerateO = 0;
                data.timertemp = 0.0f;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
               


            }


        }
    }
}
