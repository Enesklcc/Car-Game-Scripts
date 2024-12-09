using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followCamera : MonoBehaviour
{
    //takip edicek þeyi(kameramýzý) belirtmek için gameobject oluþturduk
    [SerializeField] GameObject thingToFollow;
    void Start()
    {
        
    }

    
    void LateUpdate()
    {
        transform.position = thingToFollow.transform.position + new Vector3(0, 0, -5);
    }
}
