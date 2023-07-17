using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace newnextscene1
{

    public class NextScene1 : MonoBehaviour
    {
        public GameObject Button;
        public bool active = true;
        private Scene _scene;
        private void newAwake()
        {
            _scene = SceneManager.GetActiveScene();
        }
        void StartnewGame()
        {
            if (active)
            {
                Button.SetActive(false);
                active = false;
                SceneManager.LoadScene(_scene.buildIndex + 1);
            }
            else if (!active)
            {
                Button.SetActive(true);
                active = true;
            }
        }
    }
}
