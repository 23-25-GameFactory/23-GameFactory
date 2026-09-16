using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHPViewer : MonoBehaviour
{
   [SerializeField]
    public PlayerHP playerHP; // public으로 선언

    private Slider sliderHP;

    private void Awake()
    {
        sliderHP = GetComponent<Slider>();
    }

    private void Update()
    {
        sliderHP.value = playerHP.CurrentHP / playerHP.MaxHP;
    }
}