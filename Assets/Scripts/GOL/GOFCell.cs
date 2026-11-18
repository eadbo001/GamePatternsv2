using UnityEngine;

[RequireComponent (typeof(MeshRenderer))]
public class GOFCell : MonoBehaviour
{
    public Color AliveColor = Color.greenYellow;
    public Color DeadColor = Color.black;

    private MeshRenderer m_Renderer;

    public void SetAlive()
    {
        m_Renderer.material.color = AliveColor;
    }

    public void SetDead()
    {
         m_Renderer.material.color = DeadColor;
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        m_Renderer = GetComponent<MeshRenderer>();
    }

    // Update is called once per frame
    void Start()
    {
        //SetDead();
    }
}
