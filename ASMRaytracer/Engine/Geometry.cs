using System.Numerics;
using System;
using System.Drawing;

namespace Renderer {
    class Geometry {

        public Geometry() {}

        public Vector3 Add(Vector3 v1, Vector3 v2) {
            return new Vector3( v1.X+v2.X, 
                                v1.Y+v2.Y, 
                                v1.Z+v2.Z);
        }

        public Vector3 Subtract(Vector3 v1, Vector3 v2) {
             return new Vector3( v1.X-v2.X, 
                                 v1.Y-v2.Y, 
                                 v1.Z-v2.Z);
        }

        public float DotProduct(Vector3 v1, Vector3 v2) {
            return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
        }

        public float LengthSquared(Vector3 v) {
            return DotProduct(v,v);
        }

    }
}