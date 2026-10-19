using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerMaster : MonoBehaviour
{
    public CharacterStats statLine;
    [Tooltip("Health max(int):")]
    public int maxHP = 100;
    [Tooltip("Attack stat(int):")]
    public int ATK = 5;
    public UnityEngine.UI.Image HPBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        statLine = new CharacterStats(maxHP, ATK);
    }

    private void OnEnable()
    {
	GetComponentInChildren<Attack>().damage = ATK;
	GetComponentInChildren<Attack>().gameObject.SetActive(false);
    }

    private void Update()
    {
    }
}
