package com.sysmap.parrot.api.user;

import com.sysmap.parrot.application.user.IUserService;
import com.sysmap.parrot.application.user.createUser.CreateUserRequest;
import com.sysmap.parrot.application.user.createUser.CreateUserResponse;
import com.sysmap.parrot.application.user.findUser.FindUserResponse;
import org.springframework.beans.factory.annotation.Autowired;
import org.springframework.http.HttpStatus;
import org.springframework.http.ResponseEntity;
import org.springframework.web.bind.annotation.*;
import org.springframework.web.multipart.MultipartFile;

import java.util.UUID;

@RestController
@RequestMapping("/api/v1/user")
public class UserController {

    @Autowired
    private IUserService _userService;

    @PostMapping("create")
    public ResponseEntity<CreateUserResponse> createUser(@RequestBody CreateUserRequest request) {
        try {
            return ResponseEntity.status(HttpStatus.CREATED).body(_userService.createUser(request));
        } catch (Exception e) {
            return ResponseEntity.status(HttpStatus.BAD_REQUEST).build();
        }
    }

    @GetMapping("details")
    public ResponseEntity<FindUserResponse> getUser(String email) {
        return ResponseEntity.ok().body(_userService.findUserByEmail(email));
    }

    @PostMapping("/photo/upload")
    public ResponseEntity uploadPhotoProfile(@RequestParam UUID userId, @RequestParam("photo") MultipartFile photo) {
        try {
            _userService.uploadPhotoProfile(userId, photo);
            return new ResponseEntity(HttpStatus.OK);
        } catch (Exception e) {
            return new ResponseEntity(e.getMessage(), HttpStatus.BAD_REQUEST);
        }
    }
}
