.data
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
	vmulpd ymm0, ymm0, ymm1
	ret
asmDotProduct endp

end