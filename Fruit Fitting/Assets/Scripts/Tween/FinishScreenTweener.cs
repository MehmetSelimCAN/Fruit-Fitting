using DG.Tweening;
using UnityEngine;

public class FinishScreenTweener : MonoBehaviour
{
    [SerializeField] private RectTransform fadeImage;
    [SerializeField] private RectTransform congrulationsText;
    [SerializeField] private RectTransform[] stars;

    private void OnEnable()
    {
        EventManager.GameFinishedEvent += AnimateFinishScreen;
    }

    private void OnDisable()
    {
        EventManager.GameFinishedEvent -= AnimateFinishScreen;
    }

    private void AnimateFinishScreen()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.AppendInterval(0.75f);
        mySequence.Append(fadeImage.DOScale(Vector3.one, 0.75f));
        mySequence.Append(congrulationsText.DOScale(Vector3.zero, 0.5f));

        foreach (var star in stars)
        {
            mySequence.Append(star.DOScale(Vector3.zero, 0.5f));
        }

        mySequence.OnComplete(() => EventManager.BackToMenu());
    }
}
