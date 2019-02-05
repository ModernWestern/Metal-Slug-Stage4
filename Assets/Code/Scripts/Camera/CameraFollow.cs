using UnityEngine;

public class CameraFollow
{
    private readonly float THREE_EIGHTHS_SCREEN;
    private readonly float Smoothness; //  1 = Slower / 10 = Faster
    private readonly Vector3 OFFSET;
    
    private GameObject target, camera;
    private Vector3 moveTowards, lastPosition;
    private bool lookBack, lookForward;

    public CameraFollow(GameObject target, float smoothness)
    {
        this.target = target;
        Smoothness = smoothness;

        camera = Globals.Generics.MainCamera.transform.gameObject;

        THREE_EIGHTHS_SCREEN = Screen.width / 2.666666666666667f;
        OFFSET = new Vector3
        {
            x = 2.666666666666667f,
            y = 5.5f,
            z = -10
        };
        lastPosition = target.transform.position + OFFSET; // Start Here

        Globals.Tools.Event.Subscribe(EventType.OnUpdate, Logic);
        Globals.Tools.Event.Subscribe(EventType.OnLateUpdate, Follow);
    }

    private void Logic()
    {
        // screen width / ~2.666 => 3/8 of screen (Chop the screen in 8 parts and move in the first 3 like Metal Slug)

        if (target)
        {
            lookBack = Vector3.Dot(camera.transform.right.normalized, target.transform.right.normalized) >= 1 ? false : true;
            lookForward = Globals.Generics.MainCamera.WorldToScreenPoint(target.transform.position).x > THREE_EIGHTHS_SCREEN ? true : false;

            moveTowards = lastPosition;
            if (!lookBack && lookForward) moveTowards = target.transform.position + OFFSET;
            lastPosition = camera.transform.position;
        }
        else Debug.Log("There is not a Target allocated yet");
    }

    private void Follow()
    {
        camera.transform.position = Vector3.Lerp(camera.transform.position, moveTowards, Time.deltaTime * Smoothness);
    }
}
