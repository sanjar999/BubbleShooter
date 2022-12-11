using System.Collections.Generic;
using UnityEngine;

public class LaserBeam
{
    Vector3 pos, dir;

    public GameObject laserObj;
    LineRenderer laser;
    List<Vector3> laserIndices = new();

    public LaserBeam(Vector3 pos, Vector3 dir, Material material)
    {
        laser = new();
        laserObj = new();
        laserObj.name = "Laser Beam";
        this.pos = pos;
        this.dir = dir;

        laser = laserObj.AddComponent(typeof(LineRenderer)) as LineRenderer;
        laser.startWidth = 0.1f;
        laser.endWidth = 0.1f;
        laser.material = material;
        laser.startColor = Color.white;
        laser.endColor = Color.white;

        CastRay(pos, dir, laser);
    }

    void CastRay(Vector2 pos, Vector2 dir, LineRenderer line, int maxReflectionCount = 2)
    {
        laserIndices.Add(pos);

        Ray ray = new Ray(pos, dir);
        RaycastHit2D hit;
        if ( Physics2D.Raycast(pos, dir, 30f) &&  maxReflectionCount > 0 )
        {
            hit = Physics2D.Raycast(pos, dir, 30f);
            CheckHit(hit, dir, laser,maxReflectionCount);
        }
        else
        {
            laserIndices.Add(ray.GetPoint(30));
            UpdateLaser();
        }
    }

    void UpdateLaser()
    {
        int count = 0;
        laser.positionCount = laserIndices.Count;

        foreach (var idx in laserIndices)
        {
            laser.SetPosition(count, idx);
            count++;
        }
    }

    void CheckHit(RaycastHit2D hitInfo, Vector2 direction, LineRenderer laser,int maxReflectionCount = 10)
    {
        if (hitInfo.collider.CompareTag("Wall"))
        {
            Vector2 pos = hitInfo.point;
            Vector2 dir = Vector3.Reflect(direction, hitInfo.normal);

            CastRay(pos, dir, laser, maxReflectionCount - 1);
        }
        else
        {
            laserIndices.Add(hitInfo.point);
            UpdateLaser();
        }
    }

}