using SUPERCharacter;
using UnityEngine;

public class MonitorInteractScript : MonoBehaviour, IInteractable
{
    private GameObject player;
    private Camera playerCam;
    private SUPERCharacterAIO playerController;
    private GameObject crosshair;
    [SerializeField] private Camera monitorCam;
    [SerializeField] private GameObject monitorOverlay;
    
    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerCam = player.GetComponentInChildren<Camera>();
        playerController = player.GetComponent<SUPERCharacterAIO>();
        crosshair = GameObject.Find("Crosshair");
    }

    public void Interact()
    {
        playerController.inComputer = true;
        
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<SUPERCharacterAIO>().enabled = false;

        crosshair.SetActive(false);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        monitorOverlay.SetActive(true);

        playerCam.GetComponent<Camera>().enabled = false;
        monitorCam.GetComponent<Camera>().targetTexture = null;
    }

    private void Update()
    {
        if (playerController.inComputer) 
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
