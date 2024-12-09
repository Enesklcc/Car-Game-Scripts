using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mud : MonoBehaviour
{
    //balçýk içine girince düþüceði hýzý belirttik.
    [SerializeField] float slowFactor = 0.2f; 
    [SerializeField] float minSpeed = 0.005f;
    private bool isInMud = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        //player tagli objenin balçýða girmesi durumunda hýzýný ayarladýk
        if (other.tag == "Player")
        {
            driver driver = other.GetComponent<driver>();
            if (driver != null)
            {
                driver.ModifySpeed(slowFactor, minSpeed);
            }
        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        //player tagli objenin balçýktan çýkmasý durumunda hýzýný ayarladýk
        if (other.tag == "Player")
        {
            driver driver = other.GetComponent<driver>();
            if (driver != null)
            {
                driver.ResetSpeed();
            }
        }
    }
    void OnTriggerStay2D(Collider2D other)
    {
        //player tagli objenin balçýkta kalmasý durumunda hýzýný ayarladýk
        if (isInMud && other.tag == "Player")
        {
            driver driver = other.GetComponent<driver>(); 
            if (driver != null)
            {
                driver.ModifySpeed(slowFactor, minSpeed);
            }
        }
    }
}
