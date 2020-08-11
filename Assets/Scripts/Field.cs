using UnityEngine;

public class Field : MonoBehaviour
{

    public Color hoverColor;
    public Vector3 turretOffsetPosition;

    private GameObject turret;

    private Renderer newRenderer;
    private Color startColor;

    void Start()
    {
        newRenderer = GetComponent<Renderer>();
        startColor = newRenderer.material.color;
    }
    void OnMouseEnter ()
    {
        newRenderer.material.color = hoverColor;
    }
    void OnMouseExit ()
    {
        newRenderer.material.color = startColor;
    }
    void OnMouseDown ()
    {

        if (turret != null)
        {
            Debug.Log("Can't build there!");
            return;
        }
        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret = (GameObject)Instantiate(turretToBuild, transform.position + turretOffsetPosition, transform.rotation);
    }
}
