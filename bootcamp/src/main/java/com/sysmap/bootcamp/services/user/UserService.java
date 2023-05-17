package com.sysmap.bootcamp.services.user;

import com.sysmap.bootcamp.entities.User;
import com.sysmap.bootcamp.repositories.IUserRepository;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.security.core.userdetails.UsernameNotFoundException;
import org.springframework.security.crypto.bcrypt.BCryptPasswordEncoder;
import org.springframework.stereotype.Service;
import org.springframework.transaction.annotation.Transactional;

@Service
public class UserService implements IUserService {
    @Autowired
    private IUserRepository _userRepository;
    @Autowired
    private BCryptPasswordEncoder _bCrypt;

    @Override
    public String createUser(CreateUserRequest request) {
        var pass = _bCrypt.encode(request.password);

        var user = new User(request.name, request.email, pass);

        _userRepository.save(user);

        return user.getId().toString();
    }

    @Override
    public User getUserByEmail(String email) {
        var user = _userRepository.findUserByEmail(email).get();

        if (user == null) {
            throw new UsernameNotFoundException("User not found");
        }

        return user;
    }
}
