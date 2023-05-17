package com.sysmap.parrot.api.authentication;

import com.sysmap.parrot.application.authentication.IAuthenticationService;
import com.sysmap.parrot.application.authentication.authenticate.AuthenticateRequest;
import com.sysmap.parrot.application.authentication.authenticate.AuthenticateResponse;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.multipart.MultipartFile;

@RestController
@RequestMapping("/api/v1/authentication")
public class AuthenticationController {

    @Autowired
    private IAuthenticationService _authenticationService;

    @PostMapping
    public ResponseEntity<AuthenticateResponse> authenticate(@RequestBody AuthenticateRequest request) {
        try {
            return ResponseEntity.ok().body(_authenticationService.authenticate(request));
        } catch (Exception e) {
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).build();
        }
    }
}
