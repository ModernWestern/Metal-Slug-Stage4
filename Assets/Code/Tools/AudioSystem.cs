using UnityEngine;
using B25.PoolSystem;

public class AudioSystem
{
    private AudioClip[] clips;
    private MonoBehaviour mono;
    private AudioListener listener;

    public AudioSystem(AudioClip[] clips, MonoBehaviour mono)
    {
        this.clips = clips;
        this.mono = mono;

        var listener = new GameObject("Listener");
        listener.AddComponent<AudioListener>();

        Globals.Tools.Event.Subscribe(EventType.OnSFX, PlayOnShot);
    }

    private void PlayOnShot(object obj)
    {
        var sfx = obj as SoundEffect?;
        var source = Globals.Tools.ObjectPooling.Grab(PoolType.AudioSource);
        mono.StartCoroutine(source.GetComponent<AudioSource>().PlaySoundEffect(sfx, () => OnComplete(source), clips));
    }

    private void OnComplete(GameObject source)
    {
        Globals.Tools.ObjectPooling.Drop(PoolType.AudioSource, source);
    }
}