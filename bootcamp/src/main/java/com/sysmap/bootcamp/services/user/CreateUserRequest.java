package com.sysmap.bootcamp.services.user;

import lombok.Builder;
import lombok.Data;

@Data
@Builder
public class CreateUserRequest {
    public String name;
    public String email;
    public String password;
}
