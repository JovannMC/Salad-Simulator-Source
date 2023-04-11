using System.Collections;
using UnityEngine;

public class GrassInteraction : MonoBehaviour, IInteractable
{
    [SerializeField] private GameObject grassPrompt;
    

    public void Interact()
    {
        Debug.Log("Player touched grass!");
        StartCoroutine(TouchGrass());
    }

    IEnumerator TouchGrass()
    {
        if (!GameManager.instance.isNoticeActive)
        {
            GameManager.instance.isNoticeActive = true;
            grassPrompt.SetActive(true);
            yield return new WaitForSeconds(3f);
            grassPrompt.SetActive(false);
            GameManager.instance.isNoticeActive = false;
        }
    }

    public string GetDescription()
    {
        return "Touch grass";
    }

}
