using SUPERCharacter;
using UnityEngine;

public class ComputerInteractScript : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject player;
    [SerializeField] private Camera playerCam;
    [SerializeField] private Camera monitorCam;
    [SerializeField] private SUPERCharacterAIO playerController;

    public void Interact()
    {
        playerController.inUI = true;
        player.GetComponent<SUPERCharacterAIO>().enabled = false;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        playerCam.GetComponent<Camera>().enabled = false;
        monitorCam.GetComponent<Camera>().targetTexture = null;
    }

    public string GetDescription()
    {
        return "Open Computer";
    }

}
