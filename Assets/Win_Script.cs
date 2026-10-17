using UnityEngine;
using UnityEngine.SceneManagement;

public class Win_Script : MonoBehaviour
{
    [Header("Should be on the object at exit")]
    //public bool DidPlayerGetToEnd = false;

    [Tooltip("Scene to change too(Index): ")]
    public int SceneIndex;
   
   
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            //DidPlayerGetToEnd = true;

            ScreenController.screenController.GoToSpecificScene(SceneIndex);

        }


      
    }
}
