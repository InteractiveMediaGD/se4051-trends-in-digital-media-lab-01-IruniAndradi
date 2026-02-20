using UnityEngine;

public class C_Interaction : MonoBehaviour
{
    
    private Renderer objectRenderer;
    private Color originalColor;

    public Color gazeColor = Color.yellow;
    public float dwellTime = 2f;

    private float timer;

    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        originalColor = objectRenderer.material.color;
    }

    void Update()
    {
        Ray ray = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit) && hit.transform == transform)
        {
            objectRenderer.material.color = gazeColor;
            timer += Time.deltaTime;

            if (timer >= dwellTime)
           {
              
               
               timer = 0;
           }

        }
        else
        {
            objectRenderer.material.color = originalColor;
            timer = 0;
        }
    }
}