using SpaceGraphicsToolkit.Ring;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class RingColorController : MonoBehaviour
{

    [SerializeField] SgtRing _ring;
    [SerializeField] private float _colorChangeStep = 1.0f / 38.0f;

    [SerializeField]private Color _sgtColor;

    private int MAX_COLOR = 255;
    private int MIN_COLOR = 0;


    // Start is called before the first frame update
    void Start()
    {
        _sgtColor = _ring.Color;
        // _sgtColor = Color.cyan;
        //_ring.Color = Color.cyan;
        StartCoroutine(nameof(ChangeColorWithSteps));
    }


    IEnumerator ChangeColorWithSteps()
    {

        WaitForSeconds waitTime = new WaitForSeconds(1.0f);

        float r = 0f, g = 0f, b = 0f;
        Color changingColor = new Color(r, g, b);
        _ring.Color = new Color(r, g, b);
        var complete = false;
        while (!complete)
        {
            Debug.Log("Changing");
            if (r < 1.0f)
            {
                r += _colorChangeStep;
                changingColor.r = r;
                _ring.Color = new Color(r, g, b);
                yield return waitTime;
                continue;
            }

            if (g < 1.0f)
            {
                g += _colorChangeStep;
                _ring.Color = new Color(r, g, b);
                yield return waitTime;
                continue;
            }
            if (b < 1.0f)
            {
                b += _colorChangeStep;
                _ring.Color = new Color(r, g, b);
                yield return waitTime;
                continue;
            }

            complete = true;
        }

        yield return null;
    }


    private void ChangeColorToRed()
    {

    }
}
