package com.sysmap.bootcamp.controllers;

import com.sysmap.bootcamp.entities.User;
import com.sysmap.bootcamp.services.user.CreateUserRequest;
import com.sysmap.bootcamp.services.user.IUserService;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;

import java.util.UUID;

@RestController
@RequestMapping("/api/v1/user")
public class UserController {

    @Autowired
    private IUserService _userService;

    @GetMapping()
    public ResponseEntity<User> getUser(String email) {
        return ResponseEntity.ok().body(_userService.getUserByEmail(email));
    }

    @PostMapping()
    public ResponseEntity<String> createUser(@RequestBody CreateUserRequest request) {
        return ResponseEntity.status(HttpStatus.CREATED).body(_userService.createUser(request));
    }
}
