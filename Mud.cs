using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mud : MonoBehaviour
{
    //bal��k i�ine girince d���ce�i h�z� belirttik.
    [SerializeField] float slowFactor = 0.2f; 
    [SerializeField] float minSpeed = 0.005f;
    private bool isInMud = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        //player tagli objenin bal���a girmesi durumunda h�z�n� ayarlad�k
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
        //player tagli objenin bal��ktan ��kmas� durumunda h�z�n� ayarlad�k
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
        //player tagli objenin bal��kta kalmas� durumunda h�z�n� ayarlad�k
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
