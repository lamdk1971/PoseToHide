using DigitalRuby.AdvancedPolygonCollider;
using System.Collections;
using System.Collections.Generic;
using System.Security.Authentication.ExtendedProtection;
using UnityEngine;

public class Character : MonoBehaviour
{
    // Sprite
    [SerializeReference]
    private List<Sprite> listPoseSprite;
    int currentSpriteIndex = 0;

    // collider
    private PolygonCollider2D polygonCollider2D;

    // drag and drop
    private Vector3 offset;

    private bool isDragging = false;
    [SerializeReference]
    float dragTime;
    float currentTime;

    public PolygonCollider2D frameCollider;
    public bool isTouch = false;
    public bool isPass = false;
    void Start()
    {
        polygonCollider2D = gameObject.GetComponent<PolygonCollider2D>();
    }

    private void Update()
    {
        if (checkInside())
        {
            if (!isTouch)
            {
                isPass = true;
            } else
            {
                isPass = false;
            }
        } else
        {
            isPass=false;
        }
    }

    private void OnMouseDrag()
    {
        currentTime += Time.deltaTime;
        if(currentTime > dragTime)
        {
            isDragging = true;
            moveObject();
        }
    }

    private void OnMouseDown()
    {
        isDragging = false;
    }

    private void OnMouseUp()
    {
        if (!isDragging)
        {
            changePose();
        }
        // Reset
        currentTime = 0;
        isDragging = false;
    }

    // -----------------------------------
    private void changePose()
    {
        currentSpriteIndex = (currentSpriteIndex + 1) % listPoseSprite.Count;
        this.gameObject.GetComponent<SpriteRenderer>().sprite = listPoseSprite[currentSpriteIndex];
        if (polygonCollider2D != null)
        {
            //Destroy(polygonCollider2D);
        }
        //polygonCollider2D = gameObject.AddComponent<PolygonCollider2D>();
    }

    private void moveObject()
    {
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = transform.position.z; 
        if (!isDragging)
        {
            offset = transform.position - mousePosition;
            isDragging = true;
        }
        transform.position = mousePosition + offset;
    }
    //--------------------------------------------------------------
    private bool checkInside()
    {
        Vector2[] points = polygonCollider2D.points;
        foreach (Vector2 point in points)
        {
            Vector2 worldPoint = (Vector2)polygonCollider2D.transform.TransformPoint(point);
            if (!frameCollider.OverlapPoint(worldPoint))
            {
                return false;
            }
            
        }
        return true;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {

        if (collision != null)
        {
            if (collision.collider.GetComponent<Character>() != null)
            {
                Debug.DrawLine(collision.contacts[0].point,gameObject.transform.position);
                isTouch = true;
            }
            else
            {
                isTouch = false;
            }
        }
    }
}
