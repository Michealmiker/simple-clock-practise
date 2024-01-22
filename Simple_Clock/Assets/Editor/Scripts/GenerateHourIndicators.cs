using UnityEditor;
using UnityEngine;

public static class GenerateHourIndicators
{
    private static readonly Vector3 HourIndicatorPosition = new(0, 0.15f, 4);
    private static readonly Vector3 HourIndicatorScale = new(0.3f, 0.1f, 1);
    
    private const int HourCount = 12;
    private const float DegreePerHour = 360f / HourCount;
    private const float RadPerHour = DegreePerHour * Mathf.Deg2Rad;
    
    [MenuItem("GameObject/工具/生成时间刻度", validate = true)]
    public static bool CheckSelectGameObject()
        => Selection.gameObjects.Length == 1
           && string.CompareOrdinal(Selection.gameObjects[0].name, "HourIndicators") == 0;

    [MenuItem("GameObject/工具/生成时间刻度")]
    public static void GenerateHourIndicatorGameObjects()
    {
        var root = Selection.gameObjects[0].transform;
        var transforms = root.GetComponentsInChildren<Transform>();
        var childCount = transforms.Length;
        
        if (childCount > 1)
        {
            for (int i = 0; i < childCount; i++)
            {
                if (string.CompareOrdinal(transforms[i].name, root.name) == 0)
                {
                    continue;
                }
                
                GameObject.DestroyImmediate(transforms[i].gameObject);
            }
        }
        
        for (var i = 0; i < HourCount; i++)
        {
            var go = GameObject.CreatePrimitive(PrimitiveType.Cube);
            var transform = go.transform;
            
            go.name = $"Item_{i}";
            transform.parent = root;
            transform.localPosition = new(
                HourIndicatorPosition.z * Mathf.Sin(RadPerHour * i),
                HourIndicatorPosition.y,
                HourIndicatorPosition.z * Mathf.Cos(RadPerHour * i));
            transform.localRotation = Quaternion.Euler(0, DegreePerHour * i, 0);
            transform.localScale = HourIndicatorScale;
        }
    }
}
