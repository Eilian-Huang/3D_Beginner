using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameEnding : MonoBehaviour
{
    // Time of fading in or fading out
    public float fadeDuration = 1f;
    public float displayImageDuration = 1f;
    // Reference of game player(JohnLemon)
    public GameObject player;
    // When JohnLemon is escaped
    public CanvasGroup exitBackgroundImageCanvasGroup;
    public AudioSource exitAudio;
    // When JohnLemon is caught
    public CanvasGroup caughtBackgroundImageCanvasGroup;
    public AudioSource caughtAudio;
    
    bool m_IsPlayerAtExit;
    bool m_IsPlayerCaught;
    // Timer to ensure that the game does not end before fading in and out
    float m_Timer;
    bool m_HasAudioPlayed;

    // Detect game objects controlled by the player
    void OnTriggerEnter (Collider other)
    {
        // Game ends only if JohnLemon hits box collider
        if (other.gameObject == player)
        {
            m_IsPlayerAtExit = true;
        }
    }

    public void CaughtPlayer ()
    {
        m_IsPlayerCaught = true;
    }

    // Update is called once per frame
    void Update ()
    {
        if(m_IsPlayerAtExit)
        {
            EndLevel (exitBackgroundImageCanvasGroup, false, exitAudio);
        }
        else if(m_IsPlayerCaught)
        {
            EndLevel (caughtBackgroundImageCanvasGroup, true, caughtAudio);
        }
    }

    // End the Game, fading in & out image, restart if being caught
    void EndLevel (CanvasGroup imageCanvasGroup, bool doRestart, AudioSource audioSource)
    {
        if(!m_HasAudioPlayed)
        {
            audioSource.Play();
            m_HasAudioPlayed = true;
        }
        // Set the timer equal to itself plus deltaTime
        m_Timer += Time.deltaTime;
        /*
         * When the timer is 0, the Alpha value should be 0
         * When the timer does not exceed fadeDuration, the Alpha value should be 1 
         * To obtain this value, the timer value can be divided by the duration
         */
        imageCanvasGroup.alpha = m_Timer / fadeDuration;
        // When the timer value is greater than the duration, the fade-in and fade-out will end
        if(m_Timer > fadeDuration + displayImageDuration)
        {
            if (doRestart)
            {
                // Reload the level
                SceneManager.LoadScene(0);
            }
            else
            {
                Application.Quit ();
            }
        }
    }
}
