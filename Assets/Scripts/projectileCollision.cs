using UnityEngine;

public class projectileCollision : MonoBehaviour
{

    private void OnCollisionEnter2D(Collision2D collision)
    {
	GameObject.Destroy(gameObject);
    }
}
