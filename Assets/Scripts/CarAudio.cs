using System;
using UnityEngine;

public class CarAudio : MonoBehaviour
{
    // This script reads some of the car's current properties and plays sounds accordingly.
    // The engine sound can be a simple single clip which is looped and pitched, or it
    // can be a crossfaded blend of four clips which represent the timbre of the engine
    // at different RPM and Throttle state.

    // the engine clips should all be a steady pitch, not rising or falling.

    // when using four channel engine crossfading, the four clips should be:
    // lowAccelClip : The engine at low revs, with throttle open (i.e. begining acceleration at very low speed)
    // highAccelClip : Thenengine at high revs, with throttle open (i.e. accelerating, but almost at max speed)
    // lowDecelClip : The engine at low revs, with throttle at minimum (i.e. idling or engine-braking at very low speed)
    // highDecelClip : Thenengine at high revs, with throttle at minimum (i.e. engine-braking at very high speed)

    // For proper crossfading, the clips pitches should all match, with an octave offset between low and high.

    public AudioClip lowAccelClip;                                              // Audio clip for low acceleration
    public AudioClip lowDecelClip;                                              // Audio clip for low deceleration
    public AudioClip highAccelClip;                                             // Audio clip for high acceleration
    public AudioClip highDecelClip;                                             // Audio clip for high deceleration
    public float pitchMultiplier = 1f;                                          // Used for altering the pitch of audio clips
    public float lowPitchMin = 1f;                                              // The lowest possible pitch for the low sounds
    public float lowPitchMax;                                              // The highest possible pitch for the low sounds
    public float highPitchMultiplier = 0.25f;                                   // Used for altering the pitch of high sounds
    public float maxRolloffDistance = 500;                                      // The maximum distance where rollof starts to take place
    public float dopplerLevel = 1;                                              // The mount of doppler effect used in the audio
    public bool useDoppler = true;                                              // Toggle for using doppler

    private AudioSource m_LowAccel; // Source for the low acceleration sounds
    private AudioSource m_LowDecel; // Source for the low deceleration sounds
    private AudioSource m_HighAccel; // Source for the high acceleration sounds
    private AudioSource m_HighDecel; // Source for the high deceleration sounds
    private bool m_StartedSound; // flag for knowing if we have started sounds
    private Carro carro; // Reference to car we are controlling

    private void StartSound()
    {
        carro = GetComponent<Carro>();
        m_HighAccel = SetUpEngineAudioSource(highAccelClip);
        m_StartedSound = true;
        lowPitchMax = carro.rotacaoMaxima / 1000;
    }
    private void StopSound()
    {
        foreach (var source in GetComponents<AudioSource>())
        {
            Destroy(source);
        }

        m_StartedSound = false;
    }

    private void Update()
    {
        float camDist = 9;
        if (m_StartedSound && camDist > maxRolloffDistance*maxRolloffDistance)
        {
            StopSound();
        }
        if (!m_StartedSound && camDist < maxRolloffDistance*maxRolloffDistance)
        {
            StartSound();
        }

        if (m_StartedSound)
        {
            float pitch = ULerp(lowPitchMin, lowPitchMax, carro.rotacao);
            pitch = Mathf.Min(lowPitchMax, pitch);
                m_HighAccel.pitch = pitch*pitchMultiplier*highPitchMultiplier;
                m_HighAccel.dopplerLevel = useDoppler ? dopplerLevel : 0;
                m_HighAccel.volume = 1;
        }
    }


    private AudioSource SetUpEngineAudioSource(AudioClip clip)
    {
        AudioSource source = gameObject.AddComponent<AudioSource>();
        source.clip = clip;
        source.volume = 0;
        source.loop = true;

        source.time = UnityEngine.Random.Range(0f, clip.length);
        source.Play();
        source.minDistance = 5;
        source.maxDistance = maxRolloffDistance;
        source.dopplerLevel = 0;
        return source;
    }
    private static float ULerp(float from, float to, float value)
    {
        return (1.0f - value)*from + value*to;
    }
}

