using UnityEngine.InputSystem;
using UnityEngine;

public class Health_item : MonoBehaviour
{

    [Header("Player Health item")]
    [Tooltip("How much health does it heal.")]
    public int Health_added;
   
    [Tooltip("Name of inventory slot being used")]
    [SerializeField]
    private GameObject ui;
    
    [Tooltip("Name of player GameObject")]
    [SerializeField]
    private GameObject target;
    [Tooltip("Key for health item is H")]

    //public int maxHP = target.GetComponent<PlayerMaster>().maxHP;

    void Start()
    {
        
    }

   
    void Update()
    {
        


    }


    private void AddHealth(GameObject target,int Health_added,GameObject ui)
    {
        if(ui.activeSelf && Input.GetKeyDown(KeyCode.H)){//click key

            target.GetComponent<PlayerMaster>().statLine.changeHP(Health_added);//updates HP

            Debug.Log("Player has been healed");

            target.GetComponent<Inventory>().HealthItemsUsed++ ;//subtracts a health item


            
        }

    }



}
