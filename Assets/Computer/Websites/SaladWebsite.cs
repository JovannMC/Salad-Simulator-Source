using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaladWebsite : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreen;

    void OnEnable()
    {
        StartCoroutine(LoadingScreen());
    }

    IEnumerator LoadingScreen()
    {
        yield return new WaitForSeconds(2.5f);
        loadingScreen.SetActive(false);
    }
}
