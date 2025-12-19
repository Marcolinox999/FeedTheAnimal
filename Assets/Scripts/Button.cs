using UnityEngine;

public class Button : MonoBehaviour

{
   [SerializeField] private GameObject door;
   public void OpenDoor()
   {
      door.SetActive(!door.activeSelf);
   }
}
