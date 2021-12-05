using System.Numerics;

namespace Renderer {

    public class Ray {
        public Ray() {
            origin = direct = new Vector4(0.0f);
        }

        public Ray(Vector4 startPos, Vector4 dirPos) {
            origin = startPos;
            direct = dirPos;
        }

        public Vector4 at(float time) {
            return origin + (direct * time);
        }

        public Vector4 origin {get; set;}
        public Vector4 direct {get; set;}
    }
}