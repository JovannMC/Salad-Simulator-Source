using System.Collections;
using UnityEngine;

public class GrassInteraction : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject grassPrompt;
    private bool isTextActive = false;
    

    public void Interact()
    {
        Debug.Log("Player touched grass!");
        StartCoroutine(TouchGrass());
    }

    IEnumerator TouchGrass()
    {
        if (isTextActive)
        {
            yield break;
        }
        
        isTextActive = true;
        grassPrompt.SetActive(true);
        yield return new WaitForSeconds(3f);
        grassPrompt.SetActive(false);
        isTextActive = false;
    }

    public string GetDescription()
    {
        return "Touch grass";
    }

}
