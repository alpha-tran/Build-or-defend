using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class HealthMainHome : MonoBehaviour
{
    private int count = 0;  // Đếm số lượng kẻ thù đã va chạm
    public UnityEvent GameOver;  // Sự kiện khi trò chơi kết thúc

    private void OnTriggerEnter(Collider other)
    {
     
            Debug.Log("Enemy collided and destroyed");

            if (other.CompareTag("Enemy"))
            {
                count++;  // Tăng biến đếm
                Destroy(other.gameObject);
            }

    }

    private void Update()
    {
        if (count >= 11)  
        {
            GameOver?.Invoke(); 
        }
    }
}
