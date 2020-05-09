using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataInfo : MonoBehaviour
{
    // Start is called before the first frame update

    private static DataInfo instance;

    public int score;

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
        
    }
}
