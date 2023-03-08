using SUPERCharacter;
using UnityEngine;

public class MonitorInteractScript : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject player;
    [SerializeField] private Camera playerCam;
    [SerializeField] private Camera monitorCam;
    [SerializeField] private SUPERCharacterAIO playerController;
    [SerializeField] private GameObject monitorOverlay;

    public void Interact()
    {
        playerController.inUI = true;
        player.GetComponent<SUPERCharacterAIO>().enabled = false;

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        monitorOverlay.SetActive(true);

        playerCam.GetComponent<Camera>().enabled = false;
        monitorCam.GetComponent<Camera>().targetTexture = null;
    }

    public string GetDescription()
    {
        return "Open Computer";
    }

}
