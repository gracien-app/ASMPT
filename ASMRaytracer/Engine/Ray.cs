using System.Numerics;

namespace Renderer {

    public class Ray {
        public Ray() {
            origin = direct = new Vector3(0.0f);
        }

        public Ray(Vector3 startPos, Vector3 dirPos) {
            origin = startPos;
            direct = dirPos;
        }

        public Vector3 at(float time) {
            return origin + (direct * time);
        }

        public Vector3 origin {get; set;}
        public Vector3 direct {get; set;}
    }
}