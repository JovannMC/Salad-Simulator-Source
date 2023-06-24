using System.Collections;
using TMPro;
using UnityEngine;

public class SaladWebsite : MonoBehaviour
{
    [SerializeField] private GameObject loadingScreen;

    [SerializeField] private TMP_Text currentBalanceNavbarText;
    [SerializeField] private TMP_Text currentBalanceText;
    [SerializeField] private TMP_Text lifetimeBalanceText;
    [SerializeField] private TMP_Text lifetimeXPText;
    [SerializeField] private TMP_Text last24HrsText;

    void OnEnable()
    {
        StartCoroutine(LoadingScreen());
    }

    private void Update()
    {
        currentBalanceNavbarText.text = "$" + GameManager.instance.Money.ToString("F2");
        currentBalanceText.text = "$" + GameManager.instance.Money.ToString("F2");
        lifetimeBalanceText.text = "$" + GameManager.instance.LifetimeBalance.ToString("F2");
        lifetimeXPText.text = GameManager.instance.LifetimeXP.ToString("F0");
        last24HrsText.text = "$" + GameManager.instance.Last24Hrs.ToString("F2");
    }

    IEnumerator LoadingScreen()
    {
        yield return new WaitForSeconds(2.5f);
        loadingScreen.SetActive(false);
    }
}
