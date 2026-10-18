using UnityEngine;

public class Inventory : MonoBehaviour
{

    protected int HealthItemsCount = 1;
    public int HealthItemsUsed = 0;
    protected int AttackItemsCount = 0;
    public int AttackItemsUsed = 0;
    [Header("Starting items in Inventory")]
    [Tooltip("Number of items filled")]
    public int NumFilled;

    [Tooltip("1st slot:")]
    public GameObject UI1Name;

    [Tooltip("2nd slot:")]
    public GameObject UI2Name;

    [Tooltip("3rd slot:")]
    public GameObject UI3Name;

    [Tooltip("4th slot:")]
    public GameObject UI4Name;

    [Tooltip("5th slot:")]
    public GameObject UI5Name;

    [Tooltip("6th slot:")]
    public GameObject UI6Name;

    public int[] InventoryArray;

    void Start()
    {
        int[] InventoryArray = { 1, 0, 0, 0, 0, 0 };//options 0, 1, 2 empty, health, or attack
    }

    void Update()
    {
        if(HealthItemsUsed > 0 || AttackItemsUsed >0)
        {
            SubtractFromInventory(HealthItemsCount, HealthItemsUsed, AttackItemsCount, AttackItemsUsed, InventoryArray);
        }
    }


        void SubtractFromInventory(int HealthItemsCount, int HealthItemsUsed, int AttackItemsCount, int AttackItemsUsed, int[] Inventory)
    {

        int CurrentHealthSubtracted = 0;
        int CurrentHealthCount = 0;
        int CurrentAttackSubtracted = 0;
        int CurrentAttackCount = 0;
        int Index_Of_UI_To_Be_Removed=0;

        for(int i = 0; i < Inventory.Length; i++)
        {
            if (Inventory[i] == 1)
            {
                CurrentHealthCount++;
            }

            else if(Inventory[i] == 2)
            {
                CurrentAttackCount++;
            }

            if (CurrentHealthCount == HealthItemsCount && HealthItemsUsed > 0) //last item in inventory that is filled and has health item
            {
                Inventory[i] = 0;
                Index_Of_UI_To_Be_Removed = i;
                CurrentHealthSubtracted++;
                break;
            }
            else if(CurrentAttackCount == AttackItemsCount && AttackItemsUsed > 0)
            {
                Inventory [i] = 0;
                Index_Of_UI_To_Be_Removed = i;
                CurrentAttackSubtracted++;
                break;
            }

        }

        DisableUI(Index_Of_UI_To_Be_Removed);


    }

    void DisableUI(int Index){

        if(Index == 0)
        {
            UI1Name.SetActive(false);
        }
        else if (Index == 1)
        {
            UI2Name.SetActive(false);
        }
        else if (Index == 2)
        {
            UI3Name.SetActive(false);
        }
        else if (Index == 3)
        {
            UI4Name.SetActive(false);
        }
        else if (Index == 4)
        {
            UI5Name.SetActive(false);
        }
        else if (Index == 5)
        {
            UI6Name.SetActive(false);
        }
    }

   void EnableUI(int Index){
        if (Index == 0)
        {
            UI1Name.SetActive(true);
        }
        else if (Index == 1)
        {
            UI2Name.SetActive(true);
        }
        else if (Index == 2)
        {
            UI3Name.SetActive(true);
        }
        else if (Index == 3)
        {
            UI4Name.SetActive(true);
        }
        else if (Index == 4)
        {
            UI5Name.SetActive(true);
        }
        else if (Index == 5)
        {
            UI6Name.SetActive(true);
        }

    }


}
