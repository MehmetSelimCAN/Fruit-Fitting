using DG.Tweening;
using UnityEngine;

public class RestrictionAreaTweener : MonoBehaviour
{
    [SerializeField] private RectTransform restrictionArea;

    private void Start()
    {
        restrictionArea.DOScale(Vector3.zero, 0.5f).From();
    }
}
