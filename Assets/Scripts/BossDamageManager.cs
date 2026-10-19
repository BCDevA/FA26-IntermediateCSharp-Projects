using UnityEngine;

public class BossDamageManager : MonoBehaviour
{
    public AudioSource musicMan;
    public AudioClip finalAct;

    private void OnTriggerEnter2D(Collider2D collision)
    {
	if (collision.GetComponent<Attack>())
	{
	    if (!collision.GetComponent<Animator>())
	    {
		int hit = collision.GetComponent<Attack>().damage;
		gameObject.GetComponentInParent<EnemyStatMaster>().statLine.changeHP(-hit);
		Debug.Log($"{hit} damage dealt!");
		if (gameObject.GetComponentInParent<EnemyStatMaster>().statLine.getHP() == 0)
		{
		    foreach (MusicController obj in GameObject.FindObjectsByType(typeof(MusicController)))
		    {
			if (obj.tag == "Boss Fight")
			{
			    obj.tag = "Final Act";
			    obj.GetComponent<BoxCollider2D>().enabled = true;
			}
			else
			{
			    if(obj.transform.position.y < 20)
			    {
				obj.GetComponent<BoxCollider2D>().enabled = false;
			    }
			}
		    }
		    musicMan.Stop();
		    musicMan.resource = finalAct;
		    musicMan.Play();
		    musicMan.volume = 0.1f;
		    musicMan.loop = true;
		    GameObject.Destroy(GetComponentInParent<SpriteRenderer>().gameObject);
		}
	    }
	}
    }
}
