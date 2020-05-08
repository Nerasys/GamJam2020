using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlerCamera : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform player;

    private bool isMove = false;
    float distancePC = 0.0f;
    float distanceToMoveCam = 5.0f;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
           
            distancePC = Mathf.Abs(transform.position.x - player.position.x);
            if(distanceToMoveCam < distancePC)
            {
               Debug.Log(Mathf.Lerp(player.position.x, transform.position.x, Time.deltaTime));
               transform.position = new Vector3(player.position.x, transform.position.y, transform.position.z);
            }
                
    }
}
