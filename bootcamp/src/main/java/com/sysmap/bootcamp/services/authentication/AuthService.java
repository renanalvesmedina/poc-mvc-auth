package com.sysmap.bootcamp.services.authentication;

import com.sysmap.bootcamp.services.authentication.login.LoginRequest;
import com.sysmap.bootcamp.services.authentication.login.LoginResponse;
import com.sysmap.bootcamp.services.user.IUserService;
import org.springframework.stereotype.Service;

@Service
public class AuthService implements IAuthService {
    private IUserService _userService;
    private JwtService _jwtService;

    public AuthService(IUserService userService, JwtService jwtService) {
        _userService = userService;
        _jwtService = jwtService;
    }

    public LoginResponse login(LoginRequest request) {
        var user = _userService.getUserByEmail(request.email);

        if (user == null) {
            return null;
        }

        var loginResponse = new LoginResponse();

        loginResponse.token = _jwtService.generateToken(user.getUsername());

        return loginResponse;
    }
}
