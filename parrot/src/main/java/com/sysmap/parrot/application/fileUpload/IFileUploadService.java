package com.sysmap.parrot.application.fileUpload;

import org.springframework.web.multipart.MultipartFile;

public interface IFileUploadService {
    String upload(MultipartFile file, String fileName) throws Exception;
}
