//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.Audio;

////Hide constructor, add a static instance, a public getter, and no setter
//public class MusicManager : MonoBehaviour
//{
//    private MusicManager() { }

//    private static MusicManager instance = null;
//    public static MusicManager Instance
//    {
//        get
//        {
//            if (instance == null)
//            {
//                instance = FindObjectOfType<MusicManager>();
//                DontDestroyOnLoad(instance.transform.root);
//            }

//            return instance;
//        }

//        private set { instance = value; }
//    }

//    [SerializeField]
//    List<AudioClip> musicTracks;

//    [SerializeField]
//    AudioSource musicSource;
    
//    [SerializeField]
//    AudioMixer mixer;

//    public enum TrackID
//    {
//        Shootout = 0;
//    }

//    public void PlayTrack(TrackID id)
//    {
//        musicSource.clip = musicTracks[(int)id];
//        musicSource.Play();
//    }
    
//    void DestroyAllClones()
//    {
//        MusicManager[] clones = FindObjectsOfType<MusicManager>();
//        foreach (MusicManager clone in clones)
//        {
//            if (clone != Instance)
//            {
//                Destroy(clone.gameObject);
//            }
//        }
//    }

//    // Start is called before the first frame update
//    void Start()
//    {
//        WorldTraveller traveller = FindObjectOfType<WorldTraveller>();
//        traveller.onEnterEncounterEvent.AddListener(OnEnterEncounterHandler);
//        traveller.onExitEncounterEvent.AddListener(OnExitEncounterHandler);

//        //Instance.PlayTrack(TrackID.Overworld);
//        DestroyAllClones();
//    }
//    private void OnEnterEncounterHandler()
//    {
//        PlayTrack(TrackID.Battle);
//    }

//    private void OnExitEncounterHandler()
//    {
//        StartCoroutine(FadeInTrackOverDuration(TrackID.Overworld, 1.0f));
//    }

//    IEnumerator FadeInTrackOverDuration(TrackID track, float duration)
//    {
//        PlayTrack(track);
//        float timer = 0.0f;
//        while (timer < duration)
//        {
//            timer += Time.deltaTime;
//            float fadeValue = timer / duration;
//            musicSource.volume = Mathf.SmoothStep(0.0f, 1.0f, fadeValue);
//            yield return new WaitForEndOfFrame();
//        }
//    }

//    public void SetMusicVolume(float volumeDB)
//    {
//        mixer.SetFloat("VolumeMusic", volumeDB);
//    }
//}
