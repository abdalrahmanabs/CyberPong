using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class GameController : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI rightScoreTxt, leftScoreTxt;
    int rightScore, leftScore;
    GameObject Ball;
    BallController ballController;
    bool started = false;
    // Start is called before the first frame update
    void Start()
    {
        Ball=GameObject.FindWithTag("Ball").gameObject;
        ballController=Ball.GetComponent<BallController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (started)
            return;
        if (Input.GetKey(KeyCode.Space))
            {
                started = true;
                ballController.Go();
            }
    }

    public void ScoreRightGoal()
    {
        print("Right Scored");
        rightScore++;
        UpdateUI();
        ResetBall();
    }

    public void ScoreLeftGoal()
    {
        print("Left Scored");
        leftScore++;
        UpdateUI();
        ResetBall();
    }

    public void UpdateUI()
    {
        rightScoreTxt.text = rightScore.ToString();
        leftScoreTxt.text = leftScore.ToString();

    }

    void ResetBall()
    {
        ballController.Stop();
        Ball.transform.position=ballController.startingPos;
        ballController.Go();
    }
}
