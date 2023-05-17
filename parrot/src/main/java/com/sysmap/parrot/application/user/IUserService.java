package com.sysmap.parrot.application.user;

import com.sysmap.parrot.application.user.createUser.CreateUserRequest;
import com.sysmap.parrot.application.user.createUser.CreateUserResponse;
import com.sysmap.parrot.application.user.findUser.FindUserResponse;
import com.sysmap.parrot.domain.User;
import org.springframework.web.multipart.MultipartFile;

import java.util.UUID;

public interface IUserService {
    CreateUserResponse createUser(CreateUserRequest request) throws Exception;
    FindUserResponse findUserByEmail(String email);
    User getUserByEmail(String email);
    User getUserById(UUID id);
    void uploadPhotoProfile(UUID userId, MultipartFile file) throws Exception;
}
