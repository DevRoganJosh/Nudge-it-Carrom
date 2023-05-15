using UnityEngine;

public class Cam : MonoBehaviour
{

    void Start()
    {
        float currentAspect = (float)Screen.width / Screen.height;
        if(currentAspect!=16/9)
        Camera.main.orthographicSize = 5.5f;
        else
        Camera.main.orthographicSize = 5;
    }
}
