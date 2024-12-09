using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BombExp : MonoBehaviour
{
    //hasar ve effect için deðiþkenler tanýmladýk
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
        //belirli aralýklarla bombanýn patlamasý için döngüye aldýk
        while (true)
        {
            yield return StartCoroutine(Explode());
            yield return new WaitForSeconds(explosionInterval);
        }
    }
    IEnumerator Explode()
    {
        //bomba patlayýnca effect gözükmesi ve durumlarý ayarladýk
        isExploding = true;
        GameObject explosion = Instantiate(explosionEffect, transform.position, Quaternion.identity);
        yield return new WaitForSeconds(playerDamageWindow);
        isExploding = false;
        Destroy(explosion);
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //player tagli objenin bomba patladýðýnda hasar almasýný tanýmladýk
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