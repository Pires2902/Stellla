using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class Planeta : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)

    {

        Debug.Log("O objeto " + name + " colidiu com o objeto " + other.name);


        }
        public void ChangeScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }
    
    }

