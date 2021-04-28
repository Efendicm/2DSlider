using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public float playerHealth;
    [SerializeField] private Text HealthText;

    private void Start()
    {
        updateHealth();
    }

    public void updateHealth()
    {
        HealthText.text = playerHealth.ToString("0");
    }
}