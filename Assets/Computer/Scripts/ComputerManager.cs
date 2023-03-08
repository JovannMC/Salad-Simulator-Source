using SUPERCharacter;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComputerManager : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject player;
    [SerializeField] private GameObject monitorScreen;
    [SerializeField] private Camera playerCam;
    [SerializeField] private Camera monitorCam;
    [SerializeField] private GameObject startMenu;
    [SerializeField] private SUPERCharacterAIO playerController;

    [SerializeField] private GameObject startupScreen;
    [SerializeField] private GameObject blankScreen;
    [SerializeField] private GameObject monitorOverlay;

    private bool isShutdown = true;
    private bool menuOpen = false;

    private List<Coroutine> runningCoroutines = new List<Coroutine>();

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

        monitorOverlay.SetActive(false);

        playerController.inUI = false;
    }

    public void ShutdownComputer()
    {
        blankScreen.SetActive(true);
        isShutdown = true;

        foreach (Coroutine coroutine in runningCoroutines)
        {
            StopCoroutine(runningCoroutines[runningCoroutines.Count - 1]);
        }
    }

    public void RestartComputer()
    {
        StartCoroutine(Restart());
    }

    IEnumerator BootSequence()
    {
        foreach (GameObject app in GameObject.FindGameObjectsWithTag("Apps")) {
            app.SetActive(false);
        }

        blankScreen.SetActive(false);
        isShutdown = false;

        startupScreen.SetActive(true);
        yield return new WaitForSeconds(3);
        startupScreen.SetActive(false);
    }

    IEnumerator Restart()
    {
        ShutdownComputer();
        yield return new WaitForSeconds(2);
        runningCoroutines.Add(StartCoroutine(BootSequence()));
    }

    public void Interact()
    {
        if (isShutdown)
        {
            runningCoroutines.Add(StartCoroutine(BootSequence()));
        } else
        {
            ShutdownComputer();
        }
    }

    public string GetDescription()
    {
        if (isShutdown)
        {
            return "Start Computer";
        }
        else
        {
            return "Shutdown Computer";
        }
    }
}
