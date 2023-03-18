using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    private AudioSource audioSource;

    [Header("Mouse SFX")]
    [SerializeField] private AudioClip mouseClick1;
    [SerializeField] private AudioClip mouseClick2;
    [SerializeField] private AudioClip mouseClick3;
    [SerializeField] private AudioClip mouseClick4;

    [Header("Keyboard SFX")]
    [SerializeField] private AudioClip keyboardClick1;
    [SerializeField] private AudioClip keyboardClick2;
    [SerializeField] private AudioClip keyboardClick3;
    [SerializeField] private AudioClip keyboardClick4;
    [SerializeField] private AudioClip keyboardClick5;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
        DontDestroyOnLoad(gameObject);
    }

    public void PlayMouseClick()
    {
        int random = Random.Range(1, 4);

        switch (random)
        {
            case 1:
                audioSource.PlayOneShot(mouseClick1);
                break;
            case 2:
                audioSource.PlayOneShot(mouseClick2);
                break;
            case 3:
                audioSource.PlayOneShot(mouseClick3);
                break;
            case 4:
                audioSource.PlayOneShot(mouseClick4);
                break;
        }
    }

    public void PlayKeyboardClick()
    {
        int random = Random.Range(1, 5);

        switch (random)
        {
            case 1:
                audioSource.PlayOneShot(keyboardClick1);
                break;
            case 2:
                audioSource.PlayOneShot(keyboardClick2);
                break;
            case 3:
                audioSource.PlayOneShot(keyboardClick3);
                break;
            case 4:
                audioSource.PlayOneShot(keyboardClick4);
                break;
            case 5:
                audioSource.PlayOneShot(keyboardClick5);
                break;
        }
    }
}
