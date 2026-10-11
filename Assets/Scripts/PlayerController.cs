using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private PlayerControls playerControls;
    public float speed = 1;
    public Vector2 movement = Vector2.zero;

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
    }
}
