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
align 16
_bdelta real4 ?
align 16
_cdelta real4 ?
align 16
_input_one real8 ?
align 16
_input_two real8 ?

align 16
_time_min real4 0.001
align 16
_time_max real4 ?
align 16
_minus_one real4 -1.0

.code

asmSphereIntersect PROC
	; Sphere intersection function returning value which indicates when (if) collision happens.
	;---------------------------
	; Inputs:
	;	- XMM0: Ray origin (OriginC)
	;	- XMM1: Ray direction
	;	- XMM2: Sphere center
	;	- XMM3: Sphere radius
	;	- XMM4: Time max
	;
	; Returns:
	;	Value on XMM0
	;	: time of intersection if > 0 
	;	: -1 if intersection is not possible
	;
	;---------------------------- 
	;
	; Vector3 originC = inRay.origin - this.center: Result in XMM0 (inRay.origin can be overwritten)
	vsubps 	xmm0, xmm0, xmm2
	;
	; Save arguments in memory
	movapd 	[_arg_one], xmm0
	movapd 	[_arg_two],	xmm1
	movapd 	[_arg_three], xmm2
	movss 	[_arg_four], xmm3
	movss	[_time_max], xmm4
	;
	; float a = inRay.direct.LengthSquared()
	movapd 	[_input_one], xmm1
	movapd 	[_input_two], xmm1
	call 	dotProduct
	movss 	[_adelta], xmm0
	;
	; float b = Vector3.Dot(inRay.direct, originC)
	; mov r8, offset _arg_one
	; push r8
	movapd 	xmm0, qword ptr [_arg_one]
	movapd 	xmm1, qword ptr [_arg_two]
	movapd 	[_input_one], xmm0
	movapd 	[_input_two], xmm1
	call 	dotProduct
	movss 	[_bdelta], xmm0
	;
	; float c = originC.LengthSquared() - (radius*radius)
	movapd 	xmm0, qword ptr [_arg_one]
	movapd 	[_input_one], xmm0
	movapd 	[_input_two], xmm0
	call 	dotProduct
	movss 	xmm1, dword ptr [_arg_four]
	mulps 	xmm1, xmm1
	vsubps 	xmm0, xmm0, xmm1
	movss 	[_cdelta], xmm0
	; 
	; float delta= reduced_b*reduced_b - a*c 
	;
	movss 	xmm0, dword ptr [_bdelta]
	mulps 	xmm0, xmm0
	movss 	xmm1, dword ptr [_adelta]
	movss 	xmm2, dword ptr [_cdelta]
	mulps 	xmm1, xmm2
	vsubps 	xmm0, xmm0, xmm1
	;
	;if (delta < 0.0) return false;
    ;        else
    ;        {
    ;            float deltaSqrt = MathF.Sqrt(delta);
	;
    ;            root = (-b - deltaSqrt) / a;
    ;            if (root > timeMax || root < timeMin)
    ;            {
    ;                root = (-b + deltaSqrt) / a;
    ;                if (root > timeMax || root < timeMin)
    ;                {
    ;                    return false;
    ;                }
    ;            }
    ;        }
	;
	;	storage = what it was -> what it becomes
	;	xmm0 = delta -> deltaSqrt
	;	xmm1 -> root
	;	xmm6, xmm7 = utility registers
	;	[_adelta] = a
	;	[_bdelta] = b -> -b
	;	[_cdelta] = c -> utility memory
	;	[_time_max] = TimeMax
	;	[_time_min] = TimeMin
	;	[_minus_one] = you guessed it, -1

	;---Debug code in .data: setup _time_max and _time_min ---

	;-------Check if delta < 0-------
	  ;Get a copy of delta for comparison, prepare xmm6 with zero
	movss	xmm7, xmm0
	xorps	xmm6, xmm6
	  ;If xmm7 is less than xmm6 (0) then there will be ones in xmm7 (highest dword filled with 1s)
	cmpltps	xmm7, xmm6
	  ;Move to memory the result of comparison (all 0s or all 1s), _cdelta overwritten
	movss	[_cdelta], xmm7
	  ;Prepare for test of contents
	mov		eax, [_cdelta]
	  ;Test contents (if all 0s, jump will happen, else not)
	test	eax, eax
	JZ		LARGER

	  ;Return -1
	movss	xmm0, dword ptr [_minus_one]
	ret

	;-------Calculate first root-------
	LARGER:
	  ;Negate _bdelta
	movss	xmm7, dword ptr [_bdelta]
	subss	xmm6, xmm7
	movss	dword ptr [_bdelta], xmm6 

	  ;Sqare root of delta
	sqrtss	xmm0, xmm0

	  ; xmm6 = -b - deltaSqrt (b still in xmm6)
	subss	xmm6, xmm0
	  ; xmm6 /= a
	divss	xmm6, dword ptr [_adelta]
	movss	xmm1, xmm6

	;-------Check if root > timeMax || root < timeMin-------
	  ;Root is still in xmm6
	  ;Prepare xmm7 with timeMax
	movss	xmm7, dword ptr [_time_max]
	  ;If xmm7 < xmm6 (root) then there will be ones in xmm7 (highest dword filled with 1s)
	cmpltss xmm7, xmm6
	  ;Move to memory the result of comparison (all 0s or all 1s), _cdelta overwritten
	movss	[_cdelta], xmm7
	  ;Store in eax
	mov		eax, [_cdelta]

	  ;Prepare xmm7 with root and xmm6 with _time_min
	movss	xmm7, xmm1
	movss	xmm6, dword ptr [_time_min]
	  ;If xmm7 < xmm6 (_time_min) then there will be ones in xmm7 (highest dword filled with 1s)
	cmpltss xmm7, xmm6
	  ;Move to memory the result of comparison (all 0s or all 1s), _cdelta overwritten
	movss	[_cdelta], xmm7
	  ;OR with eax
	or		eax, [_cdelta]
	  ;Test contents (if all 0s, jump will happen, else not)
	test	eax, eax
	JZ RootFound

	;-------Calculate other root-------
	  ;If didn't jump, look for other root
	movss	xmm6, dword ptr [_bdelta]
	  ; xmm6 = -b + deltaSqrt
	addss	xmm6, xmm0
	  ; xmm6 /= a
	divss	xmm6, dword ptr [_adelta]
	movss	xmm1, xmm6

	;-------Check if root > timeMax || root < timeMin-------
	  ;Root is still in xmm6
	  ;Prepare xmm7 with timeMax
	movss	xmm7, dword ptr [_time_max]
	  ;If xmm7 < xmm6 (root) then there will be ones in xmm7 (highest dword filled with 1s)
	cmpltps xmm7, xmm6
	  ;Move to memory the result of comparison (all 0s or all 1s), _cdelta overwritten
	movss	[_cdelta], xmm7
	  ;Store in eax
	mov		eax, [_cdelta]

	  ;Prepare xmm7 with root and xmm6 with _time_min
	movss	xmm7, xmm1
	movss	xmm6, dword ptr [_time_min]
	  ;If xmm7 < xmm6 (_time_min) then there will be ones in xmm7 (highest dword filled with 1s)
	cmpltps xmm7, xmm6
	  ;Move to memory the result of comparison (all 0s or all 1s), _cdelta overwritten
	movss	[_cdelta], xmm7
	  ;OR with eax
	or		eax, [_cdelta]
	  ;Test contents (if all 0s, jump will happen, else not)
	test	eax, eax
	JZ RootFound

	  ;No roots found
	  ;return -1
	movss	xmm0, dword ptr [_minus_one]
	ret

	RootFound:
	  ;Return root
	  ;Root will always be at xmm1, so move that to xmm0
	movss	xmm0, xmm1;
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
	movapd 	xmm0, qword ptr [_input_one]
	movapd 	xmm1, qword ptr [_input_two]
	;
	; XMM0 and XMM1 contain two input vectors
	;
	; Multiplying two vectors with single precision values, storing results in XMM0.
	vmulps 	xmm0, xmm0, xmm1
	;
	; Taking two highest packed floats from XMM0 to lower part of XMM1
	movhlps	xmm1, xmm0
	;
	; Adding two highest and two lowest single precision [XYZW] + [**XY] -> X+Z, Y+W.
 	vaddps 	xmm0, xmm0, xmm1
	;
	; Move single precision float (X+Z) to XMM1 for shuffling
	movaps 	xmm1, xmm0
	;
	; Move selected two floats to the lowest position [X+Z, Y+W] -> [X+Z, Y+W], [X+Z]
	shufps 	xmm1, xmm1, 01010101b
	;
	; Add two lowest single precision floats for final result in lowest dword XMM0, [Y+W]+[X+Z]
	addps 	xmm0, xmm1
	;
	; Return to caller.
	ret
dotProduct ENDP

end