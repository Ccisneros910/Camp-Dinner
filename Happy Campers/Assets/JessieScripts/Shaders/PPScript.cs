using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PPScript : MonoBehaviour
{
    [SerializeField] private Material material;
    [SerializeField] private float[] SunsetColors;
    [SerializeField] private float[] EveningColors;
    [SerializeField] private float TimeBeforeSunset;
    [SerializeField] private float TimeBeforeEvening;
    [SerializeField] private float TimeBeforeEnd;

    [SerializeField] private float Timer;
    [SerializeField] private float InitialTime;

    [SerializeField] private bool timerRunning;

    private void Start()
    {
        if(TimeBeforeSunset == 0)
        {
            TimeBeforeSunset = 60;
        }

        if(TimeBeforeEvening == 0)
        {
            TimeBeforeEvening = 90;
        }

        if(TimeBeforeEvening < TimeBeforeSunset)
        {
            float temp = TimeBeforeEvening;
            TimeBeforeEvening = TimeBeforeSunset;
            TimeBeforeSunset = temp;
        }

        timerRunning = true;
        Timer = InitialTime;
        material.SetFloat("_Redness", 0);
        material.SetFloat("_Greenness", 0);
        material.SetFloat("_Blueness", 0);
    }

    private void Update()
    {
        Timer += Time.deltaTime;

        if(Timer > TimeBeforeEvening)
        {
            BeginEvening();
        }else if(Timer > TimeBeforeSunset)
        {
            BeginSunset();
        }

        if(Timer > TimeBeforeEnd)
        {
            SceneManager.LoadScene(4);
        }
    }

    private void BeginSunset()
    {
        material.SetFloat("_Redness", SunsetColors[0]);
        material.SetFloat("_Greenness", SunsetColors[1]);
        material.SetFloat("_Blueness", SunsetColors[2]);
    }

    private void BeginEvening()
    {
        material.SetFloat("_Redness", EveningColors[0]);
        material.SetFloat("_Greenness", EveningColors[1]);
        material.SetFloat("_Blueness", EveningColors[2]);
    }
    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        Graphics.Blit(source, destination, material);
    }
}
