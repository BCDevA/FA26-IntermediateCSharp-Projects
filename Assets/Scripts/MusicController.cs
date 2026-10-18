using Unity.VisualScripting;
using UnityEngine;

public class MusicController : MonoBehaviour
{
    public AudioSource musicMan;
    public AudioClip peacefulMusic;
    public AudioClip act1Music;
    public AudioClip act2Music;
    public AudioClip act3Music;
    public AudioClip npcMusic;
    public AudioClip preludeMusic;
    public AudioClip bossMusic;
    private void OnTriggerEnter2D(Collider2D collision)
    {
	switch (tag)
	{
	    case "Peace":
		foreach (MusicController obj in GameObject.FindObjectsByType(typeof(MusicController)))
		{
		    if (obj.tag != "Peace")
		    {
			obj.GetComponent<BoxCollider2D>().enabled = true;
		    }
		    else
		    {
			obj.GetComponent<BoxCollider2D>().enabled = false;
		    }
		}
		musicMan.Stop();
		musicMan.PlayOneShot(peacefulMusic);
		musicMan.volume = 0.1f;
		musicMan.loop = true;
		break;
	    case "Act I":
		foreach (MusicController obj in GameObject.FindObjectsByType(typeof(MusicController)))
		{
		    if (obj.tag != "Act I")
		    {
			obj.GetComponent<BoxCollider2D>().enabled = true;
		    }
		    else
		    {
			obj.GetComponent<BoxCollider2D>().enabled = false;
		    }
		}
		musicMan.Stop();
		musicMan.PlayOneShot(act1Music);
		musicMan.volume = 0.1f;
		musicMan.loop = true;
		break;
	    case "Act II":
		foreach (MusicController obj in GameObject.FindObjectsByType(typeof(MusicController)))
		{
		    if (obj.tag != "Act II")
		    {
			obj.GetComponent<BoxCollider2D>().enabled = true;
		    }
		    else
		    {
			obj.GetComponent<BoxCollider2D>().enabled = false;
		    }
		}
		musicMan.Stop();
		musicMan.PlayOneShot(act2Music);
		musicMan.volume = 0.1f;
		musicMan.loop = true;
		break;
	    case "NPC Interact":
		foreach (MusicController obj in GameObject.FindObjectsByType(typeof(MusicController)))
		{
		    if (obj.tag != "NPC Interact")
		    {
			obj.GetComponent<BoxCollider2D>().enabled = true;
		    }
		    else
		    {
			obj.GetComponent<BoxCollider2D>().enabled = false;
		    }
		}
		musicMan.Stop();
		musicMan.PlayOneShot(npcMusic);
		musicMan.volume = 0.1f;
		musicMan.loop = true;
		break;
	    case "Prelude":
		foreach (MusicController obj in GameObject.FindObjectsByType(typeof(MusicController)))
		{
		    if (obj.tag != "Prelude")
		    {
			obj.GetComponent<BoxCollider2D>().enabled = true;
		    }
		    else
		    {
			obj.GetComponent<BoxCollider2D>().enabled = false;
		    }
		}
		musicMan.Stop();
		musicMan.PlayOneShot(preludeMusic);
		musicMan.volume = 0.1f;
		musicMan.loop = true;
		break;
	    case "Boss Fight":
		foreach (MusicController obj in GameObject.FindObjectsByType(typeof(MusicController)))
		{
		    if (obj.tag != "Boss Fight")
		    {
			obj.GetComponent<BoxCollider2D>().enabled = true;
		    }
		    else
		    {
			obj.GetComponent<BoxCollider2D>().enabled = false;
		    }
		}
		musicMan.Stop();
		musicMan.PlayOneShot(bossMusic);
		musicMan.volume = 0.1f;
		musicMan.loop = true;
		break;
	    default:
		foreach (MusicController obj in GameObject.FindObjectsByType(typeof(MusicController)))
		{
			obj.GetComponent<BoxCollider2D>().enabled = false;
		}
		musicMan.Stop();
		musicMan.PlayOneShot(act3Music);
		musicMan.volume = 0.1f;
		musicMan.loop = true;
		break;
	}
    }
}
