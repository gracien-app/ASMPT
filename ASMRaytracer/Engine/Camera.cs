using System.Numerics;

namespace Renderer {

    class Camera
    {
        public Camera(int W, int H) {
            position = new Vector4(0.0f);

            float projectionHeight = 2.0f; // Our imaginary coord. system is 2 units in height (-1.0 ; 1.0)
            float aspectRatio = W / H; // Checking how width is defined in terms of height
            float projectionWidth = projectionHeight * aspectRatio; // Width is scaled to match projection aspect ratio

            float focalLength = 1.0f; // Imaginary "lens" focal length, hardcoded to 1.0 for natural perspective.

            xDir = new Vector4( projectionWidth, 0.0f, 0.0f, 0.0f );
            yDir = new Vector4( 0.0f, projectionHeight, 0.0f, 0.0f );
            zDir = new Vector4( 0.0f, 0.0f, focalLength, 0.0f );

            renderStartPos = position - zDir + (yDir*0.5f) - (xDir*0.5f);

        } 

        public Ray makeRay(float xOffset, float yOffset) {
            var offsetDir = renderStartPos + (xDir * xOffset) - (yDir * yOffset);
            return new Ray(position, offsetDir - position);
        }

        private Vector4 position;
        private Vector4 renderStartPos;

        private Vector4 xDir;
        private Vector4 yDir;
        private Vector4 zDir;
    }
}