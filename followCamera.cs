using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCamera : MonoBehaviour
{
    //takip edicek �eyi(kameram�z�) belirtmek i�in gameobject olu�turduk
    [SerializeField] GameObject thingToFollow;
    void Start()
    {
        
    }

    
    void LateUpdate()
    {
        transform.position = thingToFollow.transform.position + new Vector3(0, 0, -5);
    }
}
