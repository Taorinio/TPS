using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public float Health = 100f;
    float maxValue;
    public RectTransform rect;
    public GameObject GameOverScreen;
    public GameObject GameplayUI;
    public GameObject PlayerModel;
    void Start()
    {
        maxValue = Health;
        DrawHealth();
    }

    public void DealDamage(float damage) {
        Health -= damage * Time.deltaTime;
        if (Health <= 0) {
            Die();
        }
        DrawHealth();
    }
    public void DrawHealth() {
        rect.anchorMax = new Vector2(Health / maxValue, 1);
    }

    void Die() {
        GameOverScreen.SetActive(true);
        GameplayUI.SetActive(false);
        GetComponent<PlayerController>().enabled = false;
    }
}