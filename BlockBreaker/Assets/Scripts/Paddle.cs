using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public struct Position {
    public float x;
    public float y;

    public Position(float x, float y) {
        this.x = x;
        this.y = y;
    }

}
public class Paddle : MonoBehaviour
{
[SerializeField] float screenWidthInUnits = 16f;
[SerializeField] float minX = 0f;
[SerializeField] float maxX = 16f;

GameSession gameSession;
Ball ball;
    // Start is called before the first frame update
    void Start()
    {
        this.gameSession = FindObjectOfType<GameSession>();
        this.ball = FindObjectOfType<Ball>();
    }

    // Update is called once per frame
    void Update()
    {

        float mousePos = ((Input.mousePosition.x / Screen.width) * screenWidthInUnits); 
        Position paddlePos = getPaddlePosition();

        //clamp the mouse position so that the paddle will stay within the screen boundaries
        float clampedXPosition = Mathf.Clamp(paddlePos.x, minX, maxX);

        transform.position = new Vector2(clampedXPosition, paddlePos.y);
    
    }

    private Position getPaddlePosition() {
        if  (this.gameSession.isAutoPlayEnabled()) {
            return new Position(this.ball.transform.position.x, transform.position.y);
        } else {
            return new Position(((Input.mousePosition.x / Screen.width) * screenWidthInUnits), transform.position.y);
        }
    }
}
