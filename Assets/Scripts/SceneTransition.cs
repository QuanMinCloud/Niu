using System;
using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneTransition : MonoBehaviour
{
        private Animator transitionAnim;
        
        private void Start()
        {
                transitionAnim = GetComponent<Animator>();
        }

        public void LoadScene(string sceneName)
        {
                SceneManager.LoadScene(sceneName);
//                StartCoroutine(Transition(sceneName));
        }

        IEnumerator Transition(string sceneName)
        { 
//                transitionAnim.SetTrigger("end");
                yield return new WaitForSeconds(1);
                print("12312312");
                SceneManager.LoadScene(sceneName);
        }
}
