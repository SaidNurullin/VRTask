using UnityEngine;
using System.Collections.Generic;

public class MiniGameLogic : MonoBehaviour
{
    [SerializeField] private Trigger trigger;
    [SerializeField] private int targetNumber;
    [SerializeField] private InfoUI infoUI;
    [SerializeField] private LeverManager leverManager;

    private List<GameObject> beatles = new();

    void Start()
    {
        trigger.OnTrigger.AddListener(ProcessTrigger);
    }

    private void ProcessTrigger(GameObject obj)
    {
        if (beatles.Contains(obj)) return;
        beatles.Add(obj);

        if(beatles.Count == targetNumber)
        {
            infoUI.SetText(true, 0);
            leverManager.Activate();
        }
        else
        {
            infoUI.SetText(false, targetNumber - beatles.Count);
        }
    }
}
