using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeshController : MonoBehaviour
{
    public Vector3[] m_vertexs;
    public int[] m_triangles;
    public Color m_color;
    public Texture m_texture;
    public Vector2[] m_uvs;

    [HideInInspector]
    public MeshFilter m_meshFilter;
    [HideInInspector]
    public MeshRenderer m_meshRenderer;
    [HideInInspector]
    public GameObject m_objMesh;

    void Awake()
    {
        m_objMesh = new GameObject("ObjMesh");
        m_meshFilter =  m_objMesh.AddComponent<MeshFilter>();
        m_meshRenderer = m_objMesh.AddComponent<MeshRenderer>();
        
        m_vertexs = new Vector3[]{
            new Vector3(-1,-1,0),
            new Vector3(-1,1,0),
            new Vector3(1,1,0),
            new Vector3(1,-1,0)
        };
        m_triangles = new int[]{
            0,1,2,2,0,3
        };
        m_uvs = new Vector2[]
        {
            new Vector2(0,0),
            new Vector2(0,1),
            new Vector2(1,1),
            new Vector2(1,0)
        };
    }

    void Start()
    {
        m_meshFilter.mesh = CreateMesh("objMesh_mesh",m_vertexs,m_triangles,m_uvs);
        m_meshRenderer.material = CreateMaterial("Standard",m_color,m_texture);
    }

    Mesh CreateMesh(string meshName,Vector3[] vertexs,int[] triangles,Vector2[] uvs)
    {
        Mesh mesh = new Mesh();
        mesh.name = meshName;
        mesh.vertices = vertexs;
        mesh.triangles = triangles;
        mesh.uv = uvs;
        return mesh;
    }

    Material CreateMaterial(string shaderName,Color color,Texture texture)
    {
        Material material = new Material(Shader.Find("Standard"));
        material.color = color;
        material.mainTexture = texture;
        return material;
    }
}
