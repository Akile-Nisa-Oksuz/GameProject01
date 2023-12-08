using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;
    public Transform player;

    public int score;
    public int levelItime;
    public AudioClip[] levelSounds;
    public Transform[] Particles;

    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;   

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlaySound(AudioClip sound, Vector3 ownerPos)
    {
        GameObject obj = SoundFXPooler.curret.GetpooledObject();
        AudioSource audio = obj.GetComponent<AudioSource>();

        obj.transform.position = ownerPos;
        obj.SetActive(true);
        audio.PlayOneShot(sound);
        StartCoroutine(DisableSound(audio));

    }

    IEnumerator DisableSound(AudioSource audio)
    {
        while (audio.isPlaying)
            yield return new WaitForSeconds(0.5f);
        audio.gameObject.SetActive(false);
    }

}
