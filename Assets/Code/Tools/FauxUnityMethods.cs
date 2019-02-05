using UnityEngine;

public class FauxUnityMethods : MonoBehaviour
{
    private void Start()
    {
        Globals.Tools.Event.Fire(EventType.OnStart);
    }

    private void Update()
    {
        Globals.Tools.Event.Fire(EventType.OnUpdate);
    }

    //private void FixedUpdate()
    //{
    //    Globals.System.EventSystem.Fire(EventType.OnFixedUpdate);
    //}

    private void LateUpdate()
    {
        Globals.Tools.Event.Fire(EventType.OnLateUpdate);
    }
}
