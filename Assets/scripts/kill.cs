using UnityEngine;

public class kill : MonoBehaviour
{
    void Update()
    {
        if (Input.touchCount > 0) // At least one touch detected
        {
            Touch touch = Input.GetTouch(0); // Get the first touch

            if (touch.phase == TouchPhase.Began) // Touch just started
            {
                Ray ray = Camera.main.ScreenPointToRay(touch.position);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit))
                {
                    if (hit.collider.gameObject == gameObject) // Enemy was touched
                    {
                        ScoreManager.instance.AddScore(1); // Add 1 point
                        AudioManager.instance.PlayEnemyKilledSound();
                        Destroy(gameObject); // Destroy enemy
                       
                    }
                }
            }
        }
    }

   
}
