using UnityEngine;
using UnityEngine.SceneManagement;

//switches between scenes in unity
public class ScreenController : MonoBehaviour
{
    public static ScreenController screenController;

    [Tooltip("Current Scene Number:  ")]
    [SerializeField]
        public int CurrentSceneNum;
    [Tooltip("Game Over Scene(if applicable)?")]
    [SerializeField]
        public string GameOverScreen;
    [Tooltip("Name of Main Menu: ")]
    [SerializeField]
        public string MainMenuName;
    [Tooltip("Save File: ")]
    [SerializeField]
        public string file; 


    private void Awake()
    {
       Debug.Log("ScreenController is Awake");

        CurrentSceneNum = SceneManager.GetActiveScene().buildIndex;

        SceneManager.sceneLoaded += AfterBuildingScene;
    }
    public void GoToSpecificScene(int sceneIndex, string sceneName)
    {
        Debug.Log($"Loading scene {sceneName}...");
        SceneManager.LoadScene(sceneIndex);
    }
      
    public void GoToNextScene(int currentSceneNum)
    {
        int NextSceneNum = currentSceneNum + 1;
        SceneManager.LoadScene(NextSceneNum);
    }

    public void GoToMainMenu()
    {
        Debug.Log("Loaded Main Menu...");

       

        SceneManager.LoadScene(MainMenuName.ToString()); 

        
    }

    public void AfterBuildingScene(Scene scene, LoadSceneMode mode)
    {
        CurrentSceneNum = scene.buildIndex;
    }

    public void SaveBefore(string file)
    {
        Debug.Log("Saving Game File...");
        //IMPORTANT!!!!!!
        //probably where save data implementation would go
        //NOT IMPLEMENTED YET

            QuitGame();//calls to quit the game
    }


    public void QuitGame()
    {
        Debug.Log("Exiting Game...");

        Application.Quit();
    }


}
