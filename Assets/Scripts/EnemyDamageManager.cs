using UnityEngine;

public class EnemyDamageManager : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
	if (collision.GetComponent<Attack>())
	{
	    int hit = collision.GetComponent<Attack>().damage;
	    gameObject.GetComponentInParent<EnemyStatMaster>().statLine.changeHP(-hit);
	    Debug.Log($"{hit} damage dealt!");
	    if (gameObject.GetComponentInParent<EnemyStatMaster>().statLine.getHP() == 0)
	    {
		GameObject.Destroy(GetComponentInParent<SpriteRenderer>().gameObject);
	    }
	}
    }
}
