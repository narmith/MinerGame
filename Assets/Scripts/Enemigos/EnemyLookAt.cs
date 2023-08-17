using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EnemyLookAt : MonoBehaviour
{
    public bool enemyFollows = false;
    public GameObject enemyTarget;
    public float enemySpeed=1f;
    public DisparadorAutomatico disparador;
    public AudioSource audioWalk;

    public Renderer objectColor;
    float timedCounter = 0;

    void Awake()
    {
        if (objectColor != null)
        {
            objectColor = this.gameObject.GetComponent<Renderer>();
        }
        if (disparador)
        {
            disparador._enabled = false;
        }
    }

    void OnTriggerStay(Collider other)
    {
        if (enemyTarget != null)
        {
            if (other.CompareTag(enemyTarget.tag))
            {
                this.transform.LookAt(enemyTarget.transform);
                
                if (enemyFollows)
                {
                    if (Vector3.Distance(transform.position, enemyTarget.transform.position) >= 1)
                    {
                        transform.position += transform.forward * enemySpeed * Time.deltaTime;
                    }

                    // SOUND
                    if (audioWalk != null)
                    {
                        if (!audioWalk.isPlaying)
                        {
                            audioWalk.Play();
                        }
                    }
                }

                if (disparador)
                {
                    disparador._enabled = true;

                    if (objectColor != null)
                    {
                        /* ALTERNAR COLORES EN ATAQUE */
                        if (gameObject != null)
                        {
                            if (timedCounter <= 0)
                            { Colorcito(); }
                            else
                            { timedCounter -= 6f * Time.deltaTime; } //frecuencia
                        }
                        /* --- */
                    }
                }
            }
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.CompareTag(enemyTarget.tag))
        {
            if (disparador)
            {
                disparador._enabled = false;
                if (objectColor != null)
                {
                    objectColor.material.SetColor("_Color", Color.red);
                }
            }

            // SOUND
            if (audioWalk != null)
            {
                if (audioWalk.isPlaying)
                {
                    audioWalk.Stop();
                }
            }
        }
    }

    void Colorcito()
    {
        if (objectColor.material.color != Color.yellow)
        {
            objectColor.material.SetColor("_Color", Color.yellow);
        }
        else objectColor.material.SetColor("_Color", Color.red);

        timedCounter = 1f;
    }
}

