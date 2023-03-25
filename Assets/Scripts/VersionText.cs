using TMPro;
using UnityEngine;

public class VersionText : MonoBehaviour
{
    void Start()
    {
        //DontDestroyOnLoad(canvas);
        
        TMP_Text versionText = GetComponent<TextMeshProUGUI>();
        
        if (Application.version.Contains("a"))
        {
            versionText.text = "Version: " + Application.version + " (Alpha)";
        } else if (Application.version.Contains("b"))
        {
            versionText.text = "Version: " + Application.version + " (Beta)";
        } else if (Application.version.Contains("pb"))
        {
            versionText.text = "Version: " + Application.version + " (Private Build)";
        } else
        {
            versionText.text = "Version: " + Application.version;
        }
    }
}
