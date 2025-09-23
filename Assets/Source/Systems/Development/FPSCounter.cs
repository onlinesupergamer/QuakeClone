using UnityEngine;

public class FPSCounter : MonoBehaviour
{
    public TMPro.TextMeshProUGUI UITextMeshPro;

    float timer;

    private void Update()
    {
        
        int fps = (int)(1.0f / Time.deltaTime);
        UITextMeshPro.text = fps.ToString();
    }
}
