using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PlacementMode
{
    Fixed,
    Valid,
    Invalid
}

public class BuildManager : MonoBehaviour
{
    public Color validPlacementColor = Color.green;
    public Color invalidPlacementColor = Color.red;

    public SpriteRenderer[] spriteComponents;
    private Dictionary<SpriteRenderer, Color> initialColors;

    [HideInInspector] public bool hasValidPlacement;
    [HideInInspector] public bool isFixed;

    private int _nObstacles;

    private void Awake()
    {
        hasValidPlacement = true;
        isFixed = true;
        _nObstacles = 0;

        _InitializeColors();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isFixed) return;

        _nObstacles++;
        SetPlacementMode(PlacementMode.Invalid);
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (isFixed) return;

        _nObstacles--;
        if (_nObstacles == 0)
            SetPlacementMode(PlacementMode.Valid);
    }

    public void SetPlacementMode(PlacementMode mode)
    {
        if (mode == PlacementMode.Fixed)
        {
            isFixed = true;
            hasValidPlacement = true;
        }
        else if (mode == PlacementMode.Valid)
        {
            hasValidPlacement = true;
        }
        else
        {
            hasValidPlacement = false;
        }
        SetColor(mode);
    }

    public void SetColor(PlacementMode mode)
    {
        Color colorToApply = Color.white;   //white is the default color.

        if (mode == PlacementMode.Fixed)
        {
            foreach (SpriteRenderer r in spriteComponents)
                r.color = initialColors[r];
        }
        else
        {
            colorToApply = mode == PlacementMode.Valid
                ? validPlacementColor : invalidPlacementColor;

            foreach (SpriteRenderer r in spriteComponents)
            {
                r.color = colorToApply;
            }
        }
    }

    private void _InitializeColors()
    {
        if (initialColors == null)
            initialColors = new Dictionary<SpriteRenderer, Color>();
        if (initialColors.Count > 0)
        {
            initialColors.Clear();
        }

        foreach (SpriteRenderer r in spriteComponents)
        {
            initialColors[r] = r.color;
        }
    }
}