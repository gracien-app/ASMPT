using System.Numerics;
using System;
using System.Drawing;

namespace Renderer {
    class Sphere: Geometry {

        public Sphere() {
            this.center = new Vector4(0.0f);
            this.radius = 0.0f;
            this.colour = new Vector3(0.0f);
        }

        public Sphere(Vector4 center, float radius, Vector3 colour) {
            this.center = center;
            this.radius = radius;
            this.colour = colour;
        }

        public bool IntersectNative(Ray inRay,float timeMin, ref float timeMax) {
            
            Vector4 originC = inRay.origin - this.center;
            float a = inRay.direct.LengthSquared();
            float b = 2.0f*Vector4.Dot(inRay.direct, originC);
            float c = (originC).LengthSquared()-(this.radius*this.radius);
            
            float delta = b*b - 4*a*c;

            float root = 0.0f;
            
            if (delta < 0.0) return false;
            else {
                float deltaSqrt = MathF.Sqrt(delta);
                
                root = (-b - deltaSqrt) / (2.0f*a);
                if (root > timeMax || root < timeMin) {
                    root = (-b + deltaSqrt) / (2.0f*a);
                    if (root > timeMax || root < timeMin) {
                        return false;
                    }
                }
            }

            timeMax = root;
            return true;
        }

        public bool IntersectNoAcceleration(Ray inRay,float timeMin, ref float timeMax) {
            
            var originC = Subtract(inRay.origin, this.center);
            float a = LengthSquared(inRay.direct);
            float b = 2.0f*DotProduct(inRay.direct, originC);
            float c = LengthSquared(originC) - (this.radius * this.radius);
            
            float delta = b*b - 4*a*c;

            float root = 0.0f;
            
            if (delta < 0.0) return false;
            else {
                float deltaSqrt = MathF.Sqrt(delta);
                
                root = (-b - deltaSqrt) / (2.0f*a);
                if (root > timeMax || root < timeMin) {
                    root = (-b + deltaSqrt) / (2.0f*a);
                    if (root > timeMax || root < timeMin) {
                        return false;
                    }
                }
            }

            timeMax = root;
            return true;
        }

        public Vector4 center;
        public Vector3 colour;
        public float radius;
    }
    
}