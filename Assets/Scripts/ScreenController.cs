using System.IO;
using UnityEditor;

//using System.Text;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//switches between scenes in unity
public class ScreenController : MonoBehaviour
{
    public static ScreenController screenController;

    [Tooltip("Current Scene Number:  ")]
        public int CurrentSceneNum;
    [Tooltip("Game Over Scene(if applicable)?")]
        public string GameOverScreen;
    [Tooltip("Player object:")]
        public GameObject Player;
    [Tooltip("Canvas Object for Player Health")]
        public Image playerHealthBar;
    [Tooltip("Name of Main Menu: ")]
        public string MainMenuName;
    [Tooltip("Save File path: ")]
        public string filePath;
    [Tooltip("Audio Source Object")]
        public AudioSource musicPlayer;


    private void Awake()
    {
       Debug.Log("ScreenController is Awake");

        CurrentSceneNum = SceneManager.GetActiveScene().buildIndex;
       
        if (File.Exists(filePath))
        {
            Debug.Log("Getting save data...");
            Debug.Log("File exists");
                ReadAndSetData(filePath);
        }
        else
        {
            Debug.Log("File Path doesn't Exist, no save accessed");
        }

            SceneManager.sceneLoaded += AfterBuildingScene;
    }

    void Update()
    {
        Keyboard current = Keyboard.current;

        if (current.escapeKey.wasPressedThisFrame)//To clear file on leaving you have to press escape
        {
            File.WriteAllText(filePath,string.Empty); 
        }


    }


    public void GoToSpecificScene(int sceneIndex)
    {
        Debug.Log($"Loading scene number{sceneIndex}...");
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
        if (CurrentSceneNum== 1)
        {
            SaveBefore(filePath); //saves only if you didn't win yet or die
        }
        SceneManager.LoadScene(MainMenuName.ToString()); 

        
    }

    void AfterBuildingScene(Scene scene, LoadSceneMode mode)
    {
        CurrentSceneNum = scene.buildIndex;
    }

    void SaveBefore(string filePath)
    {
        Debug.Log("Saving Game File...");
        //IMPORTANT!!!!!!
        //probably where save data implementation would go
        //NOT IMPLEMENTED YET

            if (File.Exists(filePath)) {

                Debug.Log("File exists");

            }
            else
            {
                Debug.Log("File does not exist");
            }
       
            using StreamWriter saver = new StreamWriter(filePath);
                float LocationX = Player.transform.position.x;//Location X float
                float LocationY = Player.transform.position.y;//Location Y float
                //float LocationZ = Player.transform.position.z;//Location Z float
                int SaveHealth = Player.GetComponent<PlayerMaster>().statLine.getHP();//Health int
                int SaveAttack = Player.GetComponent<PlayerMaster>().ATK;//Attack int
                string song = null;
                if (musicPlayer.isPlaying)
                {
                    song = musicPlayer.clip.name;
                    Debug.Log(song);
                }

            string NewLine = string.Join(',', LocationX, LocationY, SaveHealth, SaveAttack, song);

            saver.WriteLine(NewLine);

        }
               
  

    void ReadAndSetData(string filePath)
    {
        using StreamReader readSave = new StreamReader(filePath);

        string Data = readSave.ReadLine();

        if (Data != null)//if no save data yet, then do not set values to file data
        {
            string[] DataSections = Data.Split(",");

            float LocationX = 0;
            float LocationY = 0;

            bool IsTrue = false;
            if (DataSections[0] != null && DataSections[1] != null)
            {
                LocationX = float.Parse(DataSections[0]);//Location X
                LocationY = float.Parse(DataSections[1]);//Location Y
                IsTrue = true;
            }
            //float LocationZ = float.Parse(DataSections[2]);//Location Z
            int SaveHealth = int.Parse(DataSections[2]);//Health
            int SaveAttack = int.Parse(DataSections[3]);//Attack
            string song = null;
            AudioClip playSong = null;
            if (DataSections[4] != null)
            {
                Debug.Log("Loading song...");
                song = DataSections[4];
                Debug.Log($"Loading {song}...");
                playSong = Resources.Load<AudioClip>(song);
                if (playSong != null)
                {
                    Debug.Log(playSong.name + "Loaded.");
                }
            }
            //UPDATE VALUES


            Player.transform.position = new Vector2(LocationX, LocationY);//Location Changed
                Debug.Log("Location loaded...");
            
            if (IsTrue == true)
            {
                Player.GetComponent<PlayerMaster>().statLine.changeHP(-(100-SaveHealth));
                playerHealthBar.fillAmount = (float)SaveHealth / 100;
                Debug.Log("Health loaded...");
            }
            if (SaveAttack > 0)
            {
                Player.GetComponent<PlayerMaster>().ATK = SaveAttack;
                Debug.Log("Attack loaded...");
            }
            if (playSong != null)
            {
                musicPlayer.resource = playSong;
                musicPlayer.Play();
            }
            Debug.Log("Finished transfer of save data to game");
        }
    }


   void QuitGame()
    {
        Debug.Log("Exiting Game...");

        Application.Quit();
    }


}
