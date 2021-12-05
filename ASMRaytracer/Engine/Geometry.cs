using System.Numerics;
using System;
using System.Drawing;

namespace Renderer {
    class Geometry {

        public Geometry() {}

        public Vector4 Add(Vector4 v1, Vector4 v2) {
            return new Vector4( v1.X+v2.X, 
                                v1.Y+v2.Y, 
                                v1.Z+v2.Z,
                                0.0f);
        }

        public Vector4 Subtract(Vector4 v1, Vector4 v2) {
             return new Vector4( v1.X-v2.X, 
                                 v1.Y-v2.Y, 
                                 v1.Z-v2.Z,
                                 0.0f);
        }

        public float DotProduct(Vector4 v1, Vector4 v2) {
            return v1.X * v2.X + v1.Y * v2.Y + v1.Z * v2.Z;
        }

        public float LengthSquared(Vector4 v) {
            return DotProduct(v,v);
        }

    }
}