using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthBar : MonoBehaviour
{
    // Texture of blood bar
    public Texture2D bloodRed;
    public Texture2D bloodBlack;

    // Model height of target enemy
    float enemyHeight;
    // Health of enemy
    private float HEALTH;
    private float MAXHEALTH;
    // Main Camera
    private Camera m_camera;

    // Start is called before the first frame update
    void Start()
    {
        HEALTH = transform.gameObject.GetComponent<EnemyProperty>().GetEnemyHealth();
        MAXHEALTH = transform.gameObject.GetComponent<EnemyProperty>().MAXHEALTH;
        m_camera = Camera.main;
        // Get initial height of model
        float size_y = transform.GetComponentInChildren<Collider>().bounds.size.y;
        // Get scal proportion of model
        float scal_y = transform.localScale.y;
        enemyHeight = (size_y * scal_y);
        // Add offset
        enemyHeight += 0.5f;
    }

    void OnGUI ()
    {
        // Get coordinates of target enemy's head in 3D world
        Vector3 worldPosition = new Vector3(transform.position.x, 
            transform.position.y + enemyHeight, transform.position.z);
        // Convert 3D coordinates to coordinates on the 2D screen
        Vector2 position = m_camera.WorldToScreenPoint (worldPosition);
        // Get 2D coordinates of target enemy
        position = new Vector2 (position.x, Screen.height - position.y);

        // Calculate the width and height of the health bar
        Vector2 bloodSize = GUI.skin.label.CalcSize(new GUIContent(bloodRed));
        // Calculate the red blood bar display area by health
        float blood_width = bloodRed.width * HEALTH / MAXHEALTH;
        // Scal to fit
        bloodSize.y /= 16; bloodSize.x /= 4; blood_width /= 4;

        // Draw black health bar
        GUI.DrawTexture(new Rect(position.x - (bloodSize.x/2), position.y-bloodSize.y, 
             bloodSize.x, bloodSize.y), bloodBlack);
        // Draw health bar
        GUI.DrawTexture(new Rect(position.x - (bloodSize.x/2), position.y-bloodSize.y,
             blood_width, bloodSize.y), bloodRed);
    }
}
