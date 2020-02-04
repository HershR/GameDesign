
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public int maxHealth =100;
    public int currerntHealth{get;private set; }
    public Stat damage;
    public Stat armor;

    void Awake(){
        currerntHealth=maxHealth;
    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.T)){
            TakeDamage(10);
        }
    }

    public void TakeDamage(int damage){
        damage-=armor.GetValue();
        damage=Mathf.Clamp(damage,0,int.MaxValue);
        currerntHealth-=damage;
        Debug.Log(transform.name+" takes "+ damage+" damage.");
        if(currerntHealth<=0){
            Die();
        }
    }
    public virtual void Die(){
        //Die in someway
        //ment to be overridden
        Debug.Log(transform.name+" died.");
    }

}
