.data
align 16
_arg_one real8 ?
align 16
_arg_two real8 ?
align 16
_arg_three real8 ?
align 16
_arg_four real4 ?

align 16
_adelta real4 ?
_bdelta real4 ?
_cdelta real4 ?
align 16
_input_one real8 ?
align 16
_input_two real8 ?

.code

asmSphereIntersect PROC
	; Sphere intersection function returning boolean value after determining if collision happens.
	;---------------------------
	; Inputs:
	;	- XMM0: Ray origin (OriginC)
	;	- XMM1: Ray direction
	;	- XMM2: Sphere center
	;	- XMM3: Sphere radius
	;	- On stack: Time max
	;
	; Returns:
	;	Value on XMM0
	;	- Time of intersection found if > 0 
	;	- Time = -1 if intersection is not possible
	;
	;---------------------------- 
	;
	; Vector3 originC = inRay.origin - this.center: Result in XMM0 (inRay.origin can be overwritten)
	vsubps 	xmm0, xmm0, xmm2
	;
	; Save arguments in memory
	movupd 	[_arg_one], xmm0
	movupd 	[_arg_two],	xmm1
	movupd 	[_arg_three], xmm2
	movss 	[_arg_four], xmm3
	;
	; float a = inRay.direct.LengthSquared()
	movupd 	[_input_one], xmm1
	movupd 	[_input_two], xmm1
	call 	dotProduct
	movss 	[_adelta], xmm0
	;
	; float b = Vector3.Dot(inRay.direct, originC)
	; mov r8, offset _arg_one
	; push r8
	movupd 	xmm0, qword ptr [_arg_one]
	movupd 	xmm1, qword ptr [_arg_two]
	movupd 	[_input_one], xmm0
	movupd 	[_input_two], xmm1
	call 	dotProduct
	movss 	[_bdelta], xmm0
	;
	; float c = originC.LengthSquared() - (radius*radius)
	movupd 	xmm0, qword ptr [_arg_one]
	movupd 	[_input_one], xmm0
	movupd 	[_input_two], xmm0
	call 	dotProduct
	movss 	xmm1, dword ptr [_arg_four]
	mulps 	xmm1, xmm1
	vsubps 	xmm0, xmm0, xmm1
	movss 	[_cdelta], xmm0
	; 
	; float delta= reduced_b*reduced_b - a*c 
	; YES ITS WITHOUT 4 DONT CORRECT PLS NO I HAVENT GOT WRONG RESULTS FOR 6 HOURS BECAUSE I'VE HAD 4*a*c THERE
	movss 	xmm0, dword ptr [_bdelta]
	mulps 	xmm0, xmm0
	movss 	xmm1, dword ptr [_adelta]
	movss 	xmm2, dword ptr [_cdelta]
	mulps 	xmm1, xmm2
	vsubps 	xmm0, xmm0, xmm1
	;
	; ...
	; TODO
	; ...
	;
	ret
asmSphereIntersect ENDP

dotProduct PROC
	; Dot product procedure
	;---------------------------
	; Inputs:
	;	- _input_one: First vector
	;	- _input_two: Second vector
	;
	; Returns:
	;	Value on XMM0
	;	- Scalar value of dot product for two input vector
	;---------------------------- 
	;
	movupd 	xmm0, qword ptr [_input_one]
	movupd 	xmm1, qword ptr [_input_two]
	;
	; XMM0 and XMM1 contain two input Vector4's
	;
	; Multiplying two Vector4's with single precision, storing results in XMM0.
	vmulps 	xmm0, xmm0, xmm1
	;
	; Taking two highest packed floats from XMM0 to lower part of XMM1
	movhlps	xmm1, xmm0
	;
	; Adding two highest and two lowest single precision, [XYZW] -> X+Z, Y+W = X+Z (vaddps) Y+W
 	vaddps 	xmm0, xmm0, xmm1
	;
	; Move highest single precision float (X+Z) to bottom of XMM1 for shuffling
	movaps 	xmm1, xmm0
	;
	; Move selected two floats to the lowest position [X+Z, Y+W] -> [X+Z, Y+W], [X+Z]
	shufps 	xmm1, xmm1, 1010101b
	;
	; Add two lowest single precision floats for final result in XMM0, [Y+W]+[X+Z]
	addps 	xmm0, xmm1
	;
	; Return to caller
	ret
dotProduct ENDP

end