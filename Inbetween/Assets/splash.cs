using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class splash : MonoBehaviour
{
    private Image Loadblock;
    private UnityEngine.Video.VideoPlayer Video;
    private AudioSource audio1;
    private AudioSource audio2;
    private Image Logo;
    private float removeblock;
    private float fadeinlogo;
    private float sound1start;
    private float sound2start;
    private float startvid;
    private float time;
    private float fade;
    private float tomenu;
    // Start is called before the first frame update
    void Start()
    {
        audio1 = gameObject.transform.Find("Kvid").gameObject.GetComponentInChildren(typeof(AudioSource)) as AudioSource;
        audio2 = gameObject.transform.Find("Kimg").gameObject.GetComponentInChildren(typeof(AudioSource)) as AudioSource;
        audio1.Stop();
        audio2.Stop();
        Loadblock = gameObject.transform.Find("loadblock").gameObject.GetComponentInChildren(typeof(Image)) as Image;
        Video = gameObject.transform.Find("Kvid").gameObject.GetComponentInChildren(typeof(UnityEngine.Video.VideoPlayer)) as UnityEngine.Video.VideoPlayer;
        Video.Stop();
        Video.isLooping = false;
        Logo = gameObject.transform.Find("Kimg").gameObject.GetComponentInChildren(typeof(Image)) as Image;
        Logo.color = new Color(1,1,1,0);
        startvid = 0.1f;
        removeblock = 0.7f;
        sound1start = 2.3f;
        sound2start = 5.7f;
        fadeinlogo = 5f;
        time = 0;
        fade = 0;
        tomenu = 8.2f;
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time > startvid)
        {
            Video.Play();
            startvid += 100;
        }
        if (time > sound1start)
        {
            audio1.Play();
            sound1start += 100;
        }
        if (time > sound2start)
        {
            audio2.Play();
            sound2start += 100;
        }
        if (time > removeblock)
        {
            Loadblock.color = new Color(1,1,1,0);
            removeblock += 100;
        }
        if (time > fadeinlogo)
        {
            fade += Time.deltaTime;
            Logo.color = new Color(1, 1, 1, fade);
        }
        if (time > tomenu)
        {
            SceneManager.LoadScene("Menu");
        }
    }
}
