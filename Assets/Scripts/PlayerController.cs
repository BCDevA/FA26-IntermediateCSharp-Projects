using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerControls playerControls;
    public float speed = 1;
    public Vector2 movement = Vector2.zero;
    public bool attack;
    public GameObject strike;

    private void Awake()
    {
	playerControls = new PlayerControls();
    }

    private void OnEnable()
    {
	playerControls.Enable();
    }

    private void OnDisable()
    {
	playerControls.Disable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    private void Update()
    {
	movement = playerControls.Player.Move.ReadValue<Vector2>();
	this.GetComponent<Rigidbody2D>().linearVelocity = movement * speed;
	if (!attack)
	{
	    if (playerControls.Player.Attack.inProgress)
	    {
		attack = true;
		StartCoroutine(Strike());
	    }
	}
    }

    private IEnumerator Strike()
    {
	strike.SetActive (true);
	GetComponent<Animator>().SetTrigger("Damage");
	yield return new WaitForSecondsRealtime(0.67f);
	attack = false;
	GetComponent<Animator>().ResetTrigger("Damage");
	strike.SetActive (false);
    }
}
