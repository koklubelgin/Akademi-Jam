using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    public class GameManager : MonoBehaviour
    {
        public static GameManager Instance { get; private set; }
        public bool IsTimeStopped { get; private set; } = false;
        public float timeStopDuration = 5f; // Zaman�n duraca�� s�re

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
                DontDestroyOnLoad(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
        }

        public void StopTime(float duration)
        {
            if (!IsTimeStopped)
            {
                StartCoroutine(TimeStopCoroutine(duration));
            }
        }

        private IEnumerator TimeStopCoroutine(float duration)
        {
            IsTimeStopped = true;
            Time.timeScale = 0f; // Zaman� durdur
            yield return new WaitForSecondsRealtime(duration); // Ger�ek zaman bekle
            Time.timeScale = 1f; // Zaman� tekrar ba�lat
            IsTimeStopped = false;
        }
    }



