using UnityEngine;
using UnityEngine.UI;

public class RestrictionsLayoutGroup : MonoBehaviour
{
    [SerializeField] private VerticalLayoutGroup layoutGroup;

    private void OnDisable()
    {
        EventManager.RestrictionAreaUpdatedEvent -= UpdateLayoutGroup;
    }

    private void OnEnable()
    {
        EventManager.RestrictionAreaUpdatedEvent += UpdateLayoutGroup;
    }

    private void UpdateLayoutGroup()
    {
        layoutGroup.SetLayoutVertical();
    }
}
