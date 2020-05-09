using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ControlerIA : MonoBehaviour
{
    [SerializeField] GameObject player;
    NavMeshAgent nMA;
    // Start is called before the first frame update
    void Start()
    {
        nMA = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        nMA.destination = player.transform.position;
    }
}
