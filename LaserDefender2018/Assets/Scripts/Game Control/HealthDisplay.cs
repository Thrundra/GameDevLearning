using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class HealthDisplay : MonoBehaviour {

    TextMeshProUGUI healthText;
    Player playerObject;

    private void Start()
    {
        healthText = GetComponent<TextMeshProUGUI>();
        playerObject = FindObjectOfType<Player>();
    }

    private void Update()
    {
        healthText.text = playerObject.GetHealth().ToString();
    }
}
