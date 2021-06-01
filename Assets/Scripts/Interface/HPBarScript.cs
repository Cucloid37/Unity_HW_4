using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPBarScript : MonoBehaviour
{
    [SerializeField] private Slider slider;
    [SerializeField] private PickUp healthUI;

    public float ValueSlider => slider.value;

    private void Update()
    {
        slider.value = healthUI.playerHealth;
    }
}
