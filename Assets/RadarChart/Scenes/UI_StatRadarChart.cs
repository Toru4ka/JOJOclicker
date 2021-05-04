using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UI_StatRadarChart : MonoBehaviour
{
    [SerializeField] private Material radarMaterial;
    [SerializeField] private Texture2D radarTexture2D;
    private Stats stats;
    private CanvasRenderer radarMeshCanvasRenderer;

    private void Awake()
    {
        radarMeshCanvasRenderer = transform.Find("radarMesh").GetComponent<CanvasRenderer>();
    }

    public void SetStats(Stats stats)
    {
        this.stats = stats;
        UpdateStatsVisual();
    }

    private void UpdateStatsVisual()
    {
        Mesh mesh = new Mesh();
        Vector3[] vertices = new Vector3[7];
        Vector2[] uv = new Vector2[7];
        int[] triangles = new int[3 * 7];

        float angleIncroment = -60f;
        float radarChartSize = 272f;
        Vector3 DestructivePowerVertex = Quaternion.Euler(0,0, angleIncroment * 0) * Vector3.up * radarChartSize * stats.GetStatAmountNormalized(Stats.Type.DestructivePower);
        int DestructivePowerVertexIndex = 1;
        Vector3 SpeedVertex = Quaternion.Euler(0,0, angleIncroment * 1) * Vector3.up * radarChartSize * stats.GetStatAmountNormalized(Stats.Type.Speed);
        int SpeedVertexIndex = 2;
        Vector3 RangeVertex = Quaternion.Euler(0,0, angleIncroment * 2) * Vector3.up * radarChartSize * stats.GetStatAmountNormalized(Stats.Type.Range);
        int RangeVertexIndex = 3;
        Vector3 PerseveranceVertex = Quaternion.Euler(0,0, angleIncroment * 3) * Vector3.up * radarChartSize * stats.GetStatAmountNormalized(Stats.Type.Perseverance);
        int PerseveranceVertexIndex = 4;
        Vector3 PrecisionVertex = Quaternion.Euler(0,0, angleIncroment * 4) * Vector3.up * radarChartSize * stats.GetStatAmountNormalized(Stats.Type.Precision);
        int PrecisionVertexIndex = 5;
        Vector3 DevelopmentPotentialVertex = Quaternion.Euler(0,0, angleIncroment * 5) * Vector3.up * radarChartSize * stats.GetStatAmountNormalized(Stats.Type.DevelopmentPotential);
        int DevelopmentPotentialVertexIndex = 6;
        
        
        vertices[0] = Vector3.zero;
        vertices[DestructivePowerVertexIndex] = DestructivePowerVertex;
        vertices[SpeedVertexIndex] = SpeedVertex;
        vertices[RangeVertexIndex] = RangeVertex;
        vertices[PerseveranceVertexIndex] = PerseveranceVertex;
        vertices[PrecisionVertexIndex] = PrecisionVertex;
        vertices[DevelopmentPotentialVertexIndex] = DevelopmentPotentialVertex;
        
        uv[0] = Vector2.zero;
        uv[DestructivePowerVertexIndex] = Vector2.one;
        uv[SpeedVertexIndex] = Vector2.one;
        uv[RangeVertexIndex] = Vector2.one;
        uv[PerseveranceVertexIndex] = Vector2.one;
        uv[PrecisionVertexIndex] = Vector2.one;       
        uv[DevelopmentPotentialVertexIndex] = Vector2.one;

        triangles[0] = 0;
        triangles[1] = DestructivePowerVertexIndex;
        triangles[2] = SpeedVertexIndex;
        
        triangles[3] = 0;
        triangles[4] = SpeedVertexIndex;
        triangles[5] = RangeVertexIndex;
        
        triangles[6] = 0;
        triangles[7] = RangeVertexIndex;
        triangles[8] = PerseveranceVertexIndex;
        
        triangles[9] = 0;
        triangles[10] = PerseveranceVertexIndex;
        triangles[11] = PrecisionVertexIndex;
        
        triangles[12] = 0;
        triangles[13] = PrecisionVertexIndex;
        triangles[14] = DevelopmentPotentialVertexIndex;
        
        triangles[15] = 0;
        triangles[16] = DevelopmentPotentialVertexIndex;
        triangles[17] = DestructivePowerVertexIndex;

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
        
        radarMeshCanvasRenderer.SetMesh(mesh);
        radarMeshCanvasRenderer.SetMaterial(radarMaterial, radarTexture2D);
        
    }
}
