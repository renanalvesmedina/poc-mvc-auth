package com.sysmap.parrot.application.authentication;

import com.sysmap.parrot.application.authentication.authenticate.AuthenticateRequest;
import com.sysmap.parrot.application.authentication.authenticate.AuthenticateResponse;
import com.sysmap.parrot.application.user.IUserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.stereotype.Service;

@Service
public class AuthenticationService implements IAuthenticationService {

    @Autowired
    private IUserService _userService;
    @Autowired
    private PasswordEncoder _passwordEncoder;
    @Autowired
    private IJwtService _jwtService;

    public AuthenticateResponse authenticate(AuthenticateRequest request) throws Exception {
        var user = _userService.getUserByEmail(request.email);

        if(user == null) {
            throw new Exception("Usuario não existe!");
        }

        var hash = _passwordEncoder.matches(request.password, user.getPassword());

        if (!hash) {
            throw new Exception("Credenciais inválidas!");
        }

        var token = _jwtService.generateToken(user.getId());

        var response = new AuthenticateResponse();

        response.userId = user.getId();
        response.token = token;

        return response;
    }
}
