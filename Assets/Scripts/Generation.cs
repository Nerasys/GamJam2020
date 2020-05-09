using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generation : MonoBehaviour
{
    // Start is called before the first frame update
    private static Generation instance;

    public List<GameObject> walls = new List<GameObject>();

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

        DontDestroyOnLoad(this.gameObject);
    }

    public static Generation GetInstance()
    {
        return instance;
    }
    // Update is called once per frame



    private void Start()
    {
        int random = Random.Range(0, 3);



    }
}
