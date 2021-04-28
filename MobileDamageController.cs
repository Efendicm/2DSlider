using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MobileDamageController : MonoBehaviour
{
    [SerializeField] private float SpikeDamage;
    [SerializeField] private PlayerHealth healthcontroller;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("player"))
        {
            Damage();
        }
    }
    void Damage()
    {
        healthcontroller.playerHealth = healthcontroller.playerHealth - SpikeDamage;
        healthcontroller.updateHealth();

    }
}
