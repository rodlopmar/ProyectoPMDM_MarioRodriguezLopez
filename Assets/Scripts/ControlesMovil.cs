using UnityEngine;

public class ControlesMovil : MonoBehaviour
{
    void Start()
    {
        if (Application.isMobilePlatform)
        {
            gameObject.SetActive(true);
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}