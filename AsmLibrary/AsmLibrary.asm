.data
_zero_vector real4 0.0, 0.0, 0.0, 0.0

.code

dotProduct PROC
	; Save return pointer on the stack
	push rbp
	mov rbp, rsp
	; XMM0 and XMM1 contain two input Vector4's
	;
	; Multiplying two Vector4's with single precision, storing results in XMM0.
	vmulps xmm0, xmm0, xmm1
	;
	; Taking two highest packed floats from XMM0 to lower part of XMM1
	movhlps xmm1, xmm0
	;
	; Adding two highest and two lowest floats, [XYZW] -> X+Z, Y+W
	vaddps xmm0, xmm0, xmm1
	;
	; Move highest to bottom
	movaps xmm1, xmm0
	;
	; Shuffle to get to the lowest position [X+Z, Y+W] -> [X+Z, Y+w], [X+Z]
	shufps xmm1, xmm1, 85
	;
	; Add lowest [Y+W]+[X+Z]
	addps xmm0, xmm1
	;
	; Pop the return address off the stack
	pop rbp
	;
	; Return to caller
	ret
dotProduct ENDP

asmSphereIntersect PROC
	; Sphere intersection function returning boolean value after determining if collision happens.
	;---------------------------
	; Inputs:
	;	- XMM0: Ray origin
	;	- XMM1: Ray direction
	;	- XMM2: Sphere origin
	;	- XMM3: Time max
	;	- On stack: Sphere radius
	;
	; Returns:
	;	Value on XMM0
	;	- Time value of intersection found if > 0 
	;	- Value of -1 if intersection is not possible
	;
	;---------------------------- 

	; Vector3 originC = inRay.origin - this.center: Result in XMM0 (inRay.origin can be overwritten)
	vsubps xmm0, xmm0, xmm2
	;
	; float a = inRay.direct.LengthSquared()
	; TODO
	;
	; float b = Vector3.Dot(inRay.direct, originC)
	call dotProduct
	;
	; float c = originC.LengthSquared() - (radius*radius)
	; TODO
	; 
	; float delta= b*b-4*a*c
	; TODO
	;
	; if(delta < 0.0) return false (-1)
	; TODO
	;
	; else ...


asmSphereIntersect ENDP




end