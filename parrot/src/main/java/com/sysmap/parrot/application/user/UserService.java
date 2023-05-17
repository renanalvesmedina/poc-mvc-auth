package com.sysmap.parrot.application.user;

import com.sysmap.parrot.application.fileUpload.IFileUploadService;
import com.sysmap.parrot.application.user.createUser.CreateUserRequest;
import com.sysmap.parrot.application.user.createUser.CreateUserResponse;
import com.sysmap.parrot.application.user.findUser.FindUserResponse;
import com.sysmap.parrot.domain.User;
import com.sysmap.parrot.infrastructure.repositories.IUserRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.crypto.password.PasswordEncoder;
import org.springframework.stereotype.Service;
import org.springframework.web.multipart.MultipartFile;

import java.util.UUID;

@Service
public class UserService implements IUserService {

    @Autowired
    private PasswordEncoder _passwordEncoder;
    @Autowired
    private IUserRepository _userRepository;
    @Autowired
    private IFileUploadService _fileUploadService;


    @Override
    public CreateUserResponse createUser(CreateUserRequest request) throws Exception {
        if(!_userRepository.findUserByEmail(request.email).isEmpty()) {
            throw new Exception("Usuario já existe");
        }

        var hash = _passwordEncoder.encode(request.password);

        var user = new User(request.name, request.email, hash);

        _userRepository.save(user);

        return new CreateUserResponse(user.getId().toString());
    }

    @Override
    public FindUserResponse findUserByEmail(String email) {
        var user = _userRepository.findUserByEmail(email).get();

        var response = new FindUserResponse(
                user.getId(),
                user.getName(),
                user.getEmail(),
                user.getCreatedOn(),
                user.getUpdatedOn()
        );

        return response;
    }

    @Override
    public User getUserByEmail(String email) {
        return _userRepository.findUserByEmail(email).get();
    }

    public User getUserById(UUID id) {
        return _userRepository.findUserById(id).get();
    }

    public void uploadPhotoProfile(UUID userId, MultipartFile file) throws Exception {
        var user = _userRepository.findUserById(userId).get();

        var photoUri = "";

        try {
            var fileName = user.getId() + "." + file.getOriginalFilename().substring(file.getOriginalFilename().lastIndexOf(".") + 1);

            photoUri = _fileUploadService.upload(file, fileName);
        } catch (Exception e) {
            throw new Exception(e);
        }

        user.setPhotoUri(photoUri);

        _userRepository.save(user);
    }
}
