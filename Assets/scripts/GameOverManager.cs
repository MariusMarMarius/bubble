using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameOverManager : MonoBehaviour
{
    // ���� GameManager
    public ScoreManager scoreManager;
    public GameObject gameOverMenu;  // ��Ϸ��ͣʱ��ʾ�Ĳ˵���������һ�� UI ��壩
    private bool isGameOver = false;  // �����жϵ�ǰ�Ƿ����
    public TextMeshProUGUI scoreText;
    public GameObject pauseButton;

    // Ϊ��ȷ�������õ��� GameBoard �� Collider2D
    public Collider2D gameBoardCollider;
    void Start()
    {
        // ��ʼʱ��Ϸû����ͣ
        gameOverMenu.SetActive(false);  // ��ͣ�˵�Ĭ�ϲ��ɼ�
    }

    public void ToggleGameOver()
    {
        isGameOver = !isGameOver;  // �л���ͣ��־
        if (isGameOver)
        {
            // ��ͣ��Ϸ
            Time.timeScale = 0f;  // ����ʱ��Ϊ 0����ͣ����ʱ����صĲ���
            gameOverMenu.SetActive(true);  // ��ʾ��ͣ�˵�
            scoreText.text = "Score: " + GameManager.Instance.score;
            pauseButton.SetActive(false);
        }
    
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        // ��鴥���Ķ����Ƿ��� Player
        if (other.CompareTag("Player"))
        {
            AudioClip dieSound = Resources.Load<AudioClip>("voice/die");
            AudioSource audioSource = this.gameObject.AddComponent<AudioSource>();
            if (dieSound != null)
            {
                audioSource.clip = dieSound;
                audioSource.Play();
            }
            else
            {
                Debug.LogWarning("Splash sound not found in Resources/voice folder!");
            }
            ToggleGameOver();
            
            

            // ֹͣ��Ϸ������ͨ����ͣ��Ϸ��ֱ�ӽ�����Ϸ��ʵ��
            //Time.timeScale = 0f;  // ֹͣ��Ϸ����ͣʱ��
            Debug.Log("game over");
        } else
        {
            Destroy(other.gameObject);
        }
    }
}
