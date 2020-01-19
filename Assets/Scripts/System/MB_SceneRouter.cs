using UnityEngine;
using UnityEditor;
using UI;


namespace System
{
    public class MB_SceneRouter : MonoBehaviour
    {
        [Header("Scene Service")]
        [SerializeField] private SO_SceneService SceneService = null;

        [Header("UI Events")]
        [SerializeField] private SO_ButtonClickEvent Button_Start_OnClickEvent = null;
        [SerializeField] private SO_ButtonClickEvent Button_Restart_OnClickEvent = null;
        [SerializeField] private SO_ButtonClickEvent Button_Exit_OnClickEvent = null;

        [Header("GameLoop Events")]
        [SerializeField] private SO_Event_GameEnd GameEndEvent = null;


        private void Awake()
        {
            SceneService.LoadScene(C_SceneNames.START_MENU, true, true);
        }

        private void OnEnable()
        {
            Button_Start_OnClickEvent.OnButtonClickEvent += Start_OnClick;
            Button_Restart_OnClickEvent.OnButtonClickEvent += Restart_OnClick;
            Button_Exit_OnClickEvent.OnButtonClickEvent += Exit_OnClick;

            GameEndEvent.OnGameEndEvent += OnGameEnd;
        }

        private void OnDisable()
        {
            Button_Start_OnClickEvent.OnButtonClickEvent -= Start_OnClick;
            Button_Restart_OnClickEvent.OnButtonClickEvent -= Restart_OnClick;
            Button_Exit_OnClickEvent.OnButtonClickEvent -= Exit_OnClick;

            GameEndEvent.OnGameEndEvent -= OnGameEnd;
        }

        private void Start_OnClick()
        {
            SceneService.LoadScene(C_SceneNames.LEVEL_1, true);
            SceneService.UnloadScene(C_SceneNames.START_MENU);
        }

        private void Restart_OnClick()
        {
            SceneService.UnloadScene(C_SceneNames.LEVEL_1);
            SceneService.UnloadScene(C_SceneNames.END_SCREEN);
            SceneService.LoadScene(C_SceneNames.LEVEL_1, true);
        }

        private void Exit_OnClick()
        {
#if UNITY_EDITOR
            EditorApplication.isPlaying = false;
#else
            Application.Quit();
#endif
        }

        private void OnGameEnd()
        {
            SceneService.LoadScene(C_SceneNames.END_SCREEN, true, true);
        }
    }
}