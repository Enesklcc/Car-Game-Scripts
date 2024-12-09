using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Timeline.TimelinePlaybackControls;
using UnityEngine.UI;

public class driver : MonoBehaviour
{
    //h�z, can ve ui de�i�kenlerini tan�mlad�m
    [Header("Speed")]
    [SerializeField] float steerSpeed = 0.3f;
    [SerializeField] float moveSpeed = 0.014f;
    [SerializeField] float slowSpeed = 0.010f;
    [SerializeField] float boostSpeed = 0.020f;
    private float defaultSpeed;

    [Header("Health")]
    [SerializeField] int maxHealth = 100;
    private int currentHealth;


    [Header("UI References")]
    [SerializeField] int currentCoins = 0;
    [SerializeField] int totalCoins = 3;
    [SerializeField] Text coinText;
    [SerializeField] Image healthBackground;
    [SerializeField] Image healthForeground;
    void Start()
    {
        //ui elementlerini �a��rd�k, can ve h�z� ba�lang��taki de�ere e�itledik
        currentHealth = maxHealth;
        defaultSpeed = moveSpeed;
        UpdateCoinText();
        UpdateHealthUI();

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        //gameObject'in tagine g�re if yap�lar� yazd�k
        if (other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            currentCoins++;
            UpdateCoinText();

            if (currentCoins >= totalCoins)
            {
                Debug.Log("T�m coinleri toplad�n! Oyun bitti, Tebrikler.");
            }
        }
        if (other.tag == "boost")
        {
            moveSpeed = boostSpeed;
        }
        else if (other.tag == "bomb")
        {
            TakeDamage(10);
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        //bir yere �arpt���m�zda h�z�m�z� d���rd�k
        moveSpeed = slowSpeed;
    }

    void Update()
    {
     //can�m�z bitti�inde objemiz kayboluyor
        Movement();

        if (currentHealth <= 0)
        {
            Destroy(gameObject);
        }
    }

    void Movement()
    {
        //hareket y�nlerini kodlad�k
        float steerAmount = Input.GetAxis("Horizontal") * steerSpeed;
        float moveAmount = Input.GetAxis("Vertical") * moveSpeed;
        transform.Rotate(0, 0, -steerAmount);
        transform.Translate(0, moveAmount, 0);
    }

    public void TakeDamage(int damage)
    {
        //can�m�z�n azalmas� ve ui � g�ncellemek i�in kulland�k
        currentHealth -= damage;
        currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);

        Debug.Log($"Can De�eri: {currentHealth}");

        UpdateHealthUI();
    }
    public void ModifySpeed(float factor, float minSpeed)
    {
        moveSpeed *= factor;
        moveSpeed = Mathf.Max(moveSpeed, minSpeed);
    }
    public void ResetSpeed()
    {
        moveSpeed = defaultSpeed;
    }
    void UpdateCoinText()
    {
        coinText.text = $"Coin: {currentCoins}/{totalCoins}";

    }
    private void UpdateHealthUI()
    {
        float healthPercent = (float)currentHealth / maxHealth;

        healthForeground.rectTransform.localScale = new Vector3(healthPercent, 1, .5f);
    }
}