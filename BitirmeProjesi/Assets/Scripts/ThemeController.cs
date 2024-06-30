using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ThemeController : MonoBehaviour
{
    public List<VideoClip> themeClips;
    public VideoPlayer themePlayer;
    public GameObject videoSphere;

    public void ChangeTheme(int index)
    {
        if (index.Equals(3))
        {
            videoSphere.SetActive(false);
            themePlayer.Stop();
            return;
        }
        videoSphere.SetActive(true);
        themePlayer.Stop();
        themePlayer.clip = themeClips[index];
        themePlayer.Play();
    }
}
