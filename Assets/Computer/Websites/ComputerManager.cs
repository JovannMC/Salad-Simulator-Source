using SUPERCharacter;
using UnityEngine;

public class ComputerManager : MonoBehaviour
{
    [SerializeField] private GameObject player;
    [SerializeField] private Camera playerCam;
    [SerializeField] private Camera monitorCam;
    [SerializeField] private GameObject startMenu;
    [SerializeField] private SUPERCharacterAIO playerController;

    private bool menuOpen = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && playerController.inUI)
        {
            ExitClick();
        }
    }

    public void StartButtonClick()
    {
        if (menuOpen)
        {
            menuOpen = false;
            startMenu.SetActive(false);
        }
        else
        {
            menuOpen = true;
            startMenu.SetActive(true);
        }
    }

    public void ExitClick()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        player.GetComponent<SUPERCharacterAIO>().enabled = true;

        playerCam.GetComponent<Camera>().enabled = true;
        monitorCam.GetComponent<Camera>().targetTexture = Resources.Load<RenderTexture>("Computer");

        playerController.inUI = false;
    }
}
