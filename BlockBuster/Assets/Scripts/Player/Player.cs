using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;


public class Player : MonoBehaviour {

  public int health;
  public float playerSpeed = 800.0f;
  public Material pColor;
  public Text colorText;
  public event Action<Player> onPlayerDeath;
  
  private void Sleep()
  {
    colorText.text = "Selected Color: " + Keep.pColor;
    ChangePlayerColor();

    if (Keep.OversizedBall)
    {
      this.gameObject.transform.localScale = new Vector3(3.0f, 3.0f, 3.0f);
      Debug.Log("Big Ball: " + Keep.OversizedBall);
    } else 
        this.gameObject.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
  }

  public void ChangePlayerColor()
{
  switch (Keep.pColor)
  {
    case 1:
    pColor.color = Color.black;
    break;
    case 2:
    pColor.color = Color.blue;
    break;
    case 3:
    pColor.color = Color.yellow;
    break;
    default:
    pColor.color = Color.black;
    break;
  }
}

  private void FixedUpdate()
  {
    float moveHorizontal = Input.GetAxis("Horizontal");
    float moveVertical = Input.GetAxis("Vertical");
    
    Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

    GetComponent<Rigidbody>().AddForce(movement * playerSpeed *
    Keep.PlayerSpeed * Time.deltaTime);
  }

  void OnCollisionEnter (Collision col) {
      Enemy enemy = col.collider.gameObject.GetComponent<Enemy>();
      if(enemy) {
        collidedWithEnemy(enemy);
      }
  }

  void collidedWithEnemy(Enemy enemy) {
    enemy.Attack(this);
    if(health <= 0) {
      if(onPlayerDeath != null) {
        onPlayerDeath(this);
      }
    }
  }
}
