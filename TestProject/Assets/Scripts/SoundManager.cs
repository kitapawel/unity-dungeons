using UnityEngine;
using System.Collections;

public class SoundManager : Singleton<SoundManager>
{

    [SerializeField]
    private AudioClip footsteps;
    [SerializeField]
    private AudioClip chains;
    [SerializeField]
    private AudioClip foliage;
    [SerializeField]
    private AudioClip chest;
    [SerializeField]
    private AudioClip door;
    [SerializeField]
    private AudioClip swing;

    public AudioClip Footsteps
    {
        get
        {
            return footsteps;
        }

        set
        {
            footsteps = value;
        }
    }

    public AudioClip Chains
    {
        get
        {
            return chains;
        }

        set
        {
            chains = value;
        }
    }

    public AudioClip Foliage
    {
        get
        {
            return foliage;
        }

        set
        {
            foliage = value;
        }
    }

    public AudioClip Chest
    {
        get
        {
            return chest;
        }

        set
        {
            chest = value;
        }
    }

    public AudioClip Door
    {
        get
        {
            return door;
        }

        set
        {
            door = value;
        }
    }

    public AudioClip Swing
    {
        get
        {
            return swing;
        }

        set
        {
            swing = value;
        }
    }
}
