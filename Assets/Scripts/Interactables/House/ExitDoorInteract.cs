using SUPERCharacter;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitDoorInteract : MonoBehaviour, IInteractable
{
    private GameObject player;
    private SUPERCharacterAIO playerController;
    private GameObject crosshair;
    [SerializeField] private GameObject exitDoorPrompt;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<SUPERCharacterAIO>();
        crosshair = GameObject.Find("Crosshair");
    }

    public void Interact()
    {
        playerController.inUI = true;
        
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<SUPERCharacterAIO>().enabled = false;

        crosshair.SetActive(false);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        exitDoorPrompt.SetActive(true);
    }

    public void YesBtnClick()
    {
        playerController.inUI = false;
        
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<SUPERCharacterAIO>().enabled = true;

        crosshair.SetActive(true);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        exitDoorPrompt.SetActive(false);

        SceneManager.LoadScene("World");
    }

    public void NoBtnClick()
    {
        playerController.inUI = false;
        
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<SUPERCharacterAIO>().enabled = true;

        crosshair.SetActive(true);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        exitDoorPrompt.SetActive(false);
    }

    public string GetDescription()
    {
        return "Leave house";
    }
}
