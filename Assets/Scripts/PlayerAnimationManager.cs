using UnityEngine;

public class PlayerAnimationManager : MonoBehaviour
{
    private float horizontalVelocity;
    private float verticalVelocity;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalVelocity = GetComponent<PlayerController>().movement.x;
        verticalVelocity = GetComponent<PlayerController>().movement.y;
        GetComponent<Animator>().SetFloat("HVel", horizontalVelocity);
        GetComponent<Animator>().SetFloat("VVel", verticalVelocity);
    }
}
