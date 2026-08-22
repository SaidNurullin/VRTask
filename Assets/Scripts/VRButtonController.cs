using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class VRButtonController : MonoBehaviour
{
    [SerializeField] private GameObject spider;
    [SerializeField] private XRPokeFollowAffordance followAffordance;
    [SerializeField] private XRSimpleInteractable simpleInteractable;

    private void Update()
    {
        if (Mathf.Abs(followAffordance.pokeFollowTransform.localPosition.y) >= Mathf.Abs(followAffordance.maxDistance) - 0.01f)
        {
            ActivateSpider();
        }
    }

    public void ActivateSpider()
    {
        if (spider.activeInHierarchy) return;
        followAffordance.clampToMaxDistance = true;
        simpleInteractable.enabled = false;
        spider.SetActive(true);
    }
}
