package com.sysmap.bootcamp.services.user;

import com.sysmap.bootcamp.entities.User;

public interface IUserService {
    String createUser(CreateUserRequest request);
    User getUserByEmail(String email);
}
