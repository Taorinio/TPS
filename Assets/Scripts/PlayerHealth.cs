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
    public Animator animator;
    public Animator go;
    public FireballCaster Caster;

    void Start()
    {
        Caster = Caster.GetComponent<FireballCaster>();
        maxValue = Health;
        DrawHealth();
    }
    public void DealDamage(float damage) {
        Health -= damage;
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
        go.SetTrigger("Show");
        GetComponent<PlayerController>().enabled = false;
        GetComponent<CameraRotation>().enabled = false;
        Caster.enabled = false;
        animator.SetTrigger("Die");
    }
    public void Heal(float Strength) {
        Health += Strength;
        Health = Mathf.Clamp(Health, 0, maxValue);
        DrawHealth();
    }
}