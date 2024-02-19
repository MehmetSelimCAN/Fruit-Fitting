using DG.Tweening;
using UnityEngine;

public class MenuUITweener : MonoBehaviour
{
    [SerializeField] private RectTransform levelButtonRect;
    [SerializeField] private RectTransform fadeImage;

    private void Start()
    {
        Sequence mySequence = DOTween.Sequence();
        mySequence.Append(fadeImage.DOScale(Vector3.zero, 0.75f));
        mySequence.Append(levelButtonRect.DOScale(Vector3.zero, 0.35f).From());
    }
}
