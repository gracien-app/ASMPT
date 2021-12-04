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
	;	- Time value of intersection found if > 0 
	;	- Value of -1 if intersection is not possible
	;
	;---------------------------- 
	;
	; Vector3 originC = inRay.origin - this.center: Result in XMM0 (inRay.origin can be overwritten)
	vsubps xmm0, xmm0, xmm2
	;
	; Save constant arguments in variables
	movupd [_arg_one], xmm0
	movupd [_arg_two], xmm1
	movupd [_arg_three], xmm2
	movss [_arg_four], xmm3
	;
	; Save save corrected origin-center vector as first argument (inRay.origin no longer needed)
	movupd [_arg_one], xmm0
	;
	; float a = inRay.direct.LengthSquared()
	movupd [_input_one], xmm1
	movupd [_input_two], xmm1
	call dotProduct
	movss [_adelta], xmm0
	;
	; float b = Vector3.Dot(inRay.direct, originC): Result in XMM4
	; mov r8, offset _arg_one
	; push r8
	movupd xmm0, qword ptr [_arg_one]
	movupd xmm1, qword ptr [_arg_two]
	movupd [_input_one], xmm0
	movupd [_input_two], xmm1
	call dotProduct
	movss [_bdelta], xmm0
	;
	; float c = originC.LengthSquared() - (radius*radius)
	movupd xmm0, qword ptr [_arg_one]
	movupd [_input_one], xmm0
	movupd [_input_two], xmm0
	call dotProduct
	movss xmm1, dword ptr [_arg_four]
	mulps xmm1, xmm1
	vsubps xmm0, xmm0, xmm1
	movss [_cdelta], xmm0
	; TODO
	; 
	; float delta= b*b-a*c 
	; YES ITS WITHOUT 4 DONT CORRECT PLS NO I HAVENT GOT WRONG RESULTS FOR 6 HOURS BECAUSE I'VE HAD 4*a*c THERE
	movss xmm0, dword ptr [_bdelta]
	mulps xmm0, xmm0
	movss xmm1, dword ptr [_adelta]
	movss xmm2, dword ptr [_cdelta]
	mulps xmm1, xmm2
	vsubps xmm0, xmm0, xmm1
	;
	; ...
	; TODO
	; ...
	;
	ret
asmSphereIntersect ENDP

dotProduct PROC
	
	movupd xmm0, qword ptr [_input_one]
	movupd xmm1, qword ptr [_input_two]
	;
	; XMM4 and XMM5 contain two input Vector4's
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
	; Return to caller
	ret
dotProduct ENDP

end