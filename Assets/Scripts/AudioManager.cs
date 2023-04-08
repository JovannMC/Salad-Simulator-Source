using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager instance;

    private AudioSource audioSource;

    private List<AudioClip> mouseClicks = new List<AudioClip>();
    private List<AudioClip> keyboardClicks = new List<AudioClip>();

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
        
        audioSource = GetComponent<AudioSource>();

        mouseClicks = new List<AudioClip>(Resources.LoadAll<AudioClip>("Audio/Computer/Mouse/"));
        keyboardClicks = new List<AudioClip>(Resources.LoadAll<AudioClip>("Audio/Computer/Keyboard/Single"));
    }

    public void PlayMouseClick()
    {
        audioSource.PlayOneShot(mouseClicks[Random.Range(0, mouseClicks.Count)]);
    }

    public void PlayKeyboardClick()
    {
        audioSource.PlayOneShot(keyboardClicks[Random.Range(0, keyboardClicks.Count)], 0.25f);
    }
}
