using System.Collections.Generic;
using System.Linq;
using SUPERCharacter;
using TMPro;
using UnityEngine;

public class NPCInteract : MonoBehaviour, IInteractable
{
    private GameObject player;
    private SUPERCharacterAIO playerController;
    private GameObject crosshair;

    [SerializeField] private GameObject npcPrompt;
    [SerializeField] private TMP_Text jobText;
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private TMP_Text wageText;
    [SerializeField] private TMP_Text finalPayText;

    private string job;
    private int hours;
    private float wage;
    private float finalPay;

    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        playerController = player.GetComponent<SUPERCharacterAIO>();
        crosshair = GameObject.Find("Crosshair");
    }
    
    public void Interact()
    {
        job = JobManager.instance.GetRandomJob();
        hours = JobManager.instance.GetRandomHours();
        wage = JobManager.instance.GetPayPerHour(job);
        finalPay = JobManager.instance.GetFinalPay(job, hours);

        jobText.text = job;
        timeText.text = hours + " hours";
        wageText.text = "$" + wage + " per hour";
        finalPayText.text = "You will be paid $" + finalPay.ToString("0.00") + " for this job.";

        playerController.inUI = true;
        
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<SUPERCharacterAIO>().enabled = false;

        crosshair.SetActive(false);

        Cursor.visible = true;
        Cursor.lockState = CursorLockMode.None;

        npcPrompt.SetActive(true);
    }

    public void YesBtnClick()
    {
        playerController.inUI = false;
        
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<SUPERCharacterAIO>().enabled = true;

        crosshair.SetActive(true);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        npcPrompt.SetActive(false);

        JobManager.instance.StartJob(job, hours);
    }

    public void NoBtnClick()
    {
        playerController.inUI = false;
        
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<SUPERCharacterAIO>().enabled = true;

        crosshair.SetActive(true);

        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;

        npcPrompt.SetActive(false);
    }

    public string GetDescription()
    {
        return "Talk to NPC";
    }
}
