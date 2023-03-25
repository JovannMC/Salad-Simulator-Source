using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;

    private List<AudioClip> mouseClicks = new List<AudioClip>();
    private List<AudioClip> keyboardClicks = new List<AudioClip>();

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);

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
