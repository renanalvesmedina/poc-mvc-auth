package com.sysmap.bootcamp.entities;

import org.springframework.data.mongodb.core.index.Indexed;
import org.springframework.data.mongodb.core.mapping.Document;
import org.springframework.data.annotation.Id;
import org.springframework.security.core.GrantedAuthority;
import org.springframework.security.core.userdetails.UserDetails;

import java.util.Collection;
import java.util.UUID;

@Document(collection = "User")
public class User implements UserDetails {
    @Id
    private UUID id;
    private String name;
    @Indexed(unique = true)
    private String email;
    private String password;

    public User(String name, String email, String password) {
        this.setId();
        this.name = name;
        this.email = email;
        this.password = password;
    }

    protected void setId() {
        this.id = UUID.randomUUID();
    }

    public UUID getId() {
        return this.id;
    }

    @Override
    public Collection<? extends GrantedAuthority> getAuthorities() {
        return null;
    }

    public String getPassword() {
        return this.password;
    }

    @Override
    public String getUsername() {
        return this.email;
    }

    @Override
    public boolean isAccountNonExpired() {
        return true;
    }

    @Override
    public boolean isAccountNonLocked() {
        return true;
    }

    @Override
    public boolean isCredentialsNonExpired() {
        return true;
    }

    @Override
    public boolean isEnabled() {
        return true;
    }
}
