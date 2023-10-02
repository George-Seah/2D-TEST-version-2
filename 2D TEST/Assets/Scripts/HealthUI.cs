using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class HealthUI : MonoBehaviour
{
    TextMeshProUGUI healthComponent;
    // Start is called before the first frame update
    void Start()
    {
        healthComponent = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        healthComponent.text = $"{PlayerHealth.currentHealth}";
    }
}
