using UnityEngine.InputSystem;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class Health_item : MonoBehaviour
{

    [Header("Player Health item")]
    [Tooltip("How much health does it heal.")]
    public int Health_added;
   
    [Tooltip("Name of inventory slot being used")]
    public GameObject ui;
    [Tooltip("Canvas Object for Player Health")]
    public Image playerHealthBar;
    [Tooltip("Name of player GameObject")]
    [SerializeField]
    private GameObject target;
    [Tooltip("Key for health item is H")]
    public int count = 1;

    //public int maxHP = target.GetComponent<PlayerMaster>().maxHP;

    void Start()
    {
        
    }

   
    void Update()
    {
        if (ui.activeSelf == true)
        {
           count = AddHealth(target, Health_added, ui, count);
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            ui.SetActive(true);//added to inventory 
        }


    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")){

              //5 children
            transform.GetChild(0).gameObject.SetActive(false);
            transform.GetChild(1).gameObject.SetActive(false);
            transform.GetChild(2).gameObject.SetActive(false);
            transform.GetChild(3).gameObject.SetActive(false);
            transform.GetChild(4).gameObject.SetActive(false);
            //all the children of this object are visual elements
            //effectively health item disappears when collected
        }
            
          

        }
           
   


    int AddHealth(GameObject target,int Health_added,GameObject ui,int count)
    {
            Keyboard current = Keyboard.current;

        
            if (current.hKey.wasPressedThisFrame && count == 1){//click key
                int CurrentHP = target.GetComponent<PlayerMaster>().statLine.getHP();

                    if ((CurrentHP + Health_added) <= 100)
                    {
                        target.GetComponent<PlayerMaster>().statLine.changeHP((Health_added + CurrentHP));//updates HP
                        playerHealthBar.fillAmount = (float)((CurrentHP + Health_added) / 100);//fills health bar to correct place
                    }
                    else
                    {
                        target.GetComponent<PlayerMaster>().statLine.changeHP(100);
                        playerHealthBar.fillAmount = 1;//full
                    }
                Debug.Log("Player has been healed");

            //target.GetComponent<Inventory>().HealthItemsUsed++ ;//subtracts a health item

            count++;
            ui.SetActive(false);//disables ui attribute of health item
            return count;//makes sure that health for one item is only implemented once
        }
        return 1;
    }



}
