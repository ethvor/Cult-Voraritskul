using System.Timers;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UIElements;


public class ClickerGame : MonoBehaviour
{

    public GameObject cultHPBar;
    public GameObject enemyHPBar;
    public double cultHP;
    public double enemyHP;
    public double damagePerClick;
    public double damageRate;

    private double lastHurtTime;

    public GameObject winPanel;
    public GameObject losePanel;
    
    private bool gameOverState; //stop the click from working

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        lastHurtTime = 0.0;
        gameOverState = false;
    }

    // Update is called once per frame
    void Update()
    {
        
        
        checkGameOver();
        clickCheck();
        hurtCult();
        


    }

    private void checkGameOver()
    {
        if (!gameOverState)
        {

            if (cultHP <= 0.0)
            {
                showLosePanel();
                print("GAME OVER");
                gameOverState = true;
            }

            if (enemyHP <= 0.0)
            {
                showWinPanel();
                print("YOU WIN");
                gameOverState = true;
            }
        }
    }

    private void showWinPanel()
    {
        winPanel.SetActive(true);
    }

    private void showLosePanel()
    {
        losePanel.SetActive(true);
    }

    private void hurtCult()
    {
        if (gameOverState)
        {
            return;
        }
        if (Time.time - lastHurtTime > damageRate)
        {
            lastHurtTime = Time.time;
            print("Damaged Cult for " + damagePerClick + " damage. HP Remaining: " + cultHP);
            cultHP -= damagePerClick;
            
            // GameObject.FindGameObjectWithTag("EnemyBar") update this somehow
           // cultHPBar.GetComponent<Slider>().value = (float)cultHP;

        }
       
    }


    private void clickCheck()
    {
       
        if (Keyboard.current.spaceKey.wasPressedThisFrame)
        {
            if (gameOverState)
            {
                print("Cannot hurt the enemy, the game is already over.");
                return;
            }
            print("Dealt " + damagePerClick + " damage to enemy. HP Remaining: " + enemyHP);
            enemyHP -= damagePerClick;
            // GameObject.FindGameObjectWithTag("EnemyBar") update enemy bar somehow
            enemyHPBar.SetActive(enemyHP > 0);
        }
    }


    
    
    
}
