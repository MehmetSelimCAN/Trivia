using DG.Tweening;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SpinMenu : MenuBase
{
    [Header("Wheel Spin Settings")]
    [SerializeField] private Transform wheel;
    [SerializeField] private float spinDuration;
    [SerializeField] private Ease spinEase;
    [SerializeField] private int spinAmount;

    [Header("Buttons")]
    [SerializeField] private Button spinButton;
    [SerializeField] private Button playButton;
    [SerializeField] private Button backButton;

    [Header("Texts")]
    [SerializeField] private TextMeshProUGUI spinText;
    [SerializeField] private TextMeshProUGUI categoryText;

    private List<CategoryType> categories;

    private void Awake()
    {
        spinButton.onClick.AddListener(() => OnSpinButtonClicked());
        playButton.onClick.AddListener(() => OnPlayButtonClicked());
        backButton.onClick.AddListener(() => OnBackButtonClicked());

        ResetValues();

        categories = new List<CategoryType> { CategoryType.Generalculture, CategoryType.History, CategoryType.Cinema, CategoryType.Music };
    }

    private void OnSpinButtonClicked()
    {
        spinButton.interactable = false;
        categoryText.transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InBack);

        Sequence sequence = DOTween.Sequence();
        sequence.Append(spinText.transform.DOScale(Vector3.zero, 0.5f).SetEase(Ease.InBack));

        float randomAngle = Random.Range(0, 360);
        CategoryType categoryType = DetectLandedCategory(randomAngle);
        float rotateAngle = (360 * spinAmount) + randomAngle;

        sequence.Append(wheel.DOLocalRotate(new Vector3(0, 0, rotateAngle), spinDuration, RotateMode.FastBeyond360)
            .SetEase(spinEase)
            .OnComplete(() => OnSpinCompleted(categoryType)));
    }

    private CategoryType DetectLandedCategory(float angle)
    {
        float anglePerCagetory = 360f / categories.Count;

        return categories[(int)(angle / anglePerCagetory)];
    }

    private void OnSpinCompleted(CategoryType categoryType)
    {
        categoryText.SetText(categoryType.ToString());
        playButton.gameObject.SetActive(true);

        categoryText.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);
        playButton.transform.DOScale(Vector3.one, 0.5f).SetEase(Ease.OutBack);
    }

    private void OnPlayButtonClicked()
    {
        canvasManager.ChangeCanvas(CanvasType.GameplayMenu);
    }

    private void OnBackButtonClicked()
    {
        canvasManager.ChangeCanvas(CanvasType.MainMenu);
    }

    private void OnDisable()
    {
        ResetValues();
    }

    private void ResetValues()
    {
        categoryText.SetText("Tap on the Spin");

        playButton.gameObject.SetActive(false);
        spinButton.interactable = true;

        categoryText.transform.localScale = Vector3.one;
        spinText.transform.localScale = Vector3.one;
        playButton.transform.localScale = Vector3.zero;

        wheel.localRotation = Quaternion.identity;
    }
}