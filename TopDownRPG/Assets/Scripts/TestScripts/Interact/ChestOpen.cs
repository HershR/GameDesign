using UnityEngine;

public class ChestOpen : Interactable
{
    public Item item;
    private Animator anime;
    
    public override void Interact(){
        base.Interact();
        Open();
        
       PickUp();
    }

    void PickUp(){
        //Debug.Log("Picking up "+item.name);
        bool wasPickedUp= Inventory.instance.Add(item);
        if(wasPickedUp==false){
            Close();
        }
        if(wasPickedUp==true){
            item.TriggerDialogue();
            anime.SetBool("ItemTaken",true);
            Destroy(gameObject,1);
            Destroy(this);
        
        }
    }
    void Open(){
        anime=GetComponent<Animator>();
        anime.SetBool("IsOpened",true);
    }
    void Close(){
        anime.SetBool("IsOpened",false);
    }
}
