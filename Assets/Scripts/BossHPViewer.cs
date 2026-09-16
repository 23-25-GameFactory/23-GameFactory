using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BossHPViewer : MonoBehaviour
{
   [SerializeField]
    public BossHP bossHP; // public으로 선언

    private Slider sliderHP;

    public void Setup(BossHP bossHP)
    {
        this.bossHP = bossHP;
        sliderHP = GetComponent<Slider>();
    }

    /*private void Awake()
     {
         sliderHP = GetComponent<Slider>();
     }*/

     private void Update()
     {
        sliderHP.value = bossHP.CurrentHP / bossHP.MaxHP;
     }

}