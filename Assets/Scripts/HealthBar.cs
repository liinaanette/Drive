using UnityEngine;
using System.Collections;

// For drawing and managing the health bar
public class HealthBar : MonoBehaviour
{
    public float barDisplay; //current progress
    public float health = 1f;
    public Vector2 pos = new Vector2(20, 40);
    public Vector2 size = new Vector2(60, 20);
    public Texture2D emptyTex;
    public Texture2D fullTex;

    void OnGUI()
    {
        //draw the background:
        GUI.BeginGroup(new Rect(pos.x, pos.y, size.x, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), emptyTex);

        //draw the filled-in part:
        GUI.BeginGroup(new Rect(0, 0, size.x * barDisplay, size.y));
        GUI.Box(new Rect(0, 0, size.x, size.y), fullTex);
        GUI.EndGroup();
        GUI.EndGroup();
    }

    // How much should be drawn and how much health is still remaining
    public void Hit(float damage)
    {
        barDisplay += damage;
        health -= damage;
        if (health <= 0f)
        {
            FindObjectOfType<GameController>().EndGame();
        }
    }


}