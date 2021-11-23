using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LoadingScene : MonoBehaviour
{
    [SerializeField] Animator  loadanim;

    public void LoadScreen()
    {
        
    }

    private void Update()
    {
        if (loadanim.GetCurrentAnimatorStateInfo(0).normalizedTime >1)
        {
            SceneManager.LoadScene(1);
        }

    }


}
