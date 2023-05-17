package com.sysmap.parrot.domain;

import lombok.Data;
import org.springframework.data.annotation.Id;
import org.springframework.data.mongodb.core.index.Indexed;
import org.springframework.data.mongodb.core.mapping.Document;

import java.time.LocalDateTime;
import java.util.UUID;

@Data
@Document(collection = "User")
public class User {
    @Id
    private UUID id;
    private String name;
    @Indexed(unique = true)
    private String email;
    private String password;
    private LocalDateTime createdOn;
    private LocalDateTime updatedOn;
    private String photoUri;

    public User(String name, String email, String password) {
        this.id = UUID.randomUUID();
        this.name = name;
        this.email = email;
        this.password = password;
        this.createdOn = LocalDateTime.now();
    }

    public UUID getId() {
        return this.id;
    }

    public String getUsername() {
        return this.email;
    }
}
