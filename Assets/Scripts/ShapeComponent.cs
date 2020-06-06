using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class ShapeComponent : MonoBehaviour
{
    /**
     * <summary>
     * Default color
     * </summary>
     */
    protected Color _defaultColor;

    public Color defaultColor
    {
        set
        {
            this._defaultColor = value;
        }

        get
        {
            return this._defaultColor;
        }
    }

    /**
     * <summary>
     * Sprite renderer component
     * </summary>
     */
    protected SpriteRenderer _renderer;

    public SpriteRenderer spriteRenderer
    {
        set
        {
            this._renderer = value;
        }

        get
        {
            return this._renderer;
        }
    }

    // Start is called before the first frame update
    protected virtual void Start()
    {
        this.spriteRenderer = this.GetComponent<SpriteRenderer>();
        this.defaultColor = this.spriteRenderer.color;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        
    }


    /**
     * <summary>
     * On collides with any 2D game object
     * </summary>
     *
     * <returns>
     * void
     * </returns>
     */
    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        ShapeComponent shapeComponent = collision.transform.GetComponent<ShapeComponent>();

        if (shapeComponent == null)
        {
            return;
        }

        // Is colliding with triangle
        if (shapeComponent is TriangleComponent)
        {
            this.spriteRenderer.color = Color.red;
        }

        // Is colliding with circle
        else if (shapeComponent is CircleComponent)
        {
            this.spriteRenderer.color = Color.blue;
        }

        // Is colliding with square
        else if (shapeComponent is SquareComponent)
        {
            this.spriteRenderer.color = Color.green;
        }
    }

    /**
     * <summary>
     * On collision exits with any 2D game object
     * </summary>
     *
     * <returns>
     * void
     * </returns>
     */
    private void OnCollisionExit2D(Collision2D collision)
    {
        this.spriteRenderer.color = this.defaultColor;
    }
}
