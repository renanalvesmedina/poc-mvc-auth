package com.sysmap.bootcamp.controllers;

import com.sysmap.bootcamp.services.authentication.IAuthService;
import com.sysmap.bootcamp.services.authentication.login.LoginRequest;
import com.sysmap.bootcamp.services.authentication.login.LoginResponse;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.PostMapping;
import org.springframework.web.bind.annotation.RequestBody;
import org.springframework.web.bind.annotation.RequestMapping;
import org.springframework.web.bind.annotation.RestController;

@RestController
@RequestMapping("/api/v1/authentication")
public class AuthController {

    @Autowired
    private IAuthService _authService;

    @PostMapping("login")
    public ResponseEntity<LoginResponse> Login(@RequestBody LoginRequest request) {
        return ResponseEntity.ok().body(_authService.login(request));
    }
}
