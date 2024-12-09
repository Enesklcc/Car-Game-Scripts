using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExp : MonoBehaviour
{
    //hasar ve effect i�in de�i�kenler tan�mlad�k
    [SerializeField] int damage = 20;
    [SerializeField] GameObject explosionEffect;
    [SerializeField] float explosionInterval = 3f;
    [SerializeField] float playerDamageWindow = 0.5f;
    private bool isExploding = false;

    void Start()
    {
        StartCoroutine(ContinuousExplode());
    }
    IEnumerator ContinuousExplode()
    {
        //belirli aral�klarla bomban�n patlamas� i�in d�ng�ye ald�k
        while (true)
        {
            yield return StartCoroutine(Explode());
            yield return new WaitForSeconds(explosionInterval);
        }
    }
    IEnumerator Explode()
    {
        //bomba patlay�nca effect g�z�kmesi ve durumlar� ayarlad�k
        isExploding = true;
        GameObject explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(playerDamageWindow);
        isExploding = false;
        Destroy(explosion);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //player tagli objenin bomba patlad���nda hasar almas�n� tan�mlad�k
        if (isExploding && other.CompareTag("Player"))
        {
            driver driver = other.GetComponent<driver>();
            if (driver != null)
            {
                driver.TakeDamage(damage);
            }
        }
    }


}