package com.sysmap.parrot.application.authentication;

import com.sysmap.parrot.application.authentication.authenticate.AuthenticateRequest;
import com.sysmap.parrot.application.authentication.authenticate.AuthenticateResponse;

public interface IAuthenticationService {
    AuthenticateResponse authenticate(AuthenticateRequest request) throws Exception;
}
