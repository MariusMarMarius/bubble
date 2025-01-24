using System;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    // ���� GameManager
    public ScoreManager scoreManager;

    // Ϊ��ȷ�������õ��� GameBoard �� Collider2D
    public Collider2D gameBoardCollider;

    private void OnTriggerExit2D(Collider2D other)
    {
        // ��鴥���Ķ����Ƿ��� Player
        if (other.CompareTag("Player"))
        {
            // ���� GameManager �� Score Ϊ "Game Over"
            scoreManager.SetGameOverScore();

            // ֹͣ��Ϸ������ͨ����ͣ��Ϸ��ֱ�ӽ�����Ϸ��ʵ��
            //Time.timeScale = 0f;  // ֹͣ��Ϸ����ͣʱ��
            Debug.Log("game over");
        }
    }
}
