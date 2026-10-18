using UnityEngine;

public class EnemyStatMaster : MonoBehaviour
{
    public CharacterStats statLine;
    [Tooltip("Health max(int):")]
    public int maxHP;
    [Tooltip("Attack stat(int):")]
    public int ATK;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
	statLine = new CharacterStats(maxHP, ATK);
    }

    private void OnEnable()
    {
	if (GetComponentInChildren<Attack>())
	{
	    GetComponentInChildren<Attack>().damage = ATK;
	}
    }

    private void Update()
    {
    }
}
