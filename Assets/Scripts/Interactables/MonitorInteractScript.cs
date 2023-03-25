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

    private void Update()
    {
        if (playerController.inUI) 
        {
            if (Input.anyKeyDown)
            {
                if (Input.GetMouseButtonDown(0) || Input.GetMouseButtonDown(1) || Input.GetMouseButtonDown(2)){ 
                    GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayMouseClick();
                } else {
                    GameObject.Find("AudioManager").GetComponent<AudioManager>().PlayKeyboardClick();
                }
            }
        }
    }

    public string GetDescription()
    {
        return "Open Computer";
    }

}
