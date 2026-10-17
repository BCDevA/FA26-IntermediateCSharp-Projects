using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [Header("Spawns an enemy when Player walks through it,")]

    [Tooltip("What is the creature prefab to spawn:")]
    [SerializeField]
    private GameObject CreatureName;

    [Header("Location to spawn Enemy")]
    [Tooltip("What is the desired Y location:")]
    [SerializeField]
    private float PositionY;
    [Tooltip("What is the desired X location:")]
    [SerializeField]
    private float PositionX;

    private bool CanSpawnEnemy = true;

    [Tooltip("How many times can it spawn an enemy:")]
    [SerializeField]
    private int MaxSpawn; //can be more than 1, so it can be used for all triggered spawns

    private int count = 0;

    // Update is called once per frame
    void Update()
    {
       if(count >= MaxSpawn)
        {
            CanSpawnEnemy = false;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && CanSpawnEnemy) {
            Vector2 Location = new Vector2(PositionY, PositionX);
            Instantiate(CreatureName, Location, Quaternion.identity);
            }

    }

    private void OnTriggerExit2d(Collider2D collision)
    {
        count++;//had to enter the trigger to go out. 
    }

}
