package com.sysmap.parrot.application.authentication;

import java.util.UUID;

public interface IJwtService {
    String generateToken(UUID userId);
    boolean isValidToken(String token, String userId);
}
