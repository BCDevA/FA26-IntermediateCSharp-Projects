using UnityEngine;
using UnityEngine.SceneManagement;

public class Win_Script : MonoBehaviour
{
    [Header("Should be on Player")]
    //public bool DidPlayerGetToEnd = false;

    [Tooltip("Which Object are you going to enable: ")]
    public GameObject ObjectToEnable; //should be object with a scene controller



    void OnTriggerEnter2D(Collider2D collision)
    {



        if (collision.CompareTag("Exit_Door"))
        {
            //DidPlayerGetToEnd = true;
            ObjectToEnable.SetActive(true);
            //ObjectToEnable.GetComponent<SpriteRenderer>().enabled = true;
            Debug.Log("Player entered win zone");

        }


    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Exit_Door"))
        {
            //DidPlayerGetToEnd = true;
            ObjectToEnable.SetActive(false);
            //ObjectToEnable.GetComponent<SpriteRenderer>().enabled = true;
            Debug.Log("Player exited win zone");

        }




    }
}
