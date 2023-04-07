using UnityEngine;

public class ExitDoorInteract : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject exitDoorPrompt;

    public void Interact()
    {
        exitDoorPrompt.SetActive(true);
    }

    public string GetDescription()
    {
        return "Leave house";
    }
}
