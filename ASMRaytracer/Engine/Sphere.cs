using System.Numerics;
using System;
using System.Drawing;

namespace Renderer {
    class Sphere {
        public Sphere(Vector3 center, float radius, Color colour) {
            this.center = center;
            this.radius = radius;
            this.colour = colour;
        }

        public bool Intersect(Ray inRay,float timeMin, ref float timeMax) {
            
            Vector3 originC = inRay.origin - this.center;
            float a = inRay.direct.LengthSquared();
            float b = Vector3.Dot(inRay.direct, originC);
            float c = (originC).LengthSquared()-(this.radius*this.radius);
            
            float delta = b*b - a*c;

            float root = 0.0f;
            
            if (delta < 0.0) return false;
            else {
                float deltaSqrt = MathF.Sqrt(delta);
                
                root = (-b - deltaSqrt) / a;
                if (root > timeMax || root < timeMin) {
                    root = (-b + deltaSqrt) / a;
                    if (root > timeMax || root < timeMin) {
                        return false;
                    }
                }
            }

            timeMax = root;
            return true;
        }

        Vector3 center;
        public Color colour;
        float radius;
    }
}