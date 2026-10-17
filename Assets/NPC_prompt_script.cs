using UnityEngine;

public class NPC_prompt_script : MonoBehaviour
{

    [Tooltip("What do you want the NPC to say")]
    public string Message;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(Message);
    }

}
