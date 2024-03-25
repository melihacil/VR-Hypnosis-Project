using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class ThemeController : MonoBehaviour
{
    public List<VideoClip> themeClips;
    public VideoPlayer themePlayer;

    public void ChangeTheme(int index)
    {
        themePlayer.Stop();
        themePlayer.clip = themeClips[index];
        themePlayer.Play();
    }
}
