using UnityEngine;

public class Attack_Item : MonoBehaviour
{
    [Header("Player Attack item")]
    [Tooltip("How much Attack does it give.")]
    public int Attack_added;

    [Tooltip("Name of inventory slot being used")]
    public GameObject ui;

    [Tooltip("Name of player GameObject")]
    public GameObject target;
    [Tooltip("Key for health item is T")]


    void Update() {

    //public int OgAttack = target.GetComponent<PlayerMaster>().ATK;

    }
/*
    void AddAttack(GameObject target, int Attack_added, int OgAttack, GameObject ui, int maxHP)
    {
        if (ui.activeSelf && Input.GetKeyDown(KeyCode.T))
        {//click key

            target.GetComponent<PlayerMaster>().ATK = OgAttack + Attack_added;//updates Attack

            Debug.Log("Player attack has increased");

            target.GetComponent<Inventory>().AttackItemsUsed++;//subtracts a attack item



        }

    }
*/
}
