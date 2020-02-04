using UnityEngine;

[CreateAssetMenu(fileName="New Item",menuName="Inventory/Item")]
public class Item : ScriptableObject
{
   new public string name="New Item";
   
   public Sprite icon=null;
   public bool isDefaultItem=false;
   public Dialogue dialogue;

   public virtual void Use(){
   
   }
   public void TriggerDialogue(){
      dialogue.sentences[0]="You found a "+name;
      FindObjectOfType<DialogueManager>().StartDialogue(dialogue);
   }
   public void RemoveFromInventory(){
      Inventory.instance.Remove(this);
   }
   
}
