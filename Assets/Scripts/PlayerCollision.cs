using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerCollision : MonoBehaviour
{
   private void OnTriggerEnter2D(Collider2D collision)
   {
       if (collision.CompareTag("RespawnTrigger"))
       {
            TakeDamage();

        }


       void TakeDamage()
       {
            HealthManager.health--;

            if (HealthManager.health <= 0)
            {
                StartCoroutine(Die());
             
            }

            else
            {
                Respawn();
                StartCoroutine(GetHurt());
            }
        }

        void Respawn()
        {
            transform.position = RespawnController.Instance.respawnPoint.position;
        }





        IEnumerator GetHurt()
        { 
            Physics2D.IgnoreLayerCollision(7,8, true);
            yield return new WaitForSeconds(3);
            Physics2D.IgnoreLayerCollision(7,8,false);
        }


        IEnumerator Die()
        { 
            yield return new WaitForSeconds(0.1f);
            
            GameManager.isGameOver = true;
            gameObject.SetActive(false);
        }


   }



}
