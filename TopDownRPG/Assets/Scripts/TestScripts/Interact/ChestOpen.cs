using UnityEngine;

public class ChestOpen : Interactable
{
    public Item item;
    private Animator anime;
    public Dialogue dialogue;
    public override void Interact(){
        base.Interact();
        Open();
        TriggerDialogue();
        //PickUp();
    }
    void Open(){
        anime=GetComponent<Animator>();
        anime.SetBool("IsOpened",true);

    }
    
    void PickUp(){
        Debug.Log("Picking up "+item.name);
        bool wasPickedUp= Inventory.instance.Add(item);
        if(wasPickedUp==false)
            anime.SetBool("IsOpened",false);
        if(wasPickedUp==true)
            anime.SetBool("ItemTaken",true);
            Destroy(gameObject);

    }
    
    public void TriggerDialogue() {
        FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
    }
}
