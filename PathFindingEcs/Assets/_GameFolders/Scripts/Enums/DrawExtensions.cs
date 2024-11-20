using Unity.Mathematics;
using UnityEngine;

namespace PathFindingEcs.Enums
{
    public static class DrawExtensions
    {
        /// <summary> Function to draw a square </summary>
        public static void DrawSquare(Vector3 center, float edgeLength, Color color)
        {
            DrawSquare(center, edgeLength, color, 0f);
        }

        /// <summary> Function to draw a square </summary>
        public static void DrawSquare(Vector3 center, float edgeLength, Color color, float duration)
        {
            // Calculate the corner points of the square
            Vector3 bottomLeft = center + new Vector3(-edgeLength / 2, 0, -edgeLength / 2);
            Vector3 topLeft = center + new Vector3(-edgeLength / 2, 0, edgeLength / 2);
            Vector3 topRight = center + new Vector3(edgeLength / 2, 0, edgeLength / 2);
            Vector3 bottomRight = center + new Vector3(edgeLength / 2, 0, -edgeLength / 2);

            // Draw the square
            Debug.DrawLine(bottomLeft, topLeft, color, duration);
            Debug.DrawLine(topLeft, topRight, color, duration);
            Debug.DrawLine(topRight, bottomRight, color, duration);
            Debug.DrawLine(bottomRight, bottomLeft, color, duration);
        }

        // Function to draw a cube
        public static void DrawCube(Vector3 center, float edgeLength, Color color)
        {
            DrawCube(center, edgeLength, color, 0f);
        }

        // Function to draw a cube
        public static void DrawCube(Vector3 center, float edgeLength, Color color, float duration)
        {
            // Calculate the corner points of the cube
            Vector3 frontBottomLeft = center + new Vector3(-edgeLength / 2, -edgeLength / 2, -edgeLength / 2);
            Vector3 frontTopLeft = center + new Vector3(-edgeLength / 2, edgeLength / 2, -edgeLength / 2);
            Vector3 frontTopRight = center + new Vector3(edgeLength / 2, edgeLength / 2, -edgeLength / 2);
            Vector3 frontBottomRight = center + new Vector3(edgeLength / 2, -edgeLength / 2, -edgeLength / 2);

            Vector3 backBottomLeft = center + new Vector3(-edgeLength / 2, -edgeLength / 2, edgeLength / 2);
            Vector3 backTopLeft = center + new Vector3(-edgeLength / 2, edgeLength / 2, edgeLength / 2);
            Vector3 backTopRight = center + new Vector3(edgeLength / 2, edgeLength / 2, edgeLength / 2);
            Vector3 backBottomRight = center + new Vector3(edgeLength / 2, -edgeLength / 2, edgeLength / 2);

            // Draw the cube
            // Front face
            Debug.DrawLine(frontBottomLeft, frontTopLeft, color, duration);
            Debug.DrawLine(frontTopLeft, frontTopRight, color, duration);
            Debug.DrawLine(frontTopRight, frontBottomRight, color, duration);
            Debug.DrawLine(frontBottomRight, frontBottomLeft, color, duration);
            // Back face
            Debug.DrawLine(backBottomLeft, backTopLeft, color, duration);
            Debug.DrawLine(backTopLeft, backTopRight, color, duration);
            Debug.DrawLine(backTopRight, backBottomRight, color, duration);
            Debug.DrawLine(backBottomRight, backBottomLeft, color, duration);
            // Edges between other faces
            Debug.DrawLine(frontBottomLeft, backBottomLeft, color, duration);
            Debug.DrawLine(frontTopLeft, backTopLeft, color, duration);
            Debug.DrawLine(frontTopRight, backTopRight, color, duration);
            Debug.DrawLine(frontBottomRight, backBottomRight, color, duration);
        }

        // Function to draw a circle
        public static void DrawCircleMethod(float3 center, int segments, float radius, Color color, float duration)
        {
            CircleMethod(center, segments, radius, color, duration);

            CircleMethod(center, 8, 0.5f, color, duration);
            CircleMethod(center, 8, 0.4f, color, duration);
            CircleMethod(center, 8, 0.3f, color, duration);
            CircleMethod(center, 8, 0.2f, color, duration);
            CircleMethod(center, 8, 0.1f, color, duration);
        }

        public static void CircleMethod(float3 center, int segments, float radius, Color color, float duration)
        {
            float x;
            float z;
            float angle = 0f;
            float angleIncrement = 360f / segments;

            Vector3 startPoint = Vector3.zero;
            Vector3 prevPoint = Vector3.zero;

            for (int i = 0; i <= segments; i++)
            {
                x = center.x + Mathf.Sin(Mathf.Deg2Rad * angle) * radius;
                z = center.z + Mathf.Cos(Mathf.Deg2Rad * angle) * radius;

                Vector3 endPoint = new Vector3(x, center.y, z);

                if (i > 0)
                {
                    Debug.DrawLine(prevPoint, endPoint, color, duration);
                }
                else
                {
                    startPoint = endPoint;
                }

                prevPoint = endPoint;
                angle += angleIncrement;
            }

            // Draw the final segment to close the circle
            Debug.DrawLine(prevPoint, startPoint, color, duration);
        }
    }
}