using UnityEngine;
using System.Collections;
using System;
using B25.PoolSystem;
using B25.EventSystem;

internal static class Globals
{
    internal static class Tools
    {
        internal static readonly PoolSystem ObjectPooling;
        internal static readonly EventSystem Event;

        static Tools()
        {
            ObjectPooling = new PoolSystem(UnityEngine.Object.FindObjectOfType<GameManager>().poolData);
            Event = new EventSystem();
        }
    }

    internal static class Generics
    {
        internal static readonly Camera MainCamera = Camera.main;
        internal const float WorldLength = 200;
    }
    
    internal static class Vectors
    {
        internal static readonly Quaternion QuaternionIdentity = Quaternion.identity;
        internal static readonly Vector3 Vector3Zero = Vector3.zero;
        internal static readonly Vector3 Vector3Roght = Vector3.right;
        internal static readonly Vector3 Vector3Left = Vector3.left;
        internal static readonly Vector3 Vector3Up = Vector3.up;
        internal static readonly Vector3 Vector3Down = Vector3.down;
    }

    internal static class Tags
    {
        // Reducing string characters we're consuming less memory
        internal const string Enemy = "NMY";
        internal const string Loot = "LT";
        internal const string RocketAmmo = "RCKT";
    }
    
    internal static class Layers
    {
        internal static readonly LayerMask Ground = 1 << 8;
        internal static readonly LayerMask Enemy = 1 << 11;
        internal static readonly LayerMask Loot = 1 << 17;
        internal static readonly LayerMask Reward = 1 << 18;
        internal static readonly LayerMask ProjectileDirection = 1 << 19;
    }
    
    internal static class SoundEffects
    {
        internal static readonly SoundEffect? PistolShot = new SoundEffect(0, .05f, 1);
        internal static readonly SoundEffect? PickUp = new SoundEffect(1, .2f, 1);
        internal static readonly SoundEffect? Death = new SoundEffect(2, .35f, 1);
        internal static readonly SoundEffect? ShotGun = new SoundEffect(3, .15f, 1);
        internal static readonly SoundEffect? Stab = new SoundEffect(4, .4f, 1.25f);
        internal static readonly SoundEffect? MissionStart = new SoundEffect(5, .35f, 1);
    }
}

internal static class Extensions
{
    internal static IEnumerator PlaySoundEffect(this AudioSource source, SoundEffect? soundEffect, Action onComplete, AudioClip[] clips)
    {
        source.PlayOneShot(clips[soundEffect.Value.clip]);
        source.volume = soundEffect.Value.volume;
        source.pitch = soundEffect.Value.pitch;

        while (source.isPlaying)
        {
            yield return null;
        }
        onComplete();
    }

    ///// <summary>
    ///// Return true if the GameObject is seen by the camera
    ///// </summary>
    //internal static void OffScreeRecycling(this Renderer renderer)
    //{
    //    //Plane[] planes = GeometryUtility.CalculateFrustumPlanes(MAIN_CAMERA);
    //    //return GeometryUtility.TestPlanesAABB(planes, renderer.bounds);
    //}
}
