using UnityEngine.SceneManagement;
using UnityEngine;

public static class ButtonFunctions

{
    public static void PlayGameOnClick(int index)
    {
        if (ButtonManager.Instance != null)
        {
            ButtonManager.Instance.SetCurrentIndex(index);

            if (index >= 0 && index < ButtonManager.Instance.listSong.Count)
            {
                SongData song = ButtonManager.Instance.listSong[index];

                string pathMidi = song.PathMidi;
                ButtonManager.Instance.SetJsonFilePath(pathMidi);
                string pathAudio = song.PathAudio;
                ButtonManager.Instance.SetAudioClipPath(pathAudio);

                SceneManager.LoadScene("GamePlay");
               
            }

            Debug.Log("Playing song at index: " + index);
        
        }
    }

    public static void ButtonNext()
    {
        if (ButtonManager.Instance != null)
        {
            ButtonManager.Instance.IncrementIndex();

            if (ButtonManager.Instance.CurrentIndex >= 0 && ButtonManager.Instance.CurrentIndex < ButtonManager.Instance.listSong.Count)
            {
                SongData song = ButtonManager.Instance.listSong[ButtonManager.Instance.CurrentIndex];
                string pathMidi = song.PathMidi;
                ButtonManager.Instance.SetJsonFilePath(pathMidi);
                string pathAudio = song.PathAudio;
                ButtonManager.Instance.SetAudioClipPath(pathAudio);
            }

            Debug.Log("Next song selected: " + ButtonManager.Instance.CurrentIndex);
        }
    }

    public static void ButtonRestart()
    {
        SceneManager.LoadScene("GamePlay");
       
    }
}
