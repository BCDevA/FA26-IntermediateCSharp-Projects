using System.Collections;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    private GameObject player;
    private bool chasing = false;
    public float aggroDistance;
    public float attackFrequency;
    public float speed;
    public float attackRange;
    public bool attackType;
    public GameObject projectile;
    public float projectileSpeed;
    private GameObject spell;
    private bool attacking;
    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("PlayerCharacter");

    }

    // Update is called once per frame
    void FixedUpdate()
    {
	if (!chasing)
	{
	    Vector2 distance = new Vector2(
	transform.position.x - player.transform.position.x,
	transform.position.y - player.transform.position.y);
	    if (distance.magnitude <= aggroDistance)
	    {
		chasing = true;
	    }
	}
	else
	{
	    if (Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime).x > transform.position.x + 0.05)
	    {
		GetComponent<Animator>().SetFloat("HVel", 1);
	    }
	    else if (Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime).x < transform.position.x - 0.05)
	    {
		GetComponent<Animator>().SetFloat("HVel", -1);
	    }
	    else
	    {
		GetComponent<Animator>().SetFloat("HVel", 0);
	    }

	    if (Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime).y > transform.position.y + 0.05)
	    {
		GetComponent<Animator>().SetFloat("VVel", 1);
	    }
	    else if (Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime).y < transform.position.y - 0.05)
	    {
		GetComponent<Animator>().SetFloat("VVel", -1);
	    }
	    else
	    {
		GetComponent<Animator>().SetFloat("VVel", 0);
	    }
	    transform.position = Vector2.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
	    Vector2 distance = new Vector2(
	transform.position.x - player.transform.position.x,
	transform.position.y - player.transform.position.y);
	    if (distance.magnitude <= attackRange && !attacking)
	    {
		attacking = true;
		StartCoroutine(enemyAttack());
	    }
	}
    }

    private IEnumerator enemyAttack()
    {
	switch (attackType)
	{
	    case false:
		GetComponentInChildren<CircleCollider2D>().enabled = true;
		GetComponent<Animator>().SetTrigger("Attack");
		yield return new WaitForSeconds(0.67f);
		GetComponent<Animator>().ResetTrigger("Attack");
		GetComponentInChildren<CircleCollider2D>().enabled = false;
		break;
	    case true:
		spell = GameObject.Instantiate(projectile);
		spell.transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 1);
		spell.GetComponent<Rigidbody2D>().linearVelocity = player.transform.position.normalized * projectileSpeed;
		GetComponent<Animator>().SetTrigger("Attack");
		yield return new WaitForSeconds(0.67f);
		GetComponent<Animator>().ResetTrigger("Attack");
		break;
	}
	attacking = false;
	yield return new WaitForSeconds(attackFrequency);
    }
}
