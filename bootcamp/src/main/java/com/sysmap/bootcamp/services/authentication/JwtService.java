package com.sysmap.bootcamp.services.authentication;

import io.jsonwebtoken.Jwts;
import io.jsonwebtoken.SignatureAlgorithm;
import org.springframework.stereotype.Service;

import java.util.Date;

@Service
public class JwtService {
    private static final String SECRET_KEY = "46294A404E635266556A586E3272357538782F413F4428472D4B615064536756";
    private static final long EXPIRATION_TIME = 7200000;

    public static String generateToken(String email) {
        return Jwts
                .builder()
                .setSubject(email)
                .setExpiration(new Date(System.currentTimeMillis() + EXPIRATION_TIME))
                .signWith(SignatureAlgorithm.HS256, SECRET_KEY)
                .compact();
    }
}
