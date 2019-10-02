using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace FactorySpace
{
    public enum Types
    {
        Cube,
        Sphere,
        Cylinder
    }

    public class FactoryPattern : MonoBehaviour
    {
        public List<Spawn> objects = new List<Spawn>();
        SpawnFactory Spawner = new SpawnFactory();
        // Start is called before the first frame update
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.T))
            {
                objects.Add(Spawner.GetSpawn(Types.Cube));

                objects[0].Generate(this.transform.position.x, this.transform.position.y, this.transform.position.z);
            }
        }
    }

    public abstract class Spawn
    {
        public abstract void Generate(float x, float y, float z);
    }

    public class SpawnCube : Spawn
    {
        public override void Generate(float x, float y, float z)
        {
            Debug.Log("Called");
            GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
            cube.transform.position = new Vector3(x, y, z);
        }
    }

    public class SpawnFactory
    {
        public Spawn GetSpawn(Types type)
        {
            switch(type)
            {
                case Types.Cube:
                    return new SpawnCube();
                default:
                    return null;
            }
        }
    }

}