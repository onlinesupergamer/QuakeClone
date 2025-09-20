using UnityEngine;
using UnityEngine.Animations;

public class LevelMusic : MonoBehaviour
{
    public AudioClip[] MusicClips;
    public AudioSource MusicSource;
    public bool bPlayMusic;
    public bool bPlaySongByIndex;
    public int SongIndex;

    /*
     * This should kind of just.... work?
     */

    void Start()
    {
        if (!bPlayMusic) return;

        if (bPlaySongByIndex) 
        {
            if (MusicClips.Length < 1 || MusicClips[SongIndex] == null) 
            {
                Debug.LogWarning("Either no music found in list, or SongIndex is empty!");
                return;
            }

            MusicSource.clip = MusicClips[SongIndex];
            MusicSource.Play();
        }
    }


}
