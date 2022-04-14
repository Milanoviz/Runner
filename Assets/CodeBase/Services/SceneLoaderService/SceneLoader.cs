using UnityEngine.SceneManagement;

namespace CodeBase.Services.SceneLoaderService
{
    public class SceneLoader
    {
        public void RestartLevel()
        {
            SceneManager.LoadScene(0);
        }
    }
}