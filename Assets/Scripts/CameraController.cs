using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject playerObject;

    // Update is called once per frame
    void Update()
    {
        GetComponent<Transform>().position = new Vector3(playerObject.GetComponent<Transform>().position.x, playerObject.GetComponent<Transform>().position.y, GetComponent<Transform>().position.z);
    }
}
