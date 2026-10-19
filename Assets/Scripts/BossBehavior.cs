using System.Collections;
using UnityEngine;
using Random = System.Random;

public class BossBehavior : MonoBehaviour
{
    private AudioSource musicMan;
    public AudioClip bossTheme;
    private GameObject player;
    private bool chasing = false;
    public float speed;
    private bool attackType;
    public GameObject projectile;
    public float projectileSpeed;
    private GameObject spell;
    private bool attacking = false;
    private Random rng = new Random();
    private float finder;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
	player = GameObject.Find("PlayerCharacter");
	musicMan = GameObject.Find("MusicMan").GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
	if(musicMan.clip == bossTheme && !chasing)
	{
	    chasing = true;
	    finder = rng.Next(0, 2);
	}
	else if(musicMan.clip != bossTheme)
	{
	    chasing = false;
	}
	if (chasing)
	{
	    if (finder == 0)
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
		if (distance.magnitude <= 1 && !attacking)
		{
		    chasing = false;
		    attacking = true;
		    if (rng.Next(0, 2) == 0)
		    {
			attackType = true;
		    }
		    else
		    {
			attackType = false;
		    }
		    StartCoroutine(AttackPhase());
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
		if (distance.magnitude <= 0.5f && !attacking)
		{
		    chasing = false;
		    attacking = true;
		    if (rng.Next(0, 2) == 0)
		    {
			attackType = true;
		    }
		    else
		    {
			attackType = false;
		    }
		    StartCoroutine(AttackPhase());
		}
	    }
	}
	else
	{

	}
    }

    private IEnumerator AttackPhase()
    {
	switch (attackType)
	{
	    case false:
		GetComponentInChildren<PolygonCollider2D>().enabled = true;
		GetComponent<Animator>().SetTrigger("Attack");
		yield return new WaitForSeconds(0.67f);
		GetComponent<Animator>().ResetTrigger("Attack");
		GetComponentInChildren<PolygonCollider2D>().enabled = false;
		break;
	    case true:
		spell = GameObject.Instantiate(projectile);
		spell.transform.position = Vector2.MoveTowards(transform.position, player.transform.position, 2);
		spell.GetComponent<Rigidbody2D>().linearVelocity = player.transform.position.normalized * projectileSpeed;
		GetComponent<Animator>().SetTrigger("Attack");
		yield return new WaitForSeconds(0.67f);
		GetComponent<Animator>().ResetTrigger("Attack");
		break;
	}
	attacking = false;
	chasing = true;
    }
}
