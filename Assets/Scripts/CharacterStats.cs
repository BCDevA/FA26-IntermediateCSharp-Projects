using UnityEngine;

public class CharacterStats {
    private int hp;
    private int maxhp;
    private int attack;

    public CharacterStats(int maxHP, int attack)
    {
	if(maxHP <= 0)
	{
	    maxHP = 1;
	}
	this.attack = attack;
	this.maxhp = maxHP;
	hp = maxHP;
    }

    public void changeHP(int change)
    {
	hp += change;
	if (hp <= 0)
	{
	    hp = 0;
	}
	if (hp > maxhp)
	{
	    hp = maxhp;
	}
    }

    public int getHP() { return hp; }
    public int getAtk() {  return attack; }
}
