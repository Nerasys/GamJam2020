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
            for(int i = 0; i < data.myListItems.Count; i++)
            {
                if (data.myListItems[i].GetComponent<Items>().isObligatoire == true)
                {
                    victory = false;
                }

            }

            if (victory)
            {
                data.level++;
                data.myListItems.Clear();
                data.isGenerate = false;
                SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            }


        }
    }
}
