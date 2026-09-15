using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SOIntUpdate : MonoBehaviour
{
    public SOInt soInt;
    public TextMeshProUGUI text;

    // Initialize the displayed value.
    public void Start()
    {
        text.text = soInt.value.ToString();
    }

    // Keep the displayed value synchronized with the Scriptable Object.
    public void Update()
    {
        text.text = soInt.value.ToString();
    }
}