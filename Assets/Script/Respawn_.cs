using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Respawn_ : MonoBehaviour
{
    public InputField Name;
    public Animator anim;
    public Animator Cameranim;
    public GameObject Image;
    public void Respawn()
    {
        SceneManager.LoadScene("Game");
    }
    public void Join()
    {
        Image.active = true;
        Cameranim.SetBool("fade", true);
        anim.SetBool("fade", true);
        StaticInfo.Lobby = Name.text;
    }
}
