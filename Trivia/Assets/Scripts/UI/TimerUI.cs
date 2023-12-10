using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class TimerUI : MonoBehaviour
{
    private float maxTimer = 10f;
    private float timer;
    [SerializeField] private Image timerFill;
    [SerializeField] private Image timerOutline;
    [SerializeField] private Transform timeOutPopup;

    private bool isGamePlaying;

    private void Awake()
    {
        timer = maxTimer;
    }

    private void Update()
    {
        if (isGamePlaying)
        {
            timer -= Time.deltaTime;
            timerFill.fillAmount = timer / maxTimer;

            if (timer <= 0)
            {
                TimeOut();
            }
        }
    }

    private void TimeOut()
    {
        timerFill.gameObject.SetActive(false);
        timerOutline.gameObject.SetActive(false);
        timeOutPopup.transform.DOScale(Vector3.one, 0.25f);
        isGamePlaying = false;
        EventManager.TimeOut();
    }

    public void ResetTimer()
    {
        timer = maxTimer;
        timerFill.gameObject.SetActive(true);
        timerOutline.gameObject.SetActive(true);
        timeOutPopup.transform.localScale = Vector3.zero;
    }

    private void OnEnable()
    {
        isGamePlaying = true;
        EventManager.NewQuestionLoadedEvent += ResetTimer;
    }

    private void OnDisable()
    {
        isGamePlaying = false;
        EventManager.NewQuestionLoadedEvent -= ResetTimer;
    }
}
