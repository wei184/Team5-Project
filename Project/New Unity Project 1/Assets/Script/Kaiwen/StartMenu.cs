using UnityEngine;
using System.Collections;

public class StartMenu : MonoBehaviour {

    public MovieTexture movTexture;
    public bool isPlay = true;
    // Use this for initialization
    private bool isfinished = false;
    void Start()
    {
        movTexture.loop = false;
        movTexture.Play();
    }

    // Update is called once per frame
    void Update()
    {
        if (isPlay)
        {
            if (Input.GetMouseButtonDown(0))
            {
                isPlay = false;
                stop();
            }
        }
        if (isPlay != movTexture.isPlaying)
        {
            stop();
        }
    }
    void OnGUI()
    {
        if (isPlay)
        {
            GUI.DrawTexture(new Rect(0, 0, Screen.width, Screen.height), movTexture);
        }

    }
    private void stop()
    {
        movTexture.Stop();
        isPlay = false;
    }

}
