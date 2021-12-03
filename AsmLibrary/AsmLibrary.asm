.data
_zero_vector real4 0.0, 0.0, 0.0, 0.0

.code

asmAddTwoDoubles proc
	vaddpd ymm0, ymm0, ymm1
	ret
asmAddTwoDoubles endp

asmAddTwoDoublesTwo proc
	vmulpd ymm0, ymm0, ymm1
	ret
asmAddTwoDoublesTwo endp


asmDotProduct proc
	; YMM0 and YMM1 contain two input Vector4's
	;
	; Summing two Vector4's with double precision, storing results in YMM0.
	vaddps xmm0, xmm0, xmm1
	;
	; Taking two highest floats from YMM0 to lower part of YMM1
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
	ret
asmDotProduct endp

end