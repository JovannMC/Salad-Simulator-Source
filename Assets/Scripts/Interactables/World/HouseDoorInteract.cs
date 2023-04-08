using SUPERCharacter;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HouseDoorInteract : MonoBehaviour, IInteractable
{
    private GameObject player;
    private SUPERCharacterAIO playerController;
    private GameObject crosshair;
    [SerializeField] private GameObject houseDoorPrompt;

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

        houseDoorPrompt.SetActive(true);
    }

    public void YesBtnClick()
    {
        playerController.inUI = false;
        
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<SUPERCharacterAIO>().enabled = true;

        crosshair.SetActive(true);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        houseDoorPrompt.SetActive(false);

        SceneManager.LoadScene("House");
    }

    public void NoBtnClick()
    {
        playerController.inUI = false;
        
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<SUPERCharacterAIO>().enabled = true;

        crosshair.SetActive(true);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        houseDoorPrompt.SetActive(false);
    }

    public string GetDescription()
    {
        return "Enter house";
    }
}
