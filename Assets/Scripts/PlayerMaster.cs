using System;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class PlayerMaster : MonoBehaviour
{
    public CharacterStats statLine;
    [Tooltip("Health max(int):")]
    public int maxHP;
    [Tooltip("Attack stat(int):")]
    public int ATK;
    public UnityEngine.UI.Image HPBar;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
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
