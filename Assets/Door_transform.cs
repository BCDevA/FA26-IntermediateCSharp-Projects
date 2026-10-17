using Unity.Collections;
using UnityEngine;

public class Door_transform : MonoBehaviour
{
    //name of creature or character to be able to go through doors
    /*
    [Tooltip("Insert player or creature's name to go through door(spelling counts): ")]
    [SerializeField]
    public GameObject CreatureName;
    */
    /*
    [Header("What is the tag of the doors: ")]
    [ToolTip("OuterDoor: ")]
    [SerializeField]
    private string Outer;

    [ToolTip("InnerDoor: ")]
    [SerializeField]
    private string Inner;

    
    [Tooltip("Door Name:  ")]
    [SerializeField]
    private string Door;
    */

    //This transform of x and y is usable on any door
    [Tooltip("How far to transform(x value):  ")]
    [SerializeField]
    private float Distance;//distance can be zero

    [Tooltip("How far to transform(y value):  ")]
    [SerializeField]
    private float Height; //height can be 0

    /*
        //[Header("Door objects:")]
        [Tooltip("Door object(inner or outer):  ")]
        [SerializeField]
        private string DoorName;//name of gameObject

        [Tooltip("Inner Door Object:  ")]
        [SerializeField]
        private GameObject InnerDoor;
    */
    private int WhoIsTriggered;

    void Awake()
    {
        //Debug.Log($"Door {Door} is Awake");
    }

    
    void Update()
    {
       
        
            TransformCreature(WhoIsTriggered,Distance, Height);
        
    }

    public int OnTriggerEnter2D(Collider2D collision)
    {
        WhoIsTriggered = 0;


        if (collision.gameObject.tag == "Inner_door"){
            Debug.Log("Creature tried to exit door.");
            WhoIsTriggered = 1;
            return WhoIsTriggered;
        }
        else if(collision.gameObject.tag == "Outer_door")
        {
            Debug.Log("Creature tried to enter door.");

            WhoIsTriggered = 2;
            return WhoIsTriggered;
        }
            
            return WhoIsTriggered;
    }

    public void TransformCreature(int WhoIsTriggered,float Distance ,float Height)
    {
       float XPosition = 0, YPosition = 0;

            if ( WhoIsTriggered== 2) { //outerDoor
               XPosition = transform.position.x - Distance;
               YPosition = transform.position.y - Height;
           transform.position = new Vector2(YPosition, XPosition);
            Debug.Log("Creature entered the door.");
                    }
                else if(WhoIsTriggered== 1){//innerDoor
                      XPosition = transform.position.x + Distance;
                      YPosition = transform.position.y + Height;

            transform.position = new Vector2(YPosition, XPosition);
            Debug.Log("Creature exited the door.");
                }
                    
            //creature doesn't get transformed if it gets to here
                    

        

    }


}
