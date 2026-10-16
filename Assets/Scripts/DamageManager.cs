using System;
using UnityEngine;

public class DamageManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
	if (collision.GetComponent<Attack>())
	{
	    int hit = collision.GetComponent<Attack>().damage;
	    gameObject.GetComponentInParent<PlayerMaster>().statLine.changeHP(-hit);
	    Debug.Log($"{hit} damage taken!");
	    gameObject.GetComponentInParent<PlayerMaster>().HPBar.fillAmount = (float)gameObject.GetComponentInParent<PlayerMaster>().statLine.getHP() / 100;
	}
    }
}
