package com.sysmap.bootcamp.services.authentication;

import com.sysmap.bootcamp.services.authentication.login.LoginRequest;
import com.sysmap.bootcamp.services.authentication.login.LoginResponse;

public interface IAuthService {
    LoginResponse login(LoginRequest request);
}
