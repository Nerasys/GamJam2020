using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ControlerIA : MonoBehaviour
{
    [SerializeField] GameObject player;
    NavMeshAgent nMA;
    DataInfo dI;


    // Start is called before the first frame update
    void Start()
    {
        nMA = GetComponent<NavMeshAgent>();
        dI = DataInfo.GetInstance();
    }

    // Update is called once per frame
    void Update()
    {
        nMA.destination = player.transform.position; 
        if(nMA.remainingDistance < dI.DistanceDegatsIA)
        {
            Degats(dI.DegatsIA);
        }

    }


    public void Degats(float dgt)
    {
        FindObjectOfType<AudioManager>().Play("TouxH1");
        dI.cancer += dgt;
    }
}
