using System;
using UnityEngine;

public class GameOverManager : MonoBehaviour
{
    // 引用 GameManager
    public ScoreManager scoreManager;

    // 为了确保你设置的是 GameBoard 的 Collider2D
    public Collider2D gameBoardCollider;

    private void OnTriggerExit2D(Collider2D other)
    {
        // 检查触碰的对象是否是 Player
        if (other.CompareTag("Player"))
        {
            // 设置 GameManager 的 Score 为 "Game Over"
            scoreManager.SetGameOverScore();

            // 停止游戏，可以通过暂停游戏或直接结束游戏来实现
            //Time.timeScale = 0f;  // 停止游戏，暂停时间
            Debug.Log("game over");
        }
    }
}
