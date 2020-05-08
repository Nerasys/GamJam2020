using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlerCamera : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] Transform transformVirtual;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transformVirtual.position = transform.position;
    }
}
