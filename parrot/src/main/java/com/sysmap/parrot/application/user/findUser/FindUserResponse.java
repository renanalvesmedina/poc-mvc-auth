package com.sysmap.parrot.application.user.findUser;

import java.time.LocalDateTime;
import java.util.UUID;

public class FindUserResponse {
    public UUID userId;
    public String name;
    public String email;
    public LocalDateTime createdOn;
    public LocalDateTime updatedOn;

    public FindUserResponse(UUID id, String name, String email, LocalDateTime createdOn, LocalDateTime updatedOn) {
        this.userId = id;
        this.name = name;
        this.email = email;
        this.createdOn = createdOn;
        this.updatedOn = updatedOn;
    }
}
