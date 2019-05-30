using UnityEngine;
using System.Collections;

public class InterpolationLibrary : MonoBehaviour {

    /*Our interpolation library
     * This interpolation are not necessary just for a camera but for anything you might want to move around and even more than that
     * You can find a lot of specialized sites online that will return you an equation and you can add them here
     * there are even free assets on the asset store that provide this kind of equations
     * You can use this library between projects so that you don't have to rewrite them everytime
    */
	public static Vector3 AccelDecelInterpolation(Vector3 start, Vector3 end, float t)
    {
        float x = end.x - start.x;
        float y = end.y - start.y;
        float z = end.z - start.z;

        float newT = (Mathf.Cos((t + 1) * Mathf.PI) / 2) + 0.5f;

        x *= newT;
        y *= newT;
        z *= newT;

        Vector3 retVector = new Vector3(start.x + x, start.y + y, start.z + z);

        return retVector;        
    }

    public static Vector3 AccelerationInterpolation(Vector3 start, Vector3 end, float t, float factor)
    {
        float x = end.x - start.x;
        float y = end.y - start.y;
        float z = end.z - start.z;

        float newT = t;

        if (FloatEquals(factor, 1))//because two floats might never be equal we add an aditional check so that they are taken as such if they are close enough
        {
            newT *= newT;
        }
        else
        {
            Mathf.Pow(newT, 2 * factor);
        }

        x *= newT;
        y *= newT;
        z *= newT;

        Vector3 retVector = new Vector3(start.x + x, start.y + y, start.z + z);

        return retVector;  
    }

    private static bool FloatEquals(float f1, float f2)
    {
        return Mathf.Abs(f1 - f2) < 0.001f;
    }
}
