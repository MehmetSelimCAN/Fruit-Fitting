using UnityEngine;
using UnityEngine.UI;

public class RestrictionsLayoutGroup : MonoBehaviour
{
    [SerializeField] private VerticalLayoutGroup layoutGroup;

    private void OnDisable()
    {
        EventManager.RestrictionAreaUpdatedEvent -= UpdateLayoutGroupSize;
        EventManager.WrongRestrictionsChangedEvent -= UpdateLayoutGroupOrder;
    }

    private void OnEnable()
    {
        EventManager.RestrictionAreaUpdatedEvent += UpdateLayoutGroupSize;
        EventManager.WrongRestrictionsChangedEvent += UpdateLayoutGroupOrder;
    }

    private void UpdateLayoutGroupSize()
    {
        layoutGroup.SetLayoutVertical();
    }

    private void UpdateLayoutGroupOrder(RestrictionArea restrictionArea)
    {
        restrictionArea.transform.SetAsLastSibling();
    }
}
