package com.sysmap.parrot.application.authentication.authenticate;

import lombok.Data;

import java.util.UUID;

@Data
public class AuthenticateResponse {
    public UUID userId;
    public String token;
}
