using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


namespace System
{
    [CreateAssetMenu(fileName = "SceneService", menuName = "ScriptableObjects/System/SceneService")]
    public class SO_SceneService : ScriptableObject
    {
        private readonly List<string> scenesInBuild = new List<string>();
        private readonly List<string> loadedScenes = new List<string>();


        private string m_ActiveScene;
        public string ActiveScene { get { return m_ActiveScene; } }


        private void OnEnable()
        {
            InitSceneLists();
            CompareSceneNamesToScenesInBuild();
        }

        private void InitSceneLists()
        {
            int sceneCount = SceneManager.sceneCountInBuildSettings;

            for (int i = 0; i < sceneCount; i++)
            {
                string scene = System.IO.Path.GetFileNameWithoutExtension(SceneUtility.GetScenePathByBuildIndex(i));
                scenesInBuild.Add(scene);

                if (SceneManager.GetSceneByName(scene).IsValid())
                {
                    loadedScenes.Add(scene);
                }
            }
        }

        private void CompareSceneNamesToScenesInBuild()
        {
            bool isIncomplete = false;
            foreach (string scene in scenesInBuild)
            {
                isIncomplete = !C_SceneNames.SCENE_NAMES.Contains(scene);
                if (isIncomplete)
                {
                    Debug.LogError("SceneNames does not contain this scene: " + scene);
                    break;
                }
            }
        }

        public void LoadScene(string sceneName, bool loadAdditive = false, bool loadAsync = true)
        {
            if (!scenesInBuild.Contains(sceneName))
            {
                Debug.LogError(sceneName + " does not exist in this build.");
                return;
            }

            if (loadedScenes.Contains(sceneName))
            {
                Debug.LogError("Scene already loaded ." + sceneName + " Could not be loaded twice.");
                return;
            }

            m_ActiveScene = sceneName;

            if (loadAdditive)
            {

                if (loadAsync)
                {
                    SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Additive);
                }
                else
                {
                    SceneManager.LoadScene(sceneName, LoadSceneMode.Additive);
                }
            }
            else
            {
                loadedScenes.Clear();
                if (loadAsync)
                {
                    SceneManager.LoadSceneAsync(sceneName, LoadSceneMode.Single);
                }
                else
                {
                    SceneManager.LoadScene(sceneName, LoadSceneMode.Single);
                }
            }
            loadedScenes.Add(sceneName);
        }

        public void UnloadScene(string sceneName)
        {
            lock (loadedScenes)
            {
                if (!loadedScenes.Contains(sceneName))
                {
                    Debug.LogError("Scene already unloaded: " + sceneName);
                    return;
                }

                loadedScenes.Remove(sceneName);
                SceneManager.UnloadSceneAsync(sceneName);
                m_ActiveScene = SceneManager.GetActiveScene().name;
            }
        }
    }
}