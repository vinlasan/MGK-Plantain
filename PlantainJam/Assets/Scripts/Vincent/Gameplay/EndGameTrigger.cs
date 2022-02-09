using UnityEngine;

namespace Gameplay
{
    public class EndGameTrigger : MonoBehaviour
    {
        [SerializeField] string sceneName = default;
        void OnTriggerEnter2D(Collider2D other)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName);
        }
    }
}